using ServerContract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string page = textBox1.Text;

            try
            {
                EndpointAddress address = new EndpointAddress(new Uri("net.tcp://localhost:2137/Server"));
                NetTcpBinding binding = new NetTcpBinding();
                binding.MaxBufferPoolSize = 4 * 128 * 1024 * 1024;
                binding.MaxBufferSize = 128 * 1024 * 1024;
                binding.MaxReceivedMessageSize = 128 * 1024 * 1024;
                ChannelFactory<IPictureService> fac = new ChannelFactory<IPictureService>(binding, address);
                fac.Open();
                var svc = fac.CreateChannel();

                MessageBox.Show(svc.TextMe("World"));
                Picture pic = svc.DownloadPicture(page);
                Bitmap bmp = pic.GetBitmap();
                pictureBox1.Image = new Bitmap(bmp, new Size(bmp.Width < 894 ? bmp.Width : 894, bmp.Height < 542 ? bmp.Height : 542));
            }
            catch (EndpointNotFoundException ex)
            {
                MessageBox.Show("Brak połączenia z serwerem.\n\n" + ex.Message.ToString());
            }
            
            

        }
    }
}
