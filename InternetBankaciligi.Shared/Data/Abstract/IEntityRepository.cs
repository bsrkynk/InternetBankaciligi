using InternetBankaciligi.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternetBankaciligi.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T: class,IEntity, new()
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);  //x=>x.UserId==1 //tek bir sonuç döner
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> Predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate); //kayıdın önceden var mı yok mu bakılması için
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);  //kayıtların sayısını vs bulmak için 
        void DetachEntity();
    }
}
