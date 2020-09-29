using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using ZettaWebServices.Models.GenericModels;
using ZettaWebServices.Models.RequestModels;
using ZettaWebServices.Repository.Repositories.Interfaces;
using ZettaWebServices.Services.Services.Interfaces;
using ZettaWebServices.Utility;

namespace ZettaWebServices.Services.Services
{
    public class ZettaService : BaseService, IZettaService
    {
        private readonly IZettaRepository _zettaRepository;

        public ZettaService(IUnitOfWork unitOfWork, IZettaRepository _zettaRepository)
            : base(unitOfWork)
        {
            this._zettaRepository = _zettaRepository;
        }

        public ResponseModel CRUDSearchEngineSubmissionInput(SearchEngineSubmissionInput input, int operation, bool isMultiple = false)
        {
            ResponseModel response = new ResponseModel();

            string result = _zettaRepository.CRUDSearchEngineSubmission(input, operation, out bool isSuccess, out string message, out int? totalRecords);
            response.ResponseCode = isSuccess ? (int)Enums.StatusCode.OK : (int)Enums.StatusCode.InternalError;
            if (isMultiple)
                response.Response = !string.IsNullOrEmpty(result) ? JsonConvert.DeserializeObject<List<ExpandoObject>>(result) : null;
            else
                response.Response = !string.IsNullOrEmpty(result) ? JsonConvert.DeserializeObject<ExpandoObject>(result) : null;
            response.Message = message;
            response.TotalRecords = totalRecords;
            response.Error = !isSuccess;
            return response;
        }

        public ResponseModel CRUDUser(UserInput input, int operation, bool isMultiple = false)
        {
            ResponseModel response = new ResponseModel();

            string result = _zettaRepository.CRUDUser(input, operation, out bool isSuccess, out string message, out int? totalRecords);
            response.ResponseCode = isSuccess ? (int)Enums.StatusCode.OK : (int)Enums.StatusCode.InternalError;
            if (isMultiple)
                response.Response = !string.IsNullOrEmpty(result) ? JsonConvert.DeserializeObject<List<ExpandoObject>>(result) : null;
            else
                response.Response = !string.IsNullOrEmpty(result) ? JsonConvert.DeserializeObject<ExpandoObject>(result) : null;
            response.Message = message;
            response.TotalRecords = totalRecords;
            response.Error = !isSuccess;
            return response;
        }
    }
}
