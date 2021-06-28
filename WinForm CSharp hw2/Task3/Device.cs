using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_CSharp_hw2
{
    public class Device
    {
        
        public Device(string name, string characteristics, string comment, string cost)
        {
            Name = name;
            Characteristics = characteristics;
            Comment = comment;
            Cost = cost;
            Added = false;
        }

        public string Name { get; set; }
        public string Characteristics { get; set; }
        public string Comment { get; set; }
        public string Cost { get; set; }
        public bool Added { get; set; }
        public override string ToString()
        {
            if (Added)
            {
                return $"{Name} {Characteristics} {Comment}";
            }
            return $"{Name}";
        }
    }
    
}
