using System;
using System.Collections.Generic;
using System.Text;

namespace Generic.Dapper.UnitOfWork
{
    public interface IGeneralUnitOfWork
    {
        void SaveChanges();
    }
}
