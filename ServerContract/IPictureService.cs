using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerContract
{
    [ServiceContract]
    public interface IPictureService
    {
        [OperationContract]
        Picture DownloadPicture(string page);

        [OperationContract]
        string TextMe(string msg);
    }
}
