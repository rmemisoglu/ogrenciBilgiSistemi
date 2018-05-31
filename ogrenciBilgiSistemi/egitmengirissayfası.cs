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
    public partial class egitmengirissayfası : Form
    {
        public string egkodu;
        public egitmengirissayfası()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            egitmenGiris eg = new egitmenGiris();
            eg.egkoda = textBox1.Text;
            this.Hide();
            eg.Show();
        }
    }
}
