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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (textBox1.Text == "admin" && textBox2.Text == "123")
                {
                        Anasayfa a = new Anasayfa();
                        this.Visible = false;
                        a.Show();
                }
                else
                    MessageBox.Show("Girmiş olduğunuz Kullanıcı Adı veya Şifre yanlıştır. Lütfen tekrar deneyiniz.");
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adı veya Şifrenizi Giriniz...");
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Focus();
        }

        private void Giris_Activated(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
