﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ejercicio61
{
    public partial class Form1 : Form
    {
        List<Persona> list;

        public Form1()
        {
            InitializeComponent();

        }

        private void lstPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Persona p = list[lstPersonas.SelectedIndex];
                txtNombre.Text = p.Nombre;
                txtApellido.Text = p.Apellido;
            }
            catch (Exception)
            {
                txtNombre.Text = "";
                txtApellido.Text = "";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Length > 0 && txtApellido.Text.Length > 0)
            {
                Persona persona = new Persona(txtNombre.Text, txtApellido.Text);
                try
                {
                    if (PersonaDAO.Guardar(persona))
                    {
                        btnLeer_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Para agregar las casillas de nombre y apellido no pueden estar vacías.");
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            try
            {
                list = PersonaDAO.Leer();
                lstPersonas.Items.Clear();
                lstPersonas.BeginUpdate();
                foreach (Persona p in list)
                {
                    lstPersonas.Items.Add(String.Format("{0} {1}", p.Nombre, p.Apellido));
                }
                lstPersonas.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstPersonas.SelectedIndex;
                if (index >= 0)
                {
                    Persona p = list[index];
                    if (PersonaDAO.Borrar(p.ID))
                    {
                        btnLeer_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar a alguien de la lista.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = lstPersonas.SelectedIndex;
                if (index >= 0)
                {
                    Persona p = list[index];
                    if (PersonaDAO.Modificar(p.ID, txtNombre.Text, txtApellido.Text))
                    {
                        btnLeer_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar a alguien de la lista.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.ToString());
            }
        }

        private void lstPersonas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonaDAO.cadenaDataReader = PersonaDAO.cadenaComando.ExecuteReader();

            comboBox1.Items.Clear();
            while (PersonaDAO.cadenaDataReader.Read())
            {
                comboBox1.Items.Add(PersonaDAO.cadenaDataReader[0].ToString());
            }
        }
    }
}
