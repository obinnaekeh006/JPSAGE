using Generic.Dapper.Interfaces;
using Generic.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Dapper.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly string _connectionString;

        public Repository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        protected void Save() => _context.SaveChanges();
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }
        public async Task<bool> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            Save();

            return true;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }



        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }



        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        [Obsolete]
        public void Sp_VendorRegAdminDisapproved(int FormID, int SupplierID )
        {

            //var outParameter = new SqlParameter("@outParameter", DbType.Int32)
            //{
            //    Direction = ParameterDirection.Output
            //};

            var supplierID = new SqlParameter("@SupplierID", DbType.Int32);
            var formID = new SqlParameter("@FormID", DbType.Int32);

            //var outP = "dd";

            //var returnFormat = _context.Database.ExecuteSqlCommand("sp_VendorRegAdminDisapproved @p0, @p1", parameters: new[] { SupplierID.ToString(), FormID.ToString()});
            // var returnFormat = _context.Database.ExecuteSqlCommand("sp_VendorRegAdminDisapproved @SupplierID, @FormID", supplierID, formID);
            //var returnFormat = _context.Database.ExecuteSqlInterpolated($"sp_VendorRegAdminDisapproved {@SupplierID}, {@FormID}");
        }

    }
}
