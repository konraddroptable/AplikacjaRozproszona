using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerContract;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Server
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, MaxItemsInObjectGraph = 2147483646)]
    public class ServerService : IPictureService
    {
        Download download = new Download();


        public Picture DownloadPicture(string page)
        {
            return download.DownloadPicture(page);
        }

        public string TextMe(string msg)
        {
            return download.TextMe(msg);
        }
    }

}
