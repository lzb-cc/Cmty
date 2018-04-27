using Services.cnts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonLib;
using Services.DAL.Forum;

namespace Services.svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“ForumService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 ForumService.svc 或 ForumService.svc.cs，然后开始调试。
    public class ForumService : IForumService
    {
        public ReturnState AddPost(PostModel model)
        {
            return ForumOperator.AddPost(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState AddResponseToPost(PostReplyModel model)
        {
            return ForumOperator.AddResponseToPost(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState AddResponseToPostReply(PostReplyModel model)
        {
            return ForumOperator.AddResponseToPostReply(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState DelPost(int id)
        {
            return ForumOperator.RemovePost(id) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState DelResponseToPostById(int id)
        {
            return ForumOperator.RemoveResponseToPostById(id) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public ReturnState DelResponseToPostReplyById(int id)
        {
            return ForumOperator.RemoveResponseToPostReplyById(id) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }

        public PostModel GetPostById(int id)
        {
            return ForumOperator.QueryPostById(id);
        }

        public List<PostModel> GetPostList()
        {
            return ForumOperator.QueryPostList();
        }

        public List<PostModel> GetPostListByPoster(string poster)
        {
            return ForumOperator.QueryPostListByEamil(poster);
        }

        public PostReplyModel GetPostReplyById(int id)
        {
            return ForumOperator.QueryPostReplyById(id);
        }

        public List<PostReplyModel> GetPostReplyListByPostId(int id)
        {
            return ForumOperator.QueryPostReplyListByPostId(id);
        }

        public List<PostReplyModel> GetReplyResponseListByPostId(int id)
        {
            return ForumOperator.QueryReplyResponseListByPostId(id);
        }

        public ReturnState UpdatePost(PostModel model)
        {
            return ForumOperator.UpdatePost(model) ? ReturnState.ReturnOK : ReturnState.ReturnError;
        }
    }
}
