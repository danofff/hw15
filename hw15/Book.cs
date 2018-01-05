using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15
{
    [Serializable]
    public class Book
    {
        public string name { get; set; }
        public double price { get; set; }
        public string author { get; set; }
        public short year { get; set; }

        public Book():this("noname")
        {

        }
        public Book(string name) : this(name, 0.0)
        {
            this.name = name;
        }
        public Book(string name,double price) : this(name, price, "noauthor")
        {
            this.name = name;
            this.price = price;
        }
        public Book(string name, double price,string author) : this(name, price, author,0)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }
        public Book(string name, double price, string author,short year)
        {
            this.name = name;
            this.price = price;
            this.author = author;
            this.year = year;
        }
    }
}
