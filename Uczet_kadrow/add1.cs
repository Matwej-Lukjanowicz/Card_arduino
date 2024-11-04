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
using System.Threading;
using System.IO;
using System.Threading;

using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Uczet_kadrow
{
    public partial class add1 : Form
    {

        
        int numbername = 0;
        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;


        int k;
        int ind = 1;

        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;database=base_ber_pek;password=12345;");



        public add1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            connection.Open();
            string insert = "INSERT INTO card_sotr (dolg,kodotdel,start_work,end_work) VALUES ('" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + tb1.Text + "', '" + tb2.Text + "')";


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

        private void Add1_Load(object sender, EventArgs e)
        {
                    


            try
            {

                connection.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("select raspisanie.idraspisanie as `` from raspisanie", connection);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "raspisanie");
                data1.DataSource = ds.Tables[0];
                connection.Close();
                bool x = true;

                data1.Sort(data1.Columns[0], x ? ListSortDirection.Ascending : ListSortDirection.Descending);



                connection.Open();
                 da = new MySqlDataAdapter("select raspisanie.idraspisanie as `` from raspisanie", connection);
                 cb = new MySqlCommandBuilder(da);
                 ds = new DataSet();
                da.Fill(ds, "raspisanie");
                data2.DataSource = ds.Tables[0];
                connection.Close();

                data2.Sort(data2.Columns[0], x ? ListSortDirection.Ascending : ListSortDirection.Descending);




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


                for (int i = 0; i < data2.RowCount - 1; i++)
                {
                    comboBox2.Items.Add(data2.Rows[i].Cells[0].Value);
                }

                try
                {
                    comboBox2.Text = comboBox2.Items[0].ToString();

                }
                catch
                { }

            }
            catch
            {
                MessageBox.Show("Отсутствует соединение или база уже загружена!");
            }
        }
    }
}
