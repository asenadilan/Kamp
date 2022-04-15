using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager pm = new ProductManager(new InMemoryProductRepository());
            foreach (var product in pm.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
