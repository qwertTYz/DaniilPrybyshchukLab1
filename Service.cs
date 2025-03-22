using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Library
{
    public class Service
    {
        public string Name { get; set; }
        
        public string Address { get; set; }

        private bool IsServiceWorking { get; set; }

        public Service()
        {
            
        }

        public Service(string name, string address, bool is_service_working)
        {
            this.Name = name;
            this.Address = address;
            this.IsServiceWorking = is_service_working;
        }

        public static Service Create(string name, string address, bool is_service_working)
        {
            return new Service(name, address, is_service_working);
        }

        public void PrintObject()
        {
            Console.WriteLine($"name: {this.Name}   address: {this.Address}   is_working: {this.IsServiceWorking}");
        }
    }
}
