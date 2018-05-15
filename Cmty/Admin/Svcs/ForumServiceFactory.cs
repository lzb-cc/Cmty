using Admin.ForumService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Svcs
{
    public class ForumServiceFactory
    {
        private static ForumService.ForumService forumClient = new ForumService.ForumService();
        private static bool specify = true;

        public ReturnState AddPost(PostModel model)
        {
            ReturnState result;
            forumClient.AddPost(model, out result, out specify);
            return result;
        }

        public ReturnState DelPost(int id)
        {
            ReturnState result;
            forumClient.DelPost(id, true, out result, out specify);
            return result;
        }

        public PostModel[] GetPostList()
        {
            return forumClient.GetPostList();
        }

        public PostModel[] GetPostListByPoster(string poster)
        {
            return forumClient.GetPostListByPoster(poster);
        }

        public PostModel GetPostById(int id)
        {
            return forumClient.GetPostById(id, true);
        }

        public PostReplyModel GetPostReplyById(int id)
        {
            return forumClient.GetPostReplyById(id, true);
        }

        public ReturnState UpdatePost(PostModel model)
        {
            ReturnState result;
            forumClient.UpdatePost(model, out result, out specify);
            return result;
        }

        public PostReplyModel[] GetPostReplyListByPostId(int id)
        {
            return forumClient.GetPostReplyListByPostId(id, true);
        }

        public ReturnState AddResponseToPost(PostReplyModel model)
        {
            ReturnState result;
            forumClient.AddResponseToPost(model, out result, out specify);
            return result;
        }

        public ReturnState DelResponseToPostById(int id)
        {
            ReturnState result;
            forumClient.DelResponseToPostById(id, true, out result, out specify);
            return result;
        }

        public PostReplyModel[] GetReplyResponseListByPostId(int id)
        {
            return forumClient.GetReplyResponseListByPostId(id, true);
        }

        public ReturnState AddResponseToPostReply(PostReplyModel model)
        {
            ReturnState result;
            forumClient.AddResponseToPostReply(model, out result, out specify);
            return result;
        }

        public ReturnState DelResponseToPostReplyById(int id)
        {
            ReturnState result;
            forumClient.DelResponseToPostReplyById(id, true, out result, out specify);
            return result;
        }

        public string[] GetPostTypeList()
        {
            return forumClient.GetPostTypeList();
        }
    }
}