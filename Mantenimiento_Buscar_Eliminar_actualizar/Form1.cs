using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;


namespace Mantenimiento_Buscar_Eliminar_actualizar
{
    public partial class Form1 : Form
    {

        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = objneg.N_listar_clientes();

        }


        void mantenimiento( String accion) {

            objent.codigo = txt_codigo.Text;
            objent.nombre = txt_nombre.Text;
            objent.edad = Convert.ToInt32(text_edad.Text);
            objent.telefono = Convert.ToInt32(text_telefono.Text);
            objent.accion = accion;
            String men = objneg.N_Mantenimiento(objent);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        void limpiar() {

            txt_codigo.Text = "";
            txt_nombre.Text = "";
            text_edad.Text = "";
            text_telefono.Text = "";
            text_buscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_clientes();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (txt_codigo.Text == "") {


                if (MessageBox.Show("¿Deseas Registrar a " + txt_nombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
            


        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text != "")
            {


                if (MessageBox.Show("¿Deseas Modificar a " + txt_nombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txt_codigo.Text != "")
            {


                if (MessageBox.Show("¿Deseas Eliminar a " + txt_nombre.Text + "?", "Mensaje", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }

        }

        private void text_buscar_TextChanged(object sender, EventArgs e)
        {

            if (text_buscar.Text != "")
            {

                objent.nombre = text_buscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_Buscar_clientes(objent);
                dataGridView1.DataSource = dt;
            }
            else {
                dataGridView1.DataSource = objneg.N_listar_clientes();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;

            txt_codigo.Text = dataGridView1[0, fila].Value.ToString();
            txt_nombre.Text = dataGridView1[1, fila].Value.ToString();
            text_edad.Text = dataGridView1[2, fila].Value.ToString();
            text_telefono.Text = dataGridView1[3, fila].Value.ToString();



        }
    }
}
