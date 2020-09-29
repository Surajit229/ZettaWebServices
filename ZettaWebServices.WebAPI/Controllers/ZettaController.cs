using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZettaWebServices.Models.RequestModels;
using ZettaWebServices.Services.Services.Interfaces;
using ZettaWebServices.Utility;

namespace ZettaWebServices.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZettaController : ControllerBase
    {
        private readonly IZettaService _zettaService;

        public ZettaController(IZettaService _zettaService)
        {
            this._zettaService = _zettaService;
        }

        #region SearchEngineSubmission
        [HttpPost]
        [Route("AddSearchEngineSubmission")]
        public ActionResult AddSearchEngineSubmission(SearchEngineSubmissionInput model)
        {
            var response = _zettaService.CRUDSearchEngineSubmissionInput(model, (int)Enums.Operation.Insert);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateSearchEngineSubmission")]
        public ActionResult UpdateSearchEngineSubmission(SearchEngineSubmissionInput model)
        {
            var response = _zettaService.CRUDSearchEngineSubmissionInput(model, (int)Enums.Operation.Update);
            return Ok(response);
        }
        
        [HttpDelete]
        [Route("DeleteSearchEngineSubmission/{submissionNo}")]
        public ActionResult DeleteSearchEngineSubmission(int submissionNo)
        {
            var response = _zettaService.CRUDSearchEngineSubmissionInput(new SearchEngineSubmissionInput { SubmissionNo = submissionNo }, (int)Enums.Operation.Delete);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetSearchEngineSubmissionById/{submissionNo}")]
        public ActionResult GetSearchEngineSubmissionById(int submissionNo)
        {
            var response = _zettaService.CRUDSearchEngineSubmissionInput(new SearchEngineSubmissionInput { SubmissionNo = submissionNo }, (int)Enums.Operation.SelectById);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllSearchEngineSubmissions")]
        public ActionResult GetAllSearchEngineSubmission()
        {
            var response = _zettaService.CRUDSearchEngineSubmissionInput(new SearchEngineSubmissionInput(), (int)Enums.Operation.SelectAll, true);
            return Ok(response);
        }
        #endregion
    }
}
