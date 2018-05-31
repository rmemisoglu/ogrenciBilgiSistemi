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
    public partial class ogrenciGiris : Form
    {
        public string ogrencino;
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public ogrenciGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            dersSecim sn = new dersSecim();
            sn.ogrenci = Convert.ToInt32(ogrencino);
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void ogrenciGiris_Load(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(ogrencino);
            ogrenci o = (from x in bs.ogrencis where x.numara == no select x).FirstOrDefault();
            label1.Text = o.numara.ToString();
            label2.Text = o.ad;
            label3.Text = o.soyad;
            label4.Text = o.sinif.ToString();
            int bkkod = Convert.ToInt32(o.bolum);
            bolum b = (from x in bs.bolums where x.bolum_kodu == bkkod select x).FirstOrDefault();
            label5.Text = b.bolum_adi.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            sınavNot sn = new sınavNot();
            sn.ogrenci = Convert.ToInt32(ogrencino);
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            devamsizlikBilgi sn = new devamsizlikBilgi();
            sn.ogrenci = Convert.ToInt32(ogrencino);
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }
    }
}
