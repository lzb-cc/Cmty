using Services.cnts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Services.DAL.Forum
{
    public static class ForumOperator
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static int IndexOfPostType(string postType)
        {
            var result = 0;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id from cfg_PostType where Desp = N'{0}'", postType);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            return result;
        }
        public static string NameOfPostType(int postType)
        {
            var result = string.Empty;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Desp from cfg_PostType where Id = {0}", postType);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = Convert.ToString(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            return result;
        }

        public static bool AddPost(PostModel model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into PostMsg values(N'{0}', N'{1}', {2}, N'{3}', '{4}', {5})", model.Poster, model.Title, IndexOfPostType(model.PostType), model.Content, model.PublishDate, model.NoComments);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }
            return result;
        }

        public static bool RemovePost(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from PostMsg where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<PostModel> QueryPostList()
        {
            var ret = new List<PostModel>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id, Email, Title, Content, PType, PDate, NoComments from PostMsg order by PDate DESC");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = new PostModel()
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Poster = Convert.ToString(reader.GetValue(1)),
                            Title = Convert.ToString(reader.GetValue(2)),
                            Content = Convert.ToString(reader.GetValue(3)),
                            PostType = NameOfPostType(Convert.ToInt32(reader.GetValue(4))),
                            PublishDate = Convert.ToDateTime(reader.GetValue(5)),
                            NoComments = Convert.ToInt32(reader.GetValue(6))
                        };
                        ret.Add(model);
                    }
                    conn.Close();
                }
            }

            return ret;
        }

        public static List<PostModel> QueryPostListByEamil(string email)
        {
            var ret = new List<PostModel>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id, Email, Title, Content, PType, PDate, NoComments from PostMsg where Email = N'{0}' order by PDate DESC", email);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = new PostModel()
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Poster = Convert.ToString(reader.GetValue(1)),
                            Title = Convert.ToString(reader.GetValue(2)),
                            Content = Convert.ToString(reader.GetValue(3)),
                            PostType = NameOfPostType(Convert.ToInt32(reader.GetValue(4))),
                            PublishDate = Convert.ToDateTime(reader.GetValue(5)),
                            NoComments = Convert.ToInt32(reader.GetValue(6))
                        };
                        ret.Add(model);
                    }
                    conn.Close();
                }
            }

            return ret;
        }

        public static PostModel QueryPostById(int id)
        {
            PostModel model = null;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id, Email, Title, Content, PType, PDate, NoComments from PostMsg where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model = new PostModel()
                        {
                            Id = Convert.ToInt32(reader.GetValue(0)),
                            Poster = Convert.ToString(reader.GetValue(1)),
                            Title = Convert.ToString(reader.GetValue(2)),
                            Content = Convert.ToString(reader.GetValue(3)),
                            PostType = NameOfPostType(Convert.ToInt32(reader.GetValue(4))),
                            PublishDate = Convert.ToDateTime(reader.GetValue(5)),
                            NoComments = Convert.ToInt32(reader.GetValue(6))
                        };
                    }
                    conn.Close();
                }
            }

            return model;
        }

        public static bool UpdatePost(PostModel model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("update PostMsg set Title = N'{1}', Content = N'{2}', PType = {3}, NoComments = {4} where Id = {0}", model.Id, model.Title, model.Content, IndexOfPostType(model.PostType), model.NoComments);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<PostReplyModel> QueryPostReplyListByPostId(int id)
        {
            var list = new List<PostReplyModel>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id, Email, Reply, Content, RDate from PostReply where Reply = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = new PostReplyModel();
                        model.Id = Convert.ToInt32(reader.GetValue(0));
                        model.Responser = Convert.ToString(reader.GetValue(1));
                        model.ResponseTo = Convert.ToInt32(reader.GetValue(2));
                        model.Content = Convert.ToString(reader.GetValue(3));
                        model.ResponseDate = Convert.ToDateTime(reader.GetValue(4));
                        list.Add(model);
                    }
                    conn.Close();
                }
            }
            return list;
        }

        public static bool AddResponseToPost(PostReplyModel model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into PostReply values(N'{0}', {1}, N'{2}', '{3}')", model.Responser, model.ResponseTo, model.Content, DateTime.Now);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool RemoveResponseToPostById(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from PostReply where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static List<PostReplyModel> QueryReplyResponseListByPostId(int id)
        {
            var list = new List<PostReplyModel>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id, Email, Reply, Content, RDate from PostReplyMsg where Reply = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var model = new PostReplyModel();
                        model.Id = Convert.ToInt32(reader.GetValue(0));
                        model.Responser = Convert.ToString(reader.GetValue(1));
                        model.ResponseTo = Convert.ToInt32(reader.GetValue(2));
                        model.Content = Convert.ToString(reader.GetValue(3));
                        model.ResponseDate = Convert.ToDateTime(reader.GetValue(4));
                        list.Add(model);
                    }
                    conn.Close();
                }
            }
            return list;
        }

        public static PostReplyModel QueryPostReplyById(int id)
        {
            var model = new PostReplyModel();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Id, Email, Reply, Content, RDate from PostReply where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.Id = Convert.ToInt32(reader.GetValue(0));
                        model.Responser = Convert.ToString(reader.GetValue(1));
                        model.ResponseTo = Convert.ToInt32(reader.GetValue(2));
                        model.Content = Convert.ToString(reader.GetValue(3));
                        model.ResponseDate = Convert.ToDateTime(reader.GetValue(4));
                    }
                    conn.Close();
                }
            }
            return model;
        }

        public static List<string> QueryPostTypeList()
        {
            var result = new List<string>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("select Desp from cfg_PostType");
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader.GetValue(0)));
                    }
                }
            }
            return result;
        }

        public static bool AddResponseToPostReply(PostReplyModel model)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("insert into PostReplyMsg values(N'{0}', {1}, N'{2}', '{3}')", model.Responser, model.ResponseTo, model.Content, DateTime.Now);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }

        public static bool RemoveResponseToPostReplyById(int id)
        {
            var result = false;
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmdText = string.Format("delete from PostReplyMsg where Id = {0}", id);
                using (var cmd = new SqlCommand(cmdText, conn))
                {
                    result = cmd.ExecuteNonQuery() > 0;
                    conn.Close();
                }
            }

            return result;
        }


    }
}