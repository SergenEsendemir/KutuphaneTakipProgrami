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
    public partial class ProgramHakkında : Form
    {
        public ProgramHakkında()
        {
            InitializeComponent();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            Anasayfa a = new Anasayfa();
            this.Close();
            a.Show();
        }
    }
}
