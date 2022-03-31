using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Contactos objetoCN = new CN_Contactos();
        private string idProducto=null;
        private bool Editar = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarContactos();
        }

        private void MostrarContactos() {

            CN_Contactos objeto = new CN_Contactos();
            dataGridView1.DataSource = objeto.MostrarCont();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //INSERTAR
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarCont(txtName.Text, txtLastName.Text, txtAddress.Text, txtDate.Text, txtPhoneNumber.Text, txtCelular.Text, txtCorreo.Text, txtEstado.Text, txtGenero.Text);
                    MessageBox.Show("it inserted correctly");
                    MostrarContactos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("It cannot add the dates for: " + ex);
                }
            }
            //EDITAR
            if (Editar == true) {

                try
                {
                    objetoCN.EditarCont(txtName.Text, txtLastName.Text, txtAddress.Text, txtDate.Text, txtPhoneNumber.Text,idProducto, txtCelular.Text, txtCorreo.Text, txtEstado.Text, txtGenero.Text);
                    MessageBox.Show("it edited correctly");
                    MostrarContactos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex) {
                    MessageBox.Show("I'am sorry but It can't edit the dates for: " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtName.Text = dataGridView1.CurrentRow.Cells["Nombres"].Value.ToString();
                txtLastName.Text = dataGridView1.CurrentRow.Cells["Apellidos"].Value.ToString();
                txtAddress.Text = dataGridView1.CurrentRow.Cells["Direccion"].Value.ToString();
                txtDate.Text = dataGridView1.CurrentRow.Cells["Fecha_Cumpleanos"].Value.ToString();
                txtPhoneNumber.Text = dataGridView1.CurrentRow.Cells["Numero"].Value.ToString();
                txtCelular.Text = dataGridView1.CurrentRow.Cells["Movil"].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells["Correo"].Value.ToString();
                txtEstado.Text = dataGridView1.CurrentRow.Cells["EstadoCivil"].Value.ToString();
                txtGenero.Text = dataGridView1.CurrentRow.Cells["Genero"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
                MessageBox.Show("Choose the line First");
        }

        private void limpiarForm() {
            txtLastName.Clear();
            txtAddress.Text = "";
            txtDate.Clear();
            txtPhoneNumber.Clear();
            txtName.Clear();
            txtCelular.Clear();
            txtCorreo.Clear();
            txtEstado.Clear();
            txtGenero.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarCont(idProducto);
                MessageBox.Show("Deleted Correctly");
                MostrarContactos();
            }
            else
                MessageBox.Show("Choose a line Please");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
       
        }
    }
}
