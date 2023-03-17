using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OnlineShopping_PrioritetsLösning
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connstring = "server=localhost;uid=root;pwd=Kadino44;database=onlineshopping";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connstring;
            con.Open();
          


            string sql = "select * from onlineshopping.products";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //For loop som loopar igenom alla namnen

                string item = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    item += reader.GetValue(i).ToString() + " - ";
                }
                listBox1.Items.Add(item);


            }
            reader.Close();

            this.Controls.Remove(button3);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {


                Form Form3 = new Form3();
                Form3.Show();
                this.Hide();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
