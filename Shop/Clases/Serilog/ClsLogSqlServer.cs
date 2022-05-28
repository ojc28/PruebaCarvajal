using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Shop.Clases.Serilog
{
    public class ClsLogSqlServer : IClsLog
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ToString();
        private const string _schemaName = "dbo";
        private const string _tableName = "LogEvents";
        public string RegistrarError(Exception ex)
        {
            try
            {

                SqlConnection sqlcon = new SqlConnection();
                sqlcon.ConnectionString = _connectionString;
                sqlcon.Open();


                Log.Logger = new LoggerConfiguration().WriteTo
                    .MSSqlServer(
                        connectionString: _connectionString,
                        sinkOptions: new MSSqlServerSinkOptions
                        {
                            TableName = _tableName,
                            SchemaName = _schemaName,
                            AutoCreateSqlTable = true
                        },
                        restrictedToMinimumLevel: LogEventLevel.Debug,
                        formatProvider: null,
                        columnOptions: GetColumnOptions(),
                        logEventFormatter: null)
                    .CreateLogger();


                Log.Debug("Getting started");
                string identificador = System.DateTime.Now.ToString("yyyyMMddmmhhssfff");
                Log.Error("{Message}{Exception}{Identificador}", ex.Message, ex.StackTrace, identificador);

                Log.CloseAndFlush();


                sqlcon.Close();
                return identificador;
            }
            catch (Exception ex2)
            {
                throw ex2;
            }

        }
        public static ColumnOptions GetColumnOptions()
        {
            ColumnOptions columnOptions = new ColumnOptions();

            // Remove all the StandardColumn
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);


            // Override the default Primary Column of Serilog by your custom column name
            columnOptions.Id.ColumnName = "LogId";

            // Add all the custom coumns
            columnOptions.AdditionalDataColumns = new List<DataColumn>
         {
               new DataColumn { DataType = typeof(string), ColumnName = "Identificador" },

         };
            return columnOptions;
        }
    }
}