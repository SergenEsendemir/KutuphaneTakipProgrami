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
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Text = DateTime.Now.ToLongDateString();
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);
            label1.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = this.Text.Substring(1) + this.Text.Substring(0, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Eminmisiniz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
                Application.Exit();
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            button3.ForeColor = Color.Lime;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            button3.ForeColor = Color.Red;
            button6.ForeColor = Color.Red;
            button7.ForeColor = Color.Red;
            button9.ForeColor = Color.Red;
            button2.ForeColor = Color.Red;
            button5.ForeColor = Color.Red;
            button1.ForeColor = Color.Red;
            button4.ForeColor = Color.Red;
            button8.ForeColor = Color.Red;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            button5.ForeColor = Color.Lime;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.ForeColor = Color.Lime;
            }

        private void button9_MouseMove(object sender, MouseEventArgs e)
        {
            button9.ForeColor = Color.Lime;
        }

        private void button7_MouseMove(object sender, MouseEventArgs e)
        {
            button7.ForeColor = Color.Lime;
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
            button6.ForeColor = Color.Lime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayıtEkleme fm2 = new KayıtEkleme();
            this.Visible = false;
            fm2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KayıtAra ka = new KayıtAra();
            this.Visible = false;
            ka.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProgramHakkında ph = new ProgramHakkında();
            this.Visible = false;
            ph.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProgramcıHakkında pch = new ProgramcıHakkında();
            this.Visible = false;
            pch.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            KitapTeslim kt = new KitapTeslim();
            this.Visible = false;
            kt.Show();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.Lime;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KayıtGüncelle kg = new KayıtGüncelle();
            this.Visible = false;
            kg.Show();
        }

         void timer2_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

         private void button4_Click(object sender, EventArgs e)
         {
             EmanetKitap ek = new EmanetKitap();
             this.Visible = false;
             ek.Show();
         }

         private void button4_MouseMove(object sender, MouseEventArgs e)
         {
             button4.ForeColor = Color.Lime;
         }

         private void button8_Click(object sender, EventArgs e)
         {
             Web wb = new Web();
             wb.Show();
         }

         private void button8_MouseMove(object sender, MouseEventArgs e)
         {
             button8.ForeColor = Color.Lime;
         }
    }
}
