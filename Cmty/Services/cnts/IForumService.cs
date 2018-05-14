using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.cnts
{
    [ServiceContract]
    interface IForumService
    {
        [OperationContract]
        CommonLib.ReturnState AddPost(PostModel model);

        [OperationContract]
        CommonLib.ReturnState DelPost(int id);

        [OperationContract]
        List<PostModel> GetPostList();

        [OperationContract]
        List<PostModel> GetPostListByPoster(string poster);

        [OperationContract]
        PostModel GetPostById(int id);

        [OperationContract]
        PostReplyModel GetPostReplyById(int id);

        [OperationContract]
        CommonLib.ReturnState UpdatePost(PostModel model);

        [OperationContract]
        List<PostReplyModel> GetPostReplyListByPostId(int id);

        [OperationContract]
        CommonLib.ReturnState AddResponseToPost(PostReplyModel model);

        [OperationContract]
        CommonLib.ReturnState DelResponseToPostById(int id);

        [OperationContract]
        List<PostReplyModel> GetReplyResponseListByPostId(int id);

        [OperationContract]
        CommonLib.ReturnState AddResponseToPostReply(PostReplyModel model);

        [OperationContract]
        CommonLib.ReturnState DelResponseToPostReplyById(int id);

        [OperationContract]
        List<string> GetPostTypeList();
    }

    [DataContract]
    public class PostModel
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember]
        public string Poster { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string PostType { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember(IsRequired =true)]
        public DateTime PublishDate { get; set; }

        [DataMember(IsRequired = true)]
        public int NoComments { get; set; }
    }

    [DataContract]
    public class PostReplyModel
    {
        [DataMember(IsRequired = true)]
        public int Id { get; set; }

        [DataMember]
        public string Responser { get; set; }

        [DataMember(IsRequired = true)]
        public int ResponseTo { get; set; }

        [DataMember(IsRequired = true)]
        public DateTime ResponseDate { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}
