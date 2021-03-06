using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Core katmanı diğer sınıfları referans almaz
    //T sınırlandırmak =>generic constraint 
    //class : referans tip olabilir
    //Ientity :  olabilir veya onu implemente eden bir  nesne olabilir
    //new  : newlenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null); // hem filtreli hem de filtresiz getirme
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
