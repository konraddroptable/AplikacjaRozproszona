using ServerContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Download : IPictureService
    {
        private byte[] DownloadFromUrl(string url)
        {
            byte[] data;
            using (WebClient webClient = new WebClient())
            {
                data = webClient.DownloadData(url);
            }

            return data;
        }

        public Picture DownloadPicture(string page)
        {
            Picture pic = new Picture();
            pic.ByteArray = DownloadFromUrl(page);

            return pic;
        }

        public string TextMe(string msg)
        {
            return "Hello " + msg;
        }


    }
}
