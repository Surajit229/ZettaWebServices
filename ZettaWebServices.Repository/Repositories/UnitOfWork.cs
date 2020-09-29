using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZettaWebServices.Repository.Db.Context;
using ZettaWebServices.Repository.Repositories.Interfaces;

namespace ZettaWebServices.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ZettaWebServiceContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork()
        {
            _dbContext = new ZettaWebServiceContext();
        }

        public DbContext Db
        {
            get { return _dbContext; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Save()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
