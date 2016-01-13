using ServerContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {

            int port = 2137;
            Console.WriteLine("Server running on port {0}", port);

            Uri baseAddress = new Uri("net.tcp://localhost:" + port + "/Server");
            NetTcpBinding binding = new NetTcpBinding();
            binding.MaxBufferPoolSize = 4 * 128 * 1024 * 1024;
            binding.MaxBufferSize = 512 * 1024 * 1024;
            binding.MaxReceivedMessageSize = 512 * 1024 * 1024;
            
            ServiceHost sh = new ServiceHost(typeof(ServerService), baseAddress);
            sh.AddServiceEndpoint(typeof(IPictureService), binding, baseAddress);

            using (sh)
            {
                sh.Open();
                Console.WriteLine("Server ready");
                Console.ReadLine(); //wait

                sh.Close();
            }
        }
    }
}
