using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontShop.Clases
{
    public class ClsUtils
    {
        public static Image stringToImage(string inputString)
        {
            try
            {
                if (File.Exists(inputString))
                {
                    return Image.FromFile(inputString);
                }
                else
                {
                    Exception ex = new Exception(@"El repositorio imagen debe estar en C:\Prg\RepositorioImagen.");
                    throw ex;
                }
              
            }
            catch (Exception)
            {

                throw;
            }
         
        }
    }
}
