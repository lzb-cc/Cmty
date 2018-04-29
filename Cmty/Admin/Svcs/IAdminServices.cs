using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Admin.Svcs
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IAdminServices”。
    [ServiceContract]
    public interface IAdminServices
    {
        [OperationContract]
        void SendEamil(string sendTo, string subject, string content);
    }
}
