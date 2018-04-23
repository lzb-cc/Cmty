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
                var cmdText = string.Format("delete from CourseCommentSets where Id = {0}", id);
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
                            Id =Convert.ToInt32(reader.GetValue(0)),
                            Poster = Convert.ToString(reader.GetValue(1)),
                            Title = Convert.ToString(reader.GetValue(2)),
                            Content = Convert.ToString(reader.GetValue(3)),
                            PostType = NameOfPostType(Convert.ToInt32(reader.GetValue(4))),
                            PublishDate = Convert.ToDateTime(reader.GetValue(5)),
                            NoComments = Convert.ToInt32(reader.GetValue(6))
                        };
                        ret.Add(model);
                    }
                }
            }

            return ret;
        }
    }
}