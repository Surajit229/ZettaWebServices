using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZettaWebServices.Utility;

namespace ZettaWebServices.WebAPI.Infrastructure
{
    public static class ConfigurationSettings
    {
        public static void Configure(IConfiguration Configuration)
        {
            AppSettings.ConnectionString = Convert.ToString(Configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}
