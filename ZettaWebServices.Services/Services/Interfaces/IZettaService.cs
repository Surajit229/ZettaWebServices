using System;
using System.Collections.Generic;
using System.Text;
using ZettaWebServices.Models.GenericModels;
using ZettaWebServices.Models.RequestModels;

namespace ZettaWebServices.Services.Services.Interfaces
{
    public interface IZettaService
    {
        ResponseModel CRUDSearchEngineSubmissionInput(SearchEngineSubmissionInput input, int operation, bool isMultiple = false);
        ResponseModel CRUDUser(UserInput input, int operation, bool isMultiple = false);
    }
}
