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
    public partial class EmanetKitap : Form
    {
        public EmanetKitap()
        {
            InitializeComponent();
        }
        string Baglanti = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=2003veri.mdb";
        private void EmanetKitap_Load(object sender, EventArgs e)
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

            dateTimePicker2.Text = DateTime.Now.ToShortDateString();

            string Sorgu2 = "SELECT * FROM KitapBilgisi";
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

            string Sorgu3 = string.Format("SELECT * FROM KitapTeslimSorgulama WHERE VerisTarihi IS NULL AND HasarDurumu IS NULL");
            OleDbConnection YeniBaglanti3 = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl3 = new OleDbDataAdapter(Sorgu3, YeniBaglanti3);
            DataTable YeniTablo3 = new DataTable();
            YeniVeriAl3.Fill(YeniTablo3);
            DataSet YeniAl3 = new DataSet();
            YeniAl3.Tables.Add(YeniTablo3);
            bindingSource3.DataSource = YeniAl3;
            bindingSource3.DataMember = YeniAl3.Tables[0].TableName;
            dataGridView3.DataSource = bindingSource3;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.Columns[6].Visible = false;
            dataGridView3.Columns[7].Visible = false;

            textBox1.DataBindings.Add("text", bindingSource1, "TCKimlik");
            textBox2.DataBindings.Add("text", bindingSource1, "Adi");
            textBox3.DataBindings.Add("text", bindingSource1, "Soyadi");
            textBox6.DataBindings.Add("text", bindingSource2, "Barkod");
            textBox5.DataBindings.Add("text", bindingSource2, "KitapAdi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Sorgu3 = string.Format("SELECT * FROM KitapTeslimSorgulama WHERE VerisTarihi IS NULL AND HasarDurumu IS NULL");
            OleDbConnection YeniBaglanti3 = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl3 = new OleDbDataAdapter(Sorgu3, YeniBaglanti3);
            DataTable YeniTablo3 = new DataTable();
            YeniVeriAl3.Fill(YeniTablo3);
            DataSet YeniAl3 = new DataSet();
            YeniAl3.Tables.Add(YeniTablo3);
            bindingSource3.DataSource = YeniAl3;
            bindingSource3.DataMember = YeniAl3.Tables[0].TableName;
            dataGridView3.DataSource = bindingSource3;
            dataGridView3.AllowUserToAddRows = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa a = new Anasayfa();
            this.Close();
            a.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tc = textBox1.Text;
            string barkod = textBox6.Text;
            DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Value.ToString());
            String alıs = dt2.ToString("dd.MM.yyyy");
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kitap Emanet Edilsin mi?", "Uyarı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                string Sorgu = string.Format("INSERT INTO KitapTeslimBilgisi(TCKimlik,Barkod,AlisTarihi) VALUES ('{0}','{1}','{2}')", tc,barkod,alıs);
                OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                DataTable YeniTablo = new DataTable();
                YeniVeriAl.Fill(YeniTablo);
                DataSet YeniAl = new DataSet();
                YeniAl.Tables.Add(YeniTablo);
                MessageBox.Show("Kitap Başarıyla Emanet Edilmiştir..");
                EmanetKitap ek = new EmanetKitap();
                this.Close();
                ek.Show();
            }
            else if (sonuc == DialogResult.No)
            {
                this.Show();
            }
        }
    }
}
