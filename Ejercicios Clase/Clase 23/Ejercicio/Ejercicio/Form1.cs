using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ejercicio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una ruta valida");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtPath.Text))
            {

            string[] paths = Directory.GetFiles(txtPath.Text, "*.xml");

            this.progressBar1.Maximum = paths.Count();
            this.progressBar1.Value = 0;

            Alumno p = new Alumno();

            foreach (var item in paths)
            {
                try
                {
                    p.DeSerializarXml(item);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                    Close();
                }

                this.progressBar1.Value = this.progressBar1.Value + 1;
             }

                MessageBox.Show("Guardado en la base de datos con exito.");     
            }
            else
            {
                MessageBox.Show("Debe seleccionar una carpeta.");
            }
        }
    }
}
