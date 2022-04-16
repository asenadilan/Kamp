using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager: IProductService
    {
        //Bir iş Sınıfı başka sınıfları newlemez
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductAdded);
            }
            _productDal.Add(product);
            return new Result(true,"Ürün eklendi");
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            return new DataResult(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min,decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
