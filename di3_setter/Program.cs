using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace di3_setter
{
    internal interface IServiceClass
    {
        String ServiceInfo();
    }

    internal class ServiceClassA : IServiceClass
    {
        public String ServiceInfo()
        {
            return "我是ServceClassA";
        }
    }

    internal class ServiceClassB : IServiceClass
    {
        public String ServiceInfo()
        {
            return "我是ServceClassB";
        }
    }

    internal class ClientClass
    {
        private IServiceClass _serviceImpl;

        public void Set_ServiceImpl(IServiceClass serviceImpl)
        {
            this._serviceImpl = serviceImpl;
        }

        public void ShowInfo()
        {
            Console.WriteLine(_serviceImpl.ServiceInfo());
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            IServiceClass serviceA = new ServiceClassA();
            IServiceClass serviceB = new ServiceClassB();
            ClientClass client = new ClientClass();

            client.Set_ServiceImpl(serviceA);
            client.ShowInfo();
            client.Set_ServiceImpl(serviceB);
            client.ShowInfo();
            Console.ReadLine();
        }
    }
}
