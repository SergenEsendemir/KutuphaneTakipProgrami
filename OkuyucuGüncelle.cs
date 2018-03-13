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
    public partial class OkuyucuGüncelle : Form
    {
        public OkuyucuGüncelle()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KayıtGüncelle kg = new KayıtGüncelle();
            this.Close();
            kg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa fm1 = new Anasayfa();
            this.Close();
            fm1.Show();
        }
        string Baglanti = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=2003veri.mdb";
        private void OkuyucuGüncelle_Load(object sender, EventArgs e)
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

            textBox6.DataBindings.Add("text", bindingSource1, "TCKimlik");
            textBox2.DataBindings.Add("text", bindingSource1, "Adi");
            textBox3.DataBindings.Add("text", bindingSource1, "Soyadi");
            comboBox2.DataBindings.Add("text", bindingSource1, "Cinsiyet");
            textBox4.DataBindings.Add("text", bindingSource1, "Sinif");
            dateTimePicker1.DataBindings.Add("text", bindingSource1, "DogumTarihi");
            textBox5.DataBindings.Add("text", bindingSource1, "CepTelefon");

        }
        private void button3_Click(object sender, EventArgs e)
        {
            string tc = textBox6.Text;
            string adi = textBox2.Text;
            string soyadi = textBox3.Text;
            string cinsiyet = comboBox2.Text;
            string sinif = textBox4.Text;
            string tel = textBox5.Text;
            DateTime dt = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            String zaman = dt.ToString("yyyy-MM-dd");
            DialogResult sonuc;
            sonuc = MessageBox.Show("Güncellemek İstiyor musunuz..", "Uyarı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                string Sorgu = String.Format("UPDATE Ogrenci Set Adi='{0}',Soyadi='{1}',Cinsiyet='{2}',Sinif='{3}',DogumTarihi='{4}',CepTelefon='{5}' WHERE TCKimlik='{6}'", adi, soyadi, cinsiyet, sinif, zaman, tel, tc);
                OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                DataTable YeniTablo = new DataTable();
                YeniVeriAl.Fill(YeniTablo);
                DataSet YeniAl = new DataSet();
                YeniAl.Tables.Add(YeniTablo);
                dataGridView1.DataSource = bindingSource1;
                MessageBox.Show("Öğrenci Başarıyla Güncellenmiştir...");
                OkuyucuGüncelle og = new OkuyucuGüncelle();
                this.Close();
                og.Show();
            }
            else if (sonuc == DialogResult.No)
            {
                this.Show();
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
            }
        }
    }
}
