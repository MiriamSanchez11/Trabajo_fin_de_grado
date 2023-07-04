using BrainLinkConnect.Dato;
using BrainLinkConnect.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BrainLinkConnect
{
     
    public partial class Form2 : Form
    {
        DataTable tabla;
        Usuario dato = new Usuario();

        public string elementoSeleccionado;
        public Form2()
        {

            InitializeComponent();
            Iniciar();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Guardar();
            Iniciar();
            Consultar();
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Iniciar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Nombre");
            tabla.Columns.Add("Edad");
            dataGridView1.DataSource = tabla;
        }

        private void Guardar()
        {
            UsuarioModel modelo = new UsuarioModel()
            {
                Nombre = textnombre.Text,
                Edad = int.Parse(textedad.Text)
            };
            dato.Guardar(modelo);
        }
        private void Consultar()
        {
            foreach (var item in dato.Consultar())
            {
                DataRow fila = tabla.NewRow();
                fila["Nombre"] = item.Nombre;
                fila["Edad"] = item.Edad;
                tabla.Rows.Add(fila);


            }
        }
        private void Limpiar()
        {
            textnombre.Text = " ";
            textedad.Text = " " ;
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                this.elementoSeleccionado = row.Cells[0].Value.ToString();
            }
        }
      
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imagenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImagenes formularioImg = new FormImagenes(); // crea una instancia del formulario
            formularioImg.Show(); // muestra el formulario

        }

        private void señalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 formularioSeñales = new Form1(elementoSeleccionado); // crea una instancia del formulario
            formularioSeñales.Show(); // muestra el formulario
            this.Hide();

        }

        private void configuraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //elementoSeleccionado = ElementoSeleccionado.ToString();

            FormConfig formularioconf = new FormConfig(elementoSeleccionado); // crea una instancia del formulario
            formularioconf.Show(); // muestra el formulario 
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void configuraciónSonidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSonido formsonido = new FormSonido(elementoSeleccionado); // crea una instancia del formulario
            formsonido.Show();// muestra el formulario
        }

    }
}
