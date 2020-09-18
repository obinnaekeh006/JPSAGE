using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Dapper.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        void Create(T entity);
        Task<bool> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);
        void Update(T entity);

        void Delete(T entity);
        void Sp_VendorRegAdminDisapproved(int FormID, int SupplierID);
        int Count(Func<T, bool> predicate);
    }
}
