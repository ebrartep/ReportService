using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alisan.RaporRestApi.Core
{
    public static class ConfigData
    {
        private static IConfiguration currentConfig;

        public static void SetConfig(IConfiguration configuration)
        {
            currentConfig = configuration;
        }

        public static T GetConfiguration<T>(string key)
        {
            try
            {
                var getValue = currentConfig.GetValue<T>(key);
                return getValue;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
