using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrontShop.Modelos;
using FrontShop.Clases.Login;

namespace FrontShop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Vista.Registro.FrmRegistro registro = new Vista.Registro.FrmRegistro();
                registro.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Btn_Entrar_Click(object sender, EventArgs e)
        {
            try
            {
                string Msg = "Ok";
                LoginDto Login = new LoginDto();
                infToken infToken= new infToken();
                Login.Contraseña = txtContraseña.Text;
                Login.NombreUsuario = txtUsuario.Text;
                Msg = Login.Validar();
                if (Msg == "Ok")
                {
                    infToken = ClsLogin.Entrar(Login);
                }

                if (infToken.Message=="Ok")
                {
                    TokenDto.Login(infToken);
                    Vista.Menu.MacBurger macBurger = new Vista.Menu.MacBurger();
                    macBurger.Show();
                    this.Hide();
                }

                if (infToken.Message != "" && infToken.Message != "Ok")
                {
                    MessageBox.Show(infToken.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
