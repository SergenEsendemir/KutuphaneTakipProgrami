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
    public partial class KitapGüncelle : Form
    {
        public KitapGüncelle()
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
        private void KitapGüncelle_Load(object sender, EventArgs e)
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

            textBox6.DataBindings.Add("text", bindingSource1, "Barkod");
            textBox2.DataBindings.Add("text", bindingSource1, "KitapAdi");
            textBox3.DataBindings.Add("text", bindingSource1, "YazarAdi");
            textBox14.DataBindings.Add("text", bindingSource1, "YayinEvi");
            textBox4.DataBindings.Add("text", bindingSource1, "KitapSayfaSayisi");
            textBox5.DataBindings.Add("text", bindingSource1, "KitapTürü");
        }

        private void button1_Click(object sender, EventArgs e)
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

            textBox6.DataBindings.Add("text", bindingSource1, "Barkod");
            textBox2.DataBindings.Add("text", bindingSource1, "KitapAdi");
            textBox3.DataBindings.Add("text", bindingSource1, "YazarAdi");
            textBox14.DataBindings.Add("text", bindingSource1, "YayinEvi");
            textBox4.DataBindings.Add("text", bindingSource1, "KitapSayfaSayisi");
            textBox5.DataBindings.Add("text", bindingSource1, "KitapTürü");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string barkod = textBox6.Text;
            string kadi = textBox2.Text;
            string yadi = textBox3.Text;
            string yayinevi = textBox14.Text;
            string ssayisi = textBox4.Text;
            string tür = textBox5.Text;
            DialogResult sonuc;
            sonuc = MessageBox.Show("Güncellemek İstiyor musunuz..", "Uyarı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                string Sorgu = String.Format("UPDATE KitapBilgisi Set KitapAdi='{0}',YazarAdi='{1}',YayinEvi='{2}',KitapSayfaSayisi='{3}',KitapTürü='{4}' WHERE Barkod='{5}'", kadi,yadi,yayinevi,ssayisi,tür,barkod);
                OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                DataTable YeniTablo = new DataTable();
                YeniVeriAl.Fill(YeniTablo);
                DataSet YeniAl = new DataSet();
                YeniAl.Tables.Add(YeniTablo);
                dataGridView1.DataSource = bindingSource1;
                MessageBox.Show("Kitap Başarıyla Güncellenmiştir...");
                KitapGüncelle kg = new KitapGüncelle();
                this.Close();
                kg.Show();
            }
            else if (sonuc == DialogResult.No)
            {
                this.Show();
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
            }
        }
    }
}
