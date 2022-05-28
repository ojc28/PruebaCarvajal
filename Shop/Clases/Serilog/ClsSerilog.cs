using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Serilog;
using System.Configuration;
using Shop.Interfaces;

namespace Shop.Clases.Serilog
{
     public class ClsSerilog
    {
        /// <summary>
        /// Escribe en la tabla dbo.LogEvents o en la ruta del web config que contenga el tag RutaSerilog en un archivo log.txt
        /// Nutget necesarios Serilog, Segilog.Settings.File, Segilog.Sinks.File, Serilog.Sinks.MSSqlServer
        /// </summary>

        ClsLogSqlServer logSqlServer = new ClsLogSqlServer();
        ClsLogTXT logTXT = new ClsLogTXT();

        internal LogDto RegistrarError(Exception ex)
        {
            LogDto log = new LogDto();
            string result;
            try
            {
                result = logSqlServer.RegistrarError(ex);
                log.ErrorCode = result;
                log.Message = $"{ex.Message}**{ex.StackTrace}";
            }
            catch (Exception ex2)
            {
                result = logTXT.RegistrarError(ex2);
                log.ErrorCode = result;
                log.Message = $"{ex2.Message}**{ex2.StackTrace}";
            }
            return log;
        }
    }
}