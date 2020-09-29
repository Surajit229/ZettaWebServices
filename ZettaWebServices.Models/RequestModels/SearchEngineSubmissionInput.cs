using System;
using System.Collections.Generic;
using System.Text;

namespace ZettaWebServices.Models.RequestModels
{
    public class SearchEngineSubmissionInput
    {
        public int? SubmissionNo { get; set; }
        public string Url { get; set; }
        public string SubmissionUrl { get; set; }
        public bool? Status { get; set; }
    }
}
