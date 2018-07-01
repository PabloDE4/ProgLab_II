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

namespace Ejercicio60
{
    public partial class Form1 : Form
    {
        SqlConnection cadenaConexion;
        SqlCommand cadenaComando;
        SqlDataReader cadenaDataReader;

        public Form1()
        {
            InitializeComponent();
            cadenaConexion = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = AdventureWorks2012; Integrated Security = True");
            cadenaComando = new SqlCommand("select name from Production.Product", cadenaConexion);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            try
            {
                cadenaConexion.Open();
                cadenaDataReader = cadenaComando.ExecuteReader();

                comboBox1.Items.Clear();
                while (cadenaDataReader.Read())
                {
                    comboBox1.Items.Add(cadenaDataReader[0].ToString());
                }

                MessageBox.Show("Conectado a la base de datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar: " + ex.ToString());
            }
            finally
            {
                cadenaDataReader.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cadenaComando = new SqlCommand("INSERT INTO Production.Product (Name, ProductNumber, MakeFlag, FinishedGoodsFlag, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice, DaysToManufacture,SellStartDate,rowguid,ModifiedDate) VALUES ('" + textBox1.Text + "', AR-8000, 0, 0, 100, 750, 0.00, 0.00, 0, 2008-04-30 00:00:00.000, 2008-04-30 00:00:00.000, 2014-02-08 10:01:36.827)", cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                label2.Text = "Agregado correctamente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó: " + ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cadenaComando = new SqlCommand("UPDATE Production.Product SET Name = '" + textBox1.Text + "' WHERE Name = '" + textBox1.Text + "'", cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                label2.Text = "Modificado correctamente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó: " + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cadenaComando = new SqlCommand("DELETE FROM Production.Product WHERE Name = '" + textBox1.Text + "'", cadenaConexion);
                cadenaComando.ExecuteNonQuery();
                label2.Text = "Borrado correctamente";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se conectó: " + ex.ToString());
            }
        }

        //Para mostrar en el textbox el item seleccionado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saras = (ComboBox)sender;
            textBox1.Text = saras.SelectedItem.ToString();
        }

    }
}
