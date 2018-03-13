using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class OgrenciEkle : Form
    {
        public OgrenciEkle()
        {
            InitializeComponent();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Anasayfa fm1 = new Anasayfa();
            this.Close();
            fm1.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            KayıtEkleme fm2 = new KayıtEkleme();
            this.Close();
            fm2.Show();
        }
        string Baglanti = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=2003veri.mdb";
        private void button1_Click(object sender, EventArgs e)
        {
            string tc = textBox1.Text;
            string adi = textBox2.Text;
            string soyadi = textBox3.Text;
            string cinsiyet = comboBox1.Text;
            string sinif = textBox4.Text;
            string tel = textBox5.Text;
            DateTime dt = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            String zaman = dt.ToString("yyyy-MM-dd");
            if (textBox1.Text != "" && textBox1.Text.Length==11 && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (textBox4.Text.Length>=2 && textBox4.Text.Length<=4) && textBox5.Text != "" && textBox5.Text.Length==11 && comboBox1.Text != "")
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Öğrenci Kaydedilsin mi?", "Uyarı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    string Sorgu = string.Format("INSERT INTO Ogrenci(TCKimlik,Adi,Soyadi,Cinsiyet,Sinif,CepTelefon,DogumTarihi) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", tc.ToString(), adi, soyadi, cinsiyet, sinif, tel.ToString(), zaman);
                    OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                    OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                    DataTable YeniTablo = new DataTable();
                    YeniVeriAl.Fill(YeniTablo);
                    DataSet YeniAl = new DataSet();
                    YeniAl.Tables.Add(YeniTablo);
                    bindingSource1.DataSource = YeniAl;
                    bindingSource1.DataMember = YeniAl.Tables[0].TableName;
                    MessageBox.Show("Öğrenci Başarıyla Kaydedilmiştir..");
                    KayıtEkleme ke = new KayıtEkleme();
                    this.Close();
                    ke.Show();
                }
                else if (sonuc == DialogResult.No)
                {
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Lütfen * yazan yerleri düzgün bir şekilde doldurunuz...");
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.Text = dateTimePicker1.MaxDate.ToString();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    }
}
