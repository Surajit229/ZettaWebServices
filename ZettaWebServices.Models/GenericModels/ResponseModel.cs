using System;
using System.Collections.Generic;
using System.Text;

namespace ZettaWebServices.Models.GenericModels
{
    public class ResponseModel
    {
        public object Response { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public int? TotalRecords { get; set; }
        public object Error { get; set; }
    }
}
