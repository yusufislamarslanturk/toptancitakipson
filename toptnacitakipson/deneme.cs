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
    public partial class deneme : Form
    {
        public deneme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ELT3SDS;Initial Catalog=Stok_Takip;Integrated Security=True");
        DataSet daset = new DataSet();

        private void deneme_Load(object sender, EventArgs e)
        {
            ürünlistele();
            kategorigetir();
        }
        private void kategorigetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from kategoribilgileri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboKategori.Items.Add(read["kategori"].ToString());
            }
            baglanti.Close();

        }


        private void ÜrünListele()
        {
            ürünlistele();
        }

        private void ürünlistele()
        {
            
            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from urun", baglanti);
            adptr.Fill(daset, "urun");
            dataGridView2.DataSource = daset.Tables["urun"];
            baglanti.Close();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BarkodNotxt.Text = dataGridView2.CurrentRow.Cells["barkodno"].Value.ToString();
            Kategoritxt.Text = dataGridView2.CurrentRow.Cells["kategori"].Value.ToString();
            Markatxt.Text = dataGridView2.CurrentRow.Cells["marka"].Value.ToString();
            ÜrünAdıtxt.Text = dataGridView2.CurrentRow.Cells["urunadi"].Value.ToString();
            Miktaritxt.Text = dataGridView2.CurrentRow.Cells["miktari"].Value.ToString();
            AlışFiyatıtxt.Text = dataGridView2.CurrentRow.Cells["alisfiyati"].Value.ToString();
            SatışFiyatıtxt.Text = dataGridView2.CurrentRow.Cells["satisfiyati"].Value.ToString();
            lblMiktarı.Text = dataGridView2.CurrentRow.Cells["miktari"].Value.ToString();
        }
        private void btnGüncelle_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update urun set urunadi=@urunadi,miktari=@miktari,alisfiyati=@alisfiyati,satisfiyati=@satisfiyati where barkodno=@barkodno", baglanti);
            komut.Parameters.AddWithValue("@barkodno", BarkodNotxt.Text);
            komut.Parameters.AddWithValue("@urunadi", ÜrünAdıtxt.Text);
            komut.Parameters.AddWithValue("@miktari", int.Parse(Miktaritxt.Text));
            komut.Parameters.AddWithValue("@alisfiyati", double.Parse(AlışFiyatıtxt.Text));
            komut.Parameters.AddWithValue("@satisfiyati", double.Parse(SatışFiyatıtxt.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urun"].Clear();
            ürünlistele();
            
            MessageBox.Show("Güncelleme yapıldı.");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (BarkodNotxt.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update urun set kategori=@kategori,marka=@marka,where barkodno=@barkodno", baglanti);
                komut.Parameters.AddWithValue("@barkodno", BarkodNotxt.Text);
                komut.Parameters.AddWithValue("@kategori", comboKategori.Text);
                komut.Parameters.AddWithValue("@miktari", comboMarka.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                daset.Tables["urun"].Clear();
                ürünlistele();

                MessageBox.Show("Güncelleme yapıldı.");
                
            
            }
            else
            {
                MessageBox.Show("Barkod no boş bırakılamaz.");
            }

            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        

        private void Ürün_Listele_Load(object sender, EventArgs e)
        {

        }

        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            baglanti.Open();
            SqlDataAdapter adptr = new SqlDataAdapter("select *from urun where barkodno like '%" + txtBarkodNoAra.Text + "%'", baglanti);
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }

        private void comboKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboMarka.Items.Clear();
            comboMarka.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select kategori,marka from markabilgileri where kategori='" + comboKategori.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboMarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from urun where barkodno='" + dataGridView2.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["urun"].Clear();
            ürünlistele();
            ÜrünListele();
            MessageBox.Show("Kayıt silindi.");
        }
    }
}