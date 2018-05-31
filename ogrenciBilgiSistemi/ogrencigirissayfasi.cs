using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ogrenciBilgiSistemi
{
    public partial class ogrencigirissayfasi : Form
    {
        public ogrencigirissayfasi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogrenciGiris og = new ogrenciGiris();
            og.ogrencino = textBox1.Text;
            this.Hide();
            og.Show();
        }
    }
}
