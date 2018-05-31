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
    public partial class devamsizlikBilgi : Form
    {
        public int ogrenci;
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public devamsizlikBilgi()
        {
            InitializeComponent();
        }

        private void devamsizlikBilgi_Load(object sender, EventArgs e)
        {
            ogrenci o = (from x in bs.ogrencis where x.numara == ogrenci select x).FirstOrDefault();
            label1.Text = o.numara.ToString();
            label2.Text = o.ad;
            label3.Text = o.soyad;
            label4.Text = o.sinif.ToString();

            var dev = (from x in bs.devamsizliks where x.ogrNo == ogrenci select new { DersKodu = x.ders_kodu, Devamsizlik = x.devamsiz }).ToList();

            dataGridView1.DataSource = dev;
        }
    }
}
