using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ZettaWebServices.Models.RequestModels;
using ZettaWebServices.Repository.Db.SP_Models;

namespace ZettaWebServices.Repository.Db.Context
{
    public partial class ZettaWebServiceContext : DbContext
    {
        public virtual DbSet<SP_Execute> JsonResult { get; set; }

        public void Initialize_StoredProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SP_Execute>(entity =>
            {
                entity.HasNoKey();
            });
        }

        public string SP_CRUD_SearchEngineSubmission(SearchEngineSubmissionInput input, int operation, out bool isSuccess, out string message, out int? totalRecords)
        {
            isSuccess = true;
            message = string.Empty;
            totalRecords = null;

            SP_Execute jsonResult = new SP_Execute();
            var sqlQuery = "EXEC [SP_CRUD_SearchEngineSubmission] @SubmissionNo, @URL, @SubmissionURL, @Status, @Operation, @IsSuccess OUT, @Message OUT, @TotalRecords OUT";
            SqlParameter[] parameters =
            {
                new SqlParameter("@SubmissionNo", input.SubmissionNo ?? (object)DBNull.Value),
                new SqlParameter("@URL", input.Url ?? (object)DBNull.Value),
                new SqlParameter("@SubmissionURL", input.SubmissionUrl ?? (object)DBNull.Value),
                new SqlParameter("@Status", input.Status ?? (object)DBNull.Value),
                new SqlParameter("@Operation", operation),
                new SqlParameter{ ParameterName = "@IsSuccess", DbType = DbType.Boolean, Direction = ParameterDirection.Output, Value = isSuccess },
                new SqlParameter{ ParameterName = "@Message", DbType = DbType.AnsiString, Size = 100, Direction = ParameterDirection.Output, Value = message },
                new SqlParameter{ ParameterName = "@TotalRecords", DbType = DbType.Int32, Direction = ParameterDirection.Output, Value = totalRecords, IsNullable = true },
            };
            jsonResult = this.JsonResult.FromSqlRaw(sqlQuery, parameters).AsNoTracking().AsEnumerable().FirstOrDefault();
            isSuccess = Convert.ToBoolean(parameters[5].Value);
            message = Convert.ToString(parameters[6].Value);
            totalRecords = string.IsNullOrEmpty(Convert.ToString(parameters[7].Value)) ? (int?)null : Convert.ToInt32(parameters[7].Value);
            return jsonResult == null ? null : jsonResult.JsonResult;
        }

        public string SP_CRUD_User(UserInput input, int operation, out bool isSuccess, out string message, out int? totalRecords)
        {
            isSuccess = true;
            message = string.Empty;
            totalRecords = null;

            SP_Execute jsonResult = new SP_Execute();
            var sqlQuery = "EXEC [SP_CRUD_User] @UserId, @exp, @nbf, @ver, @iss, @aud, @nonce, @iat, @auth_time, @tfp, @c_hash, @Username, @DisplayName, @Email, @PhotoFileId, @LastLoginOn, @LastIPAddress, @CreatedBy, @ModifiedBy, @DeletedBy, @Operation, @IsSuccess OUT, @Message OUT, @TotalRecords OUT";
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserId", input.UserId ?? (object)DBNull.Value),
                new SqlParameter("@exp", input.Exp ?? (object)DBNull.Value),
                new SqlParameter("@nbf", input.Nbf ?? (object)DBNull.Value),
                new SqlParameter("@ver", input.Ver ?? (object)DBNull.Value),
                new SqlParameter("@iss", input.Iss ?? (object)DBNull.Value),
                new SqlParameter("@aud", input.Aud ?? (object)DBNull.Value),
                new SqlParameter("@nonce", input.Nonce ?? (object)DBNull.Value),
                new SqlParameter("@iat", input.Iat ?? (object)DBNull.Value),
                new SqlParameter("@auth_time", input.AuthTime ?? (object)DBNull.Value),
                new SqlParameter("@tfp", input.Tfp ?? (object)DBNull.Value),
                new SqlParameter("@c_hash", input.CHash ?? (object)DBNull.Value),
                new SqlParameter("@Username", input.Username ?? (object)DBNull.Value),
                new SqlParameter("@DisplayName", input.DisplayName ?? (object)DBNull.Value),
                new SqlParameter("@Email", input.Email ?? (object)DBNull.Value),
                new SqlParameter("@PhotoFileId", input.PhotoFileId ?? (object)DBNull.Value),
                new SqlParameter("@LastLoginOn", input.LastLoginOn ?? (object)DBNull.Value),
                new SqlParameter("@LastIPAddress", input.LastIpaddress ?? (object)DBNull.Value),
                new SqlParameter("@CreatedBy", input.CreatedBy ?? (object)DBNull.Value),
                new SqlParameter("@ModifiedBy", input.ModifiedBy ?? (object)DBNull.Value),
                new SqlParameter("@DeletedBy", input.DeletedBy ?? (object)DBNull.Value),
                new SqlParameter("@Operation", operation),
                new SqlParameter{ ParameterName = "@IsSuccess", DbType = DbType.Boolean, Direction = ParameterDirection.Output, Value = isSuccess },
                new SqlParameter{ ParameterName = "@Message", DbType = DbType.AnsiString, Size = 100, Direction = ParameterDirection.Output, Value = message },
                new SqlParameter{ ParameterName = "@TotalRecords", DbType = DbType.Int32, Direction = ParameterDirection.Output, Value = totalRecords, IsNullable = true },
            };
            jsonResult = this.JsonResult.FromSqlRaw(sqlQuery, parameters).AsNoTracking().AsEnumerable().FirstOrDefault();
            isSuccess = Convert.ToBoolean(parameters[21].Value);
            message = Convert.ToString(parameters[22].Value);
            totalRecords = string.IsNullOrEmpty(Convert.ToString(parameters[23].Value)) ? (int?)null : Convert.ToInt32(parameters[23].Value);
            return jsonResult == null ? null : jsonResult.JsonResult;
        }
    }
}