using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using Shop.Models;
using System.Data;

namespace Shop.Clases
{
    public class ClsUtils
    {
        public static string ComputeSha256Hash(string rawData)
        {
            try
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<datos> DataTableToList(DataTable masVendidos)
        {
            try
            {
                List<datos> list = new List<datos>();
                list = (from DataRow dr in masVendidos.Rows
                        select new datos()
                        {
                            Codigo = dr["Codigo"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Total = int.Parse(dr["Total"].ToString())
                        }).ToList();
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}