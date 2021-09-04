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
    public partial class Consultas : Form
    {
        public string consecutivo;


        public Consultas()
        {
            InitializeComponent();
              
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            if (txtNumero.Text != "")
            {
                Conexion conectar = new Conexion();
                SqlConnection cn = conectar.cadena();
                string numero = txtNumero.Text;
                consecutivo = txtNumero.Text;
                string datos = " select [Secuencia Ingreso] as 'beneficio', [Documento de Identidad] as 'DOCUMENTO', " +
                    "[Primer Nombre] AS 'NOMBRE', consec as 'FACTURA',[fecha de pago] AS 'F PAGO'," +
                    " origen AS 'Facturador', [valor eps] as 'valor a Pagar'," +
                    " [valor usuario] as 'Valor pagado',copago AS 'Copago', moderación AS 'Moderacion'," +
                    "poliza AS 'Poliza' from[a PACIENTE] pa " +
                    "inner join[a RECIBO] re on pa.[Secuencia Ingreso] = re.beneficiante where consec ='"+numero+"'";
                SqlCommand comand = new SqlCommand(datos, cn);
                SqlDataAdapter resultado = new SqlDataAdapter(comand);
                DataTable tabla = new DataTable();
                resultado.Fill(tabla);
                dataGridView1.DataSource = tabla;
                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No Se Ecnontraron Datos.");
                }
            }
            else
            {
                MessageBox.Show("Debe Escribir La Cedula.");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Datos formularioDatos = new Datos();
            DataGridViewRow rellenar = dataGridView1.Rows[e.RowIndex];
            formularioDatos.txtBeneficio.Text = rellenar.Cells[0].Value.ToString();
            formularioDatos.txtDocumento.Text = rellenar.Cells[1].Value.ToString();
            formularioDatos.txtNombre.Text = rellenar.Cells[2].Value.ToString();
            formularioDatos.txtFactura.Text = rellenar.Cells[3].Value.ToString();
            formularioDatos.txtFechaPago.Text = rellenar.Cells[4].Value.ToString();
            formularioDatos.txtOrigen.Text = rellenar.Cells[5].Value.ToString();
            formularioDatos.txtValorAPagar.Text = rellenar.Cells[6].Value.ToString();
            formularioDatos.txtValorPagado.Text = rellenar.Cells[7].Value.ToString();
            formularioDatos.txtCopago.Text = rellenar.Cells[8].Value.ToString();
            formularioDatos.txtModeracion.Text = rellenar.Cells[9].Value.ToString();
            formularioDatos.txtPoliza.Text = rellenar.Cells[10].Value.ToString();
            formularioDatos.consecutivo = txtNumero.Text;
            formularioDatos.ShowDialog();
        }

        public void mensaje()
        {
            MessageBox.Show("Hola");
        }


       
    }
}
