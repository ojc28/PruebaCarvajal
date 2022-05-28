using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace Shop.Clases.Serilog
{
    public class ClsLogTXT
    {
        public string RegistrarError(Exception ex)
        {
            string CarpetaDestino = ConfigurationManager.AppSettings["RutaSerilog"].ToString();
            if (!Directory.Exists(CarpetaDestino))
            {
                Directory.CreateDirectory(CarpetaDestino);
            }

            string identificador = System.DateTime.Now.ToString("yyyyMMddmmhhssfff");

            using (var log = new LoggerConfiguration()
                   .WriteTo.File($"{CarpetaDestino}\\LOG.TXT", rollingInterval: RollingInterval.Day)
                   .CreateLogger())
            {
                Log.Error($"|{identificador}|{ex.Message}|{ex.StackTrace}|");
            }
            return identificador;
        }
    }
}