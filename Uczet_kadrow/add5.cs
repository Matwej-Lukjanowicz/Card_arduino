﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Uczet_kadrow
{
    public partial class add5 : Form
    {

        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=base_ber_pek;password=12345;");


        public add5()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            connection.Open();
            string insert = "INSERT INTO child (Famil,Ima,Otchest,date_bd,daddy) VALUES ('" + tb1.Text + "', '" + tb2.Text + "', '" + tb3.Text + "', '" + tb4.Text + "', '" + comboBox1.Text + "')";


            MySqlCommand command = new MySqlCommand(insert, connection);

            try
            {
                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Добавленно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    connection.Close();

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add5_Load(object sender, EventArgs e)
        {
            try
            {

                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select sotrudnik.idsotrudnik as `` from sotrudnik", connection);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "sotrudnik");
                data1.DataSource = ds.Tables[0];
                connection.Close();
                bool x = true;

                data1.Sort(data1.Columns[0], x ? ListSortDirection.Ascending : ListSortDirection.Descending);






                for (int i = 0; i < data1.RowCount - 1; i++)
                {
                    comboBox1.Items.Add(data1.Rows[i].Cells[0].Value);
                }

                try
                {
                    comboBox1.Text = comboBox1.Items[0].ToString();

                }
                catch
                { }

            }
            catch
            {
                MessageBox.Show("Отсутствует соединение или база уже загружена!");
            }
        }

        private void Tb2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Data2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Data1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Tb1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Tb4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Tb3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
