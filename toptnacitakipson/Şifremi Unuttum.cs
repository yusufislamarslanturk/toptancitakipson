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
    public partial class Şifremi_Unuttum : Form
    {
        public Şifremi_Unuttum()
        {
            InitializeComponent();
        }
        Kullanıcı_Formu k = new Kullanıcı_Formu();

        private void btnekle_Click(object sender, EventArgs e)
        {
            k.şifremiunuttum(AdSoyadtxt,kullanıcıadıtxt,parolatxt,parolatekrartxt,sorutxt,cevaptxt,groupBox1);
        }
    }
}
