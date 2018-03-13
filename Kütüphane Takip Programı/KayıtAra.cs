using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class KayıtAra : Form
    {
        public KayıtAra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OkuyucuAra oa = new OkuyucuAra();
            this.Close();
            oa.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitap_Arama ka = new Kitap_Arama();
            this.Close();
            ka.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa fm1 = new Anasayfa();
            this.Close();
            fm1.Show();
        }

        private void KayıtAra_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Yellow;
            button2.ForeColor = Color.Yellow;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Lime;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.Lime;
        }
    }
}
