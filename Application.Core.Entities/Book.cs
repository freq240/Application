using System;

namespace Application.Core.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Book(string name, double price)
        {  
            Name = name;
            Price = price;
        }
    }
}
