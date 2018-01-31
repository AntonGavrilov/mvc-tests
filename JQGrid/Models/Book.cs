using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JQGrid.Models
{
    public class Book : IComparable<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }

        public int CompareTo(Book other)
        {
            if (other.Id > this.Id)
            {
                return -1;
            }
            else if (other.Id == this.Id)
                return 0;
            else
                return 1;
        }
    }
}