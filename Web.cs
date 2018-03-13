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
    public partial class Web : Form
    {
        public Web()
        {
            InitializeComponent();
        }

        private void Web_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }
    }
}
