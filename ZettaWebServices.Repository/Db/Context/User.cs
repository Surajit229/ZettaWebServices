using System;
using System.Collections.Generic;

namespace ZettaWebServices.Repository.Db.Context
{
    public partial class User
    {
        public int UserId { get; set; }
        public int? Exp { get; set; }
        public int? Nbf { get; set; }
        public string Ver { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
        public string Nonce { get; set; }
        public int? Iat { get; set; }
        public int? AuthTime { get; set; }
        public string Tfp { get; set; }
        public string CHash { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public int? PhotoFileId { get; set; }
        public DateTime? LastLoginOn { get; set; }
        public string LastIpaddress { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
