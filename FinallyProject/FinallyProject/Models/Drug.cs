using System;
using System.Collections.Generic;
using System.Text;

namespace FinallyProject.Models
{
    class Drug
    {
        public string Name { get; set; }
        public DrugType Type { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public int Id { get; }

        private static int _id = 0;
        public Drug()
        {
            _id++;
            Id = _id;
        }

        public Drug(string name, double price, int count, DrugType type) : this()
        {
            Name = name;
            Price = price;
            Count = count;
            Type = type;

        }

        public override string ToString()
        {
            return $"{Id} - {Name} {Price} man {Count} sayda {Type} tipli";
        }
    }
}
