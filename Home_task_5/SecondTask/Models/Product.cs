using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2.Models
{
    public struct Size
    {
        public float x
        {
            get;
            set;
        }
        public float y
        {
            get;
            set;
        }
        public float z
        {
            get;
            set;
        }
        public override string ToString()
        {
            return $"{x} * {y} * {z}";
        }
        public Size (float x, float y, float z)
        {
            this.x = x ;
            this.y = y ;
            this.z = z ;
        }
    }
    public class Product
    {
        public string Name
        {
            get; set;
        }
        public Size Size
        {
            get; set;
        }

        public Product(string name, Size size)
        {
            Name = name;
            Size = size;
        }

        public Product() { }
    }
}
