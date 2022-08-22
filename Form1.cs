using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sql_Otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GROV6BS;Initial Catalog=MyTestdb;Integrated Security=True;Pooling=False");

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("insert into UserTab values (@ID,@Name,@Age)", baglanti);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));

            cmd.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde kaydedildi.");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GROV6BS;Initial Catalog=MyTestdb;Integrated Security=True;Pooling=False");

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("Update UserTab set Name = @Name, Age = @Age where ID = @ID", baglanti);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", double.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde güncellendi.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GROV6BS;Initial Catalog=MyTestdb;Integrated Security=True;Pooling=False");

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("Delete UserTab where ID = @ID", baglanti);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
       
            cmd.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarılı bir şekilde silindi.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-GROV6BS;Initial Catalog=MyTestdb;Integrated Security=True;Pooling=False");

            baglanti.Open();

            SqlCommand cmd = new SqlCommand("Select * From UserTab", baglanti);
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

                       
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myTestdbDataSet.UserTab' table. You can move, or remove it, as needed.
            this.userTabTableAdapter.Fill(this.myTestdbDataSet.UserTab);

        }
    }
}
