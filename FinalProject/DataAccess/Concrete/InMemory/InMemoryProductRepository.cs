﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductRepository: IProductDal
    {
        List<Product> _products;
        public InMemoryProductRepository()
        {
            _products = new List<Product>
            {
                new Product { CategoryId=1 ,ProductId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15 },
                new Product { CategoryId = 2,ProductId = 1,ProductName = "Kamera",UnitPrice = 500,UnitsInStock = 3 },
                new Product { CategoryId = 3,ProductId = 2,ProductName = "Telefon",UnitPrice = 1500,UnitsInStock = 2 },
                new Product { CategoryId=4 ,ProductId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65 },
                new Product { CategoryId=5 ,ProductId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1 },
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product,bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product,bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where => içindeki şartı sağlayan bütün elemanları yeni bir liste haline getitir
            return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
