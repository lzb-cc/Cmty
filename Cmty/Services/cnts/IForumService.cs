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
    }

    [DataContract]
    public class PostModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Poster { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string PostType { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }

        [DataMember]
        public int NoComments { get; set; }
    }

    [DataContract]
    public class PostReplyModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Responser { get; set; }

        [DataMember]
        public int ReponseTo { get; set; }

        [DataMember]
        public DateTime ReponseDate { get; set; }

        [DataMember]
        public string Content { get; set; }
    }
}
