using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toptnacitakipson
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SatışListele listele = new SatışListele();
            listele.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            müşterilistele listele = new müşterilistele();
            listele.ShowDialog();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            deneme listele = new deneme();
            listele.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ÜrünEkle ekle = new ÜrünEkle();
            ekle.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Kategori kategori = new Kategori();
            kategori.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MüşteriEkle ekle = new MüşteriEkle();
            ekle.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form1 aç = new Form1();
            aç.ShowDialog();
            
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Kar_zarar ac = new Kar_zarar();
            ac.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
