using FrontShop.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontShop.Vista.Registro
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                string Msg = "Ok";
                UsuarioDto registro = new UsuarioDto();
                registro.Administrador = false;
                if (rbAdministrador.Checked)
                {
                    registro.Administrador = true;
                }
                registro.Apellido = txtApellido.Text;
                registro.Nombre = txtNombre.Text;
                registro.NombreUsuario = txtNombreUsuario.Text;
                registro.Contraseña = txtContraseña.Text;
                Msg=registro.Validar(txtRevalidarContraseña);
                if (Msg=="Ok")
                {
                    registro = Clases.Registro.ClsRegistro.RegistrarUsuario(registro);
                }

                if (registro.Mensaje!="")
                {
                    MessageBox.Show(registro.Mensaje);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
