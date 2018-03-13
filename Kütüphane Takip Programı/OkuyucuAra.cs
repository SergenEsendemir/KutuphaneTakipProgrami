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
    public partial class OkuyucuAra : Form
    {
        public OkuyucuAra()
        {
            InitializeComponent();
        }
        string Baglanti = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=2003veri.mdb";
        private void OkuyucuAra_Load(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM Ogrenci";
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

            textBox11.DataBindings.Add("text", bindingSource1, "TCKimlik");
            textBox10.DataBindings.Add("text", bindingSource1, "Adi");
            textBox9.DataBindings.Add("text", bindingSource1, "Soyadi");
            textBox13.DataBindings.Add("text", bindingSource1, "Cinsiyet");
            textBox8.DataBindings.Add("text", bindingSource1, "Sinif");
            dateTimePicker1.DataBindings.Add("text", bindingSource1, "DogumTarihi");
            textBox7.DataBindings.Add("text", bindingSource1, "CepTelefon");

            string Sorgu2 = "SELECT * FROM OkuyucuSorgulama WHERE TCKimlik='" + textBox11.Text + "'";
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
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
            textBox12.Visible = false;
            textBox15.Visible = false;
            textBox14.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "Adı:";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM Ogrenci WHERE Adi like'" + textBox1.Text + "%'";
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox12.Visible = true;
            textBox12.Focus();
            textBox1.Visible = false;
            textBox15.Visible = false;
            textBox14.Visible = false;
            comboBox1.Visible = false;
            label1.Text = "TC Kimlik :";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM Ogrenci WHERE TCKimlik like'" + textBox12.Text + "%'";
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
            textBox12.Visible = false;
            textBox1.Visible = false;
            textBox14.Visible = false;
            comboBox1.Visible = false;
            textBox15.Visible = true;
            textBox15.Focus();
            label1.Text = "Soyadı :";
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM Ogrenci WHERE Soyadi like'" + textBox15.Text + "%'";
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
            textBox12.Visible = false;
            textBox15.Visible = false;
            textBox14.Visible = false;
            comboBox1.Visible = true;
            comboBox1.Focus();
            label1.Text = "Cinsiyeti :";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM Ogrenci WHERE Cinsiyet like'" + comboBox1.Text + "%'";
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
            textBox12.Visible = false;
            textBox15.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            textBox14.Visible = true;
            textBox14.Focus();
            textBox14.MaxLength = 5;
            label1.Text = "Sınıf :";
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM Ogrenci WHERE Sinif like'" + textBox14.Text + "%'";
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
        private void button2_Click(object sender, EventArgs e)
        {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Öğrenci Silinsin mi?", "Uyarı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    string Sorgu = string.Format("DELETE FROM Ogrenci WHERE Adi='" + textBox10.Text + "'");
                    OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                    OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                    DataTable YeniTablo = new DataTable();
                    YeniTablo.Clear();
                    dataGridView1.Refresh();
                    YeniVeriAl.Fill(YeniTablo);
                    DataSet YeniAl = new DataSet();
                    YeniAl.Tables.Add(YeniTablo);
                    MessageBox.Show("Öğrenci Başarıyla Silinmiştir.");
                    OkuyucuAra oa = new OkuyucuAra();
                    this.Close();
                    oa.Show();
                }
                else if (sonuc == DialogResult.No)
                {
                    this.Show();
                }
        }

        private void OkuyucuAra_MouseMove(object sender, MouseEventArgs e)
        {
            textBox12.Focus();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Sorgu2 = "SELECT * FROM OkuyucuSorgulama WHERE TCKimlik='" + textBox11.Text + "'";
            OleDbConnection YeniBaglanti2 = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl2 = new OleDbDataAdapter(Sorgu2, YeniBaglanti2);
            DataTable YeniTablo2 = new DataTable();
            YeniVeriAl2.Fill(YeniTablo2);
            DataSet YeniAl2 = new DataSet();
            YeniAl2.Tables.Add(YeniTablo2);
            bindingSource2.DataSource = YeniAl2;
            bindingSource2.DataMember = YeniAl2.Tables[0].TableName;
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.AllowUserToAddRows = false;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }
    }
}
