using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZettaWebServices.Repository.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Db { get; }
        void Save();
        void Dispose();
    }
}
