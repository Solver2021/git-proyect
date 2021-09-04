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
    public partial class Datos : Form
    {
        public string consecutivo;

        public Datos()
        {
            InitializeComponent();
        }

        private void Datos_Load(object sender, EventArgs e)
        {
            bloquearCajas();
            txtConsecutivo.Text = consecutivo;
            if (txtCopago.Enabled == false && txtModeracion.Enabled == false && txtPoliza.Enabled == false)
            {
                btnActuzalizar.Enabled = false;
                btnLimpiar.Enabled = false;
            }
        }

        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (txtPoliza.Enabled != false)
            {
                txtPoliza.Text = "";
                txtPoliza.Focus();
            }
            if (txtCopago.Enabled != false)
            {
                txtCopago.Text = "";
            }
            if (txtModeracion.Enabled != false)
            {
                txtModeracion.Text = "";
            }
            txtCopago.Focus();
        }
        public void bloquearCajas()
        {
            txtConsecutivo.Enabled = false;
            txtBeneficio.Enabled = false;
            txtDocumento.Enabled = false;
            txtNombre.Enabled = false;
            txtFactura.Enabled = false;
            txtFechaPago.Enabled = false;
            txtOrigen.Enabled = false;
            txtValorAPagar.Enabled = false;
            txtValorPagado.Enabled = false;
            if (txtCopago.Text != "" && txtCopago.Text != "0")
            {
                txtCopago.Enabled = false;
            }
            if (txtModeracion.Text != "" && txtModeracion.Text != "0")
            {
                txtModeracion.Enabled = false;
            }
            if (txtPoliza.Text != "" && txtPoliza.Text != "0")
            {
                txtPoliza.Enabled = false;
            }
        }

        private void btnActuzalizar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Por Favor Confirme. Desea Actualizar?", "Actualizar Datos", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                Conexion conectar = new Conexion();
                SqlConnection cn = conectar.cadena();
                float copago = System.Convert.ToSingle(txtCopago.Text);
                float moderacion = System.Convert.ToSingle(txtModeracion.Text);
                string poliza = txtPoliza.Text;

                string datos = " update [a RECIBO] set copago = '"+copago+"', moderación = '"+moderacion+"', poliza = '"+poliza+"' where consec = '"+consecutivo+"'";
                SqlCommand cmd = new SqlCommand(datos, cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Consecutivo: "+ txtConsecutivo.Text);
                MessageBox.Show("Datos Actualizados.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Se Actulizaron Los Datos");
            }
        }

        private void txtCopago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtModeracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
