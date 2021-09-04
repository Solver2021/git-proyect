using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NewApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            if (usuario != "" && password != "")
            {
                Conexion conectar = new Conexion();
                SqlConnection cn = conectar.cadena();
                string datos = "select Usuario, Clave from [a MEDICO] where [Usuario]= '" + usuario+"'";
                SqlCommand comand = new SqlCommand(datos, cn);
                SqlDataAdapter result = new SqlDataAdapter(comand);

                SqlDataAdapter sda = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0].ToString() == usuario)
                    {
                        if (dt.Rows[0][1].ToString() == password)
                        {
                            MessageBox.Show("Bienvenido!!");
                            Consultas formulariobusqueda = new Consultas();
                            this.Hide();
                            formulariobusqueda.ShowDialog();
                            this.Show();
                            txtUsuario.Text = "";
                            txtPassword.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta!.");
                            txtPassword.Text = "";
                            txtPassword.Focus();
                        }
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Usuario No Encontrado");
                    txtUsuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Faltan Campos.");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label1.Font = new Font(label1.Font.FontFamily, 10);
            label2.Font = new Font(label2.Font.FontFamily, 10);
        }
    }
}
