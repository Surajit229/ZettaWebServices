using System;
using System.Collections.Generic;
using System.Text;
using ZettaWebServices.Models.RequestModels;
using ZettaWebServices.Repository.Db.Context;
using ZettaWebServices.Repository.Repositories.Interfaces;

namespace ZettaWebServices.Repository.Repositories
{
    public class ZettaRepository : BaseRepository<SearchEngineSubmissionInput>, IZettaRepository
    {
        IUnitOfWork _unitOfWork;

        public ZettaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string CRUDSearchEngineSubmission(SearchEngineSubmissionInput input, int operation, out bool isSuccess, out string message, out int? totalRecords)
        {
            ZettaWebServiceContext context = (ZettaWebServiceContext)_unitOfWork.Db;
            var result = context.SP_CRUD_SearchEngineSubmission(input, operation, out isSuccess, out message, out totalRecords);
            return result;
        }

        public string CRUDUser(UserInput input, int operation, out bool isSuccess, out string message, out int? totalRecords)
        {
            ZettaWebServiceContext context = (ZettaWebServiceContext)_unitOfWork.Db;
            var result = context.SP_CRUD_User(input, operation, out isSuccess, out message, out totalRecords);
            return result;
        }
    }
}
