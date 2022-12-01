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
    public partial class Kayıtol : Form
    {
        public Kayıtol()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ELT3SDS;Initial Catalog=Kullanıcı_Girişi;Integrated Security=True");
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Kayıtol_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from sorular", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["soru"].ToString());
                
            }
            baglanti.Close();

        }
        Kullanıcı_Formu k = new Kullanıcı_Formu();
        private void btnekle_Click(object sender, EventArgs e)
        {
           
        }

        private void btnekle_Click_1(object sender, EventArgs e)
        {
            k.yenikullanıcı(AdSoyadtxt, kullanıcıadıtxt, parolatxt, parolatekrartxt, groupBox1, cevaptxt, groupBox1);
        }

        private void sorutxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }
    }
}
