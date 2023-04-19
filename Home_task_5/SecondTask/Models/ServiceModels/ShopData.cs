using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Models.ServiceModels
{
    public class StoreData
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public StoreData(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public StoreData() { }
    }
}