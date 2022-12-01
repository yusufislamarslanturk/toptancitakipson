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
    public partial class admingiriş : Form
    {
        public admingiriş()
        {
            InitializeComponent();
        }

        private void lblkyt_Click(object sender, EventArgs e)
        {
            Kayıtol kayıt = new Kayıtol();
            kayıt.ShowDialog();

        }

        private void admingiriş_MouseEnter(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "")
            {
                txtKullanici.Text = "Kullanıcı Adı";
                txtKullanici.ForeColor = Color.DarkGray;

            }
        }

        private void admingiriş_MouseLeave(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "Kullanıcı Adı")
            {
                txtKullanici.Text = "";
                txtKullanici.ForeColor = Color.DarkGray;

            }
        }

        private void txtParola_MouseLeave(object sender, EventArgs e)
        {
            //if (txtParola.Text == "")
            //{
            //    txtParola.Text = "Parola";
            //    txtParola.ForeColor = Color.DarkGray;
            //    txtParola.UseSystemPasswordChar = false;
            //}
        }

        private void txtParola_Enter(object sender, EventArgs e)
        {
            //if (txtParola.Text == "Parola")
            //{
            //    txtParola.Text = "";
            //    NewMethod();
            //    txtParola.UseSystemPasswordChar = true;


            //}
        }
        private void NewMethod()
        {
            txtParola.ForeColor = Color.DarkGray;
        }

        private void txtKullanici_Enter(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "Kullanıcı Adı")
            {
                txtKullanici.Text = "";
                txtKullanici.ForeColor = Color.DarkGray;

            }
        }

        private void txtKullanici_MouseLeave(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "Kullanıcı Adı")
            {
                txtKullanici.Text = "";
                txtKullanici.ForeColor = Color.DarkGray;

            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Giriş başarılı...");
            Anasayfa ac = new Anasayfa();
            ac.ShowDialog();

        }

        private void admingiriş_Load(object sender, EventArgs e)
        {

        }

        private void lblunuttum_Click(object sender, EventArgs e)
        {
            Şifremi_Unuttum su = new Şifremi_Unuttum();
            su.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kar_zarar acc = new Kar_zarar();
            acc.ShowDialog();
        }

        private void txtKullanici_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParola_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
