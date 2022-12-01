using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace toptnacitakipson
{
  
    class Kullanıcı_Formu
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-ELT3SDS;Initial Catalog=Kullanıcı_Girişi;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;
        Anasayfa aç = new Anasayfa();


        public SqlDataReader kullanıcı(TextBox kullanıcıadı,TextBox şifre)
        {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select *from tbl_Kullanici where kullanıcıadı='"+kullanıcıadı.Text+"'";
            read = komut.ExecuteReader();
            if(read.Read()==true)
            {
                if(şifre.Text == read["şifre"].ToString())
                {
                    MessageBox.Show("Giriş Başarılı...","ARS GRUP");
                    aç.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Şifre Hatalı.");
                }
                
            }
            else
            {
                MessageBox.Show("Bilgilerinizi kontrol ediniz.");
            }
            baglanti.Close();
            return read;
        }
        public void yenikullanıcı(TextBox adsoyad, TextBox kullanıcıadı, TextBox şifre, TextBox şifretekrar, GroupBox soru, TextBox cevap, GroupBox grup)
        {
            if (şifre.Text == şifretekrar.Text)
            {
                baglanti.Open();
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "insert into tbl_kullanici values('" + adsoyad.Text + "','" + kullanıcıadı.Text + "','" + şifre.Text + "','" + soru.Text + "','" + cevap.Text + "')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Üye Eklendi.");
                foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";
            }
            else
            {
                MessageBox.Show("Parolalar eşleşmiyor.");
            }
        }
            public void şifremiunuttum(TextBox adsoyad,TextBox kullanıcıadı,TextBox şifre,TextBox şifretekrar,TextBox soru,TextBox cevap,GroupBox grup )
            {
            if (şifre.Text == şifretekrar.Text)
            {
                baglanti.Open();
                komut = new SqlCommand("select *from tbl_kullanici where kullanıcıadı='" + kullanıcıadı.Text + "'", baglanti);
                read = komut.ExecuteReader();
                if (read.Read() == true)
                {
                    if (soru.Text == read["soru"].ToString() && cevap.Text == read["cevap"].ToString())
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut = new SqlCommand("update tbl_kullanici set adsoyad='"+adsoyad.Text+"',şifre='"+şifre.Text+"'where kullanıcıadı='"+kullanıcıadı.Text+"'",baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Parola güncellendi.");
                        foreach (Control item in grup.Controls) if (item is TextBox) item.Text = "";


                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı hariç diğer bilgileri kontrol ediniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Bilgileri kontrol ediniz.");

                }
                baglanti.Close();
            }
            
            else
            {
                MessageBox.Show("Parolalar eşleşmiyor.");
            }
        }
        }
    }

