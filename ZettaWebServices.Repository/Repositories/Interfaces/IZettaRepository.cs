using System;
using System.Collections.Generic;
using System.Text;
using ZettaWebServices.Models.RequestModels;
using ZettaWebServices.Repository.Db.Context;

namespace ZettaWebServices.Repository.Repositories.Interfaces
{
    public interface IZettaRepository
    {
        string CRUDSearchEngineSubmission(SearchEngineSubmissionInput input, int operation, out bool isSuccess, out string message, out int? totalRecords);
        string CRUDUser(UserInput input, int operation, out bool isSuccess, out string message, out int? totalRecords);
    }
}
