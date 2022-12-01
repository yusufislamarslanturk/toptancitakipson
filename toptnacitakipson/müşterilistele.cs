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
namespace toptnacitakipson
{
    public partial class müşterilistele : Form
    {
        public müşterilistele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-ELT3SDS; Initial Catalog=Stok_Takip;Integrated Security=True");
        DataSet daset = new DataSet();
        private void müşterilistele_Load(object sender, EventArgs e)
        {
            Kayıt_Göster();

        }

        private void Kayıt_Göster()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from müşteri", baglanti);
            adtr.Fill(daset, "müşteri");
            dataGridView2.DataSource = daset.Tables["müşteri"];
            baglanti.Close();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView2.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoyad.Text = dataGridView2.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtTelefon.Text = dataGridView2.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView2.CurrentRow.Cells["adres"].Value.ToString();
            txtMail.Text = dataGridView2.CurrentRow.Cells["email"].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update müşteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc");
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müşteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Müşteri kaydı güncellendi.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from müşteri where tc='" + dataGridView2.CurrentRow.Cells["tc"].Value.ToString() + "'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["müşteri"].Clear();
            Kayıt_Göster();
            MessageBox.Show("Kayıt silindi.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from müşteri where tc like '%"+txtTcAra.Text+"%'",baglanti);
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
