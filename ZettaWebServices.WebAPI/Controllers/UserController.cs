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
    public class UserController : ControllerBase
    {
        private readonly IZettaService _zettaService;

        public UserController(IZettaService _zettaService)
        {
            this._zettaService = _zettaService;
        }

        /*
         *  Here, I have passed CreatedBy/ModifiedBy/Deleted (Not nullable fields) by as blank data, because of I have no claims or authenticated token as data.
         */
        #region U S E R
        [HttpPost]
        [Route("AddUser")]
        public ActionResult AddUser(UserInput model)
        {
            model.CreatedBy = "1";
            var response = _zettaService.CRUDUser(model, (int)Enums.Operation.Insert);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult UpdateUser(UserInput model)
        {
            model.ModifiedBy = "1";
            var response = _zettaService.CRUDUser(model, (int)Enums.Operation.Update);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteUser/userId={userId}&lastIPAddress{lastIPAddress}")]
        public ActionResult DeleteUser(int userId, string lastIPAddress)
        {
            var response = _zettaService.CRUDUser(new UserInput { UserId = userId, DeletedBy = "1", LastIpaddress = lastIPAddress }, (int)Enums.Operation.Delete);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUserById/{userId}")]
        public ActionResult GetUserById(int userId)
        {
            var response = _zettaService.CRUDUser(new UserInput { UserId = userId }, (int)Enums.Operation.SelectById);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult GetAllUsers()
        {
            var response = _zettaService.CRUDUser(new UserInput(), (int)Enums.Operation.SelectAll, true);
            return Ok(response);
        }
        #endregion
    }
}
