using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase6
{
    public partial class Form1 : Form
    {
        public Form1()
        {            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes) {
                this.Close();            
            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
             this.btn_salir.Enabled = checkBox1.Checked;
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.textBox1.Text = "Masculino";
            }
            else if (radioButton2.Checked)
            {
                this.textBox1.Text = "Femenino";
            }
            else {
                this.textBox1.Text = "Indeterminado";
            }

            if (this.checkBox1.Checked)
            {
                this.checkBox1.Text = "Checked";
            }
            else
            {
                this.checkBox1.Text = "No checked";
            }


        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label1.Text = this.listBox1.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.label2.Text = this.comboBox1.SelectedItem.ToString();
        }

    }
}
