using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerContract
{
    [DataContract]
    public class Picture
    {
        [DataMember]
        public byte[] ByteArray { get; set; }
        private Bitmap bmp = null;

        private void RenderBitmap()
        {
            using (var ms = new MemoryStream(this.ByteArray))
            {
                this.bmp = new Bitmap(ms);
            }
        }

        public Bitmap GetBitmap()
        {
            if (this.bmp == null && ByteArray != null)
                RenderBitmap();

            return this.bmp;
        }
        
    }
}
