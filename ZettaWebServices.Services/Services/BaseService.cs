using System;
using System.Collections.Generic;
using System.Text;
using ZettaWebServices.Repository.Repositories.Interfaces;

namespace ZettaWebServices.Services.Services
{
    public class BaseService : IDisposable
    {
        protected IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
        public static object ToDBNull(object value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }
    }
}
