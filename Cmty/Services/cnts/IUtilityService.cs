using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services.cnts
{
    [ServiceContract]
    public interface IUtilityService
    {
        [OperationContract]
        int IndexOfUniversity(string university);

        [OperationContract]
        string NameOfUniversity(int id);

        [OperationContract]
        int IndexOfJobTitle(string name);

        [OperationContract]
        string NameOfJobTitle(int id);
    }
}
