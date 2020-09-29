using System;
using System.Collections.Generic;

namespace ZettaWebServices.Repository.Db.Context
{
    public partial class SearchEngineSubmission
    {
        public int SubmissionNo { get; set; }
        public string Url { get; set; }
        public string SubmissionUrl { get; set; }
        public bool? Status { get; set; }
    }
}
