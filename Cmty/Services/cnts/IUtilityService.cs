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
    }
}
