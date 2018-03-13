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
    public partial class Kitap_Arama : Form
    {
        public Kitap_Arama()
        {
            InitializeComponent();
        }
        string Baglanti = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=2003veri.mdb";
        private void Kitap_Arama_Load(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapBilgisi";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.AllowUserToAddRows = false;
            

            //seçili kayıt
            textBox12.DataBindings.Add("text", bindingSource1, "Barkod");
            textBox11.DataBindings.Add("text", bindingSource1, "KitapAdi");
            textBox10.DataBindings.Add("text", bindingSource1, "YazarAdi");
            textBox7.DataBindings.Add("text", bindingSource1, "YayinEvi");
            textBox9.DataBindings.Add("text", bindingSource1, "KitapSayfaSayisi");
            textBox8.DataBindings.Add("text", bindingSource1, "KitapTürü");

            string Sorgu2 = "SELECT * FROM KitapSorgulama WHERE Barkod='" + textBox12.Text + "'";
            OleDbConnection YeniBaglanti2 = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl2 = new OleDbDataAdapter(Sorgu2, YeniBaglanti2);
            DataTable YeniTablo2 = new DataTable();
            YeniVeriAl2.Fill(YeniTablo2);
            DataSet YeniAl2 = new DataSet();
            YeniAl2.Tables.Add(YeniTablo2);
            bindingSource2.DataSource = YeniAl2;
            bindingSource2.DataMember = YeniAl2.Tables[0].TableName;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.AllowUserToAddRows = false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa a = new Anasayfa();
            this.Close();
            a.Show();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            KayıtAra ka = new KayıtAra();
            this.Close();
            ka.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Text = "Barkod No :";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapBilgisi WHERE Barkod like'" + textBox1.Text + "%'";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniTablo.Clear();
            dataGridView1.Refresh();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = true;
            textBox2.Focus();
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Text = "Kitap Adı :";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapBilgisi WHERE KitapAdi like'" + textBox2.Text + "%'";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniTablo.Clear();
            dataGridView1.Refresh();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = true;
            textBox3.Focus();
            textBox4.Visible = false;
            textBox5.Visible = false;
            label1.Text = "Yazar Adı :";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapBilgisi WHERE YazarAdi like'" + textBox3.Text + "%'";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniTablo.Clear();
            dataGridView1.Refresh();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = true;
            textBox4.Focus();
            textBox5.Visible = false;
            label1.Text = "Yayın Evi :";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapBilgisi WHERE YayinEvi like'" + textBox4.Text + "%'";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniTablo.Clear();
            dataGridView1.Refresh();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = true;
            textBox5.Focus();
            label1.Text = "Kitap Türü :";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapBilgisi WHERE KitapTürü like'" + textBox5.Text + "%'";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniTablo.Clear();
            dataGridView1.Refresh();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
        }

        private void Kitap_Arama_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kitap Silinsin mi?", "Uyarı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                string Sorgu = string.Format("DELETE FROM KitapBilgisi WHERE Barkod='" + textBox12.Text + "'");
                OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                DataTable YeniTablo = new DataTable();
                YeniTablo.Clear();
                dataGridView1.Refresh();
                YeniVeriAl.Fill(YeniTablo);
                DataSet YeniAl = new DataSet();
                YeniAl.Tables.Add(YeniTablo);
                MessageBox.Show("Kitap Başarıyla Silinmiştir.");
                Kitap_Arama ka = new Kitap_Arama();
                this.Close();
                ka.Show();
            }
            else if (sonuc == DialogResult.No)
            {
                this.Show();
            }
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            string Sorgu2 = "SELECT * FROM KitapSorgulama WHERE Barkod='" + textBox12.Text + "'";
            OleDbConnection YeniBaglanti2 = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl2 = new OleDbDataAdapter(Sorgu2, YeniBaglanti2);
            DataTable YeniTablo2 = new DataTable();
            YeniVeriAl2.Fill(YeniTablo2);
            DataSet YeniAl2 = new DataSet();
            YeniAl2.Tables.Add(YeniTablo2);
            bindingSource2.DataSource = YeniAl2;
            bindingSource2.DataMember = YeniAl2.Tables[0].TableName;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    }
}
