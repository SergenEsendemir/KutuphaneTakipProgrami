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
    public partial class KayıtEkleme : Form
    {
        public KayıtEkleme()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Anasayfa fm1=new Anasayfa();
            this.Close();
            fm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciEkle fm3 = new OgrenciEkle();
            this.Close();
            fm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KitapEkle fm4 = new KitapEkle();
            this.Close();
            fm4.Show();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Green;
        }
        private void KayıtEkleme_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Black;
            button2.ForeColor = Color.Black;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.Green;
        }
    }
}
