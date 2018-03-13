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
    public partial class KitapTeslim : Form
    {
        public KitapTeslim()
        {
            InitializeComponent();
        }
        string Baglanti = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=2003veri.mdb";
        private void KitapTeslim_Load(object sender, EventArgs e)
        {
            string Sorgu = "SELECT * FROM KitapTeslimSorgulama WHERE VerisTarihi IS NULL AND HasarDurumu IS NULL";
            OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
            OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
            DataTable YeniTablo = new DataTable();
            YeniVeriAl.Fill(YeniTablo);
            DataSet YeniAl = new DataSet();
            YeniAl.Tables.Add(YeniTablo);
            bindingSource1.DataSource = YeniAl;
            bindingSource1.DataMember = YeniAl.Tables[0].TableName;
            dataGridView1.DataSource = bindingSource1;
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            dateTimePicker2.MaxDate.ToShortDateString();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            

            textBox1.DataBindings.Add("text", bindingSource1, "TCKimlik");
            textBox2.DataBindings.Add("text", bindingSource1, "Adi");
            textBox3.DataBindings.Add("text", bindingSource1, "Soyadi");
            textBox6.DataBindings.Add("text", bindingSource1, "Barkod");
            textBox5.DataBindings.Add("text", bindingSource1, "KitapAdi");
            dateTimePicker2.DataBindings.Add("text", bindingSource1, "AlisTarihi");

            string Sorgu3 ="SELECT * FROM KitapTeslimSorgulama WHERE TCKimlik='"+textBox1.Text+"' AND HasarDurumu IS NOT NULL AND VerisTarihi IS NOT NULL";
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
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[1].Visible = false;
            dataGridView3.Columns[2].Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa a = new Anasayfa();
            this.Close();
            a.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Sorgu3 = "SELECT * FROM KitapTeslimSorgulama WHERE TCKimlik='"+textBox1.Text+"' AND HasarDurumu IS NOT NULL AND VerisTarihi IS NOT NULL";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string tc=textBox1.Text;
            string barkod = textBox6.Text;
            DateTime dt2 = Convert.ToDateTime(dateTimePicker1.Value.ToString());
            String veris = dt2.ToString("dd.MM.yyyy");
            DialogResult sonuc;
            string hasar=comboBox1.Text;
            sonuc = MessageBox.Show("Kitap Teslim Edilsin mi?", "Uyarı", MessageBoxButtons.YesNo);
            if (sonuc == DialogResult.Yes)
            {
                string Sorgu = string.Format("UPDATE KitapTeslimBilgisi Set VerisTarihi='{0}',HasarDurumu='{1}' WHERE TCKimlik='{2}' AND Barkod='{3}'", veris, hasar,tc,barkod);
                OleDbConnection YeniBaglanti = new OleDbConnection(Baglanti);
                OleDbDataAdapter YeniVeriAl = new OleDbDataAdapter(Sorgu, YeniBaglanti);
                DataTable YeniTablo = new DataTable();
                YeniVeriAl.Fill(YeniTablo);
                DataSet YeniAl = new DataSet();
                YeniAl.Tables.Add(YeniTablo);
                MessageBox.Show("Kitap Başarıyla Teslim Edilmiştir..");
                KitapTeslim kt = new KitapTeslim();
                this.Close();
                kt.Show();
            }
            else if (sonuc == DialogResult.No)
            {
                this.Show();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
    }
}
