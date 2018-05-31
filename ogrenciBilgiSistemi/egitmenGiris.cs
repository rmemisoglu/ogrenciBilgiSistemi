using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ogrenciBilgiSistemi
{
    public partial class egitmenGiris : Form
    {
        public string egkoda;
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public egitmenGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            dersEkle sn = new dersEkle();
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            notEkle sn = new notEkle();
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            egitmenEkle sn = new egitmenEkle();
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            ogrenciEkle sn = new ogrenciEkle();
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            devamsizlikEkle sn = new devamsizlikEkle();
            sn.TopLevel = false;
            panel3.Controls.Add(sn);
            sn.Show();
            sn.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void egitmenGiris_Load(object sender, EventArgs e)
        {
            egitmengirissayfası egs = new egitmengirissayfası();

            int egkod = Convert.ToInt32(egkoda);
            egitman ei = (from x in bs.egitmen where x.egitmen_kodu == egkod select x).FirstOrDefault();
            label1.Text = ei.egitmen_kodu.ToString();
            label2.Text = ei.ad;
            label3.Text = ei.soyad;


            //egitmen
            //StreamReader sr = new StreamReader("egitmen.txt");

            //while (!sr.EndOfStream)
            //{
            //    string[] satir = sr.ReadLine().Split(',');
            //    egitman eg = new egitman();
            //    eg.ad = satir[0];
            //    eg.soyad = satir[1];
            //    eg.egitmen_kodu = Convert.ToInt32(satir[2]);
            //    bs.egitmen.Add(eg);
            //    bs.SaveChanges();
            //}
            //sr.Close();
            //ders
            //StreamReader sr2 = new StreamReader("bilgisayar.txt");

            //while (!sr2.EndOfStream)
            //{
            //    string[] satir = sr2.ReadLine().Split(',');
            //    der dr = new der();
            //    dr.ders_kodu = Convert.ToInt32(satir[0]);
            //    dr.ders_adi = satir[1];
            //    dr.kredi = Convert.ToInt32(satir[2]);
            //    dr.sinif = Convert.ToInt32(satir[3]);
            //    int ekod = Convert.ToInt32(satir[4]);
            //    int eid = (from x in bs.egitmen where x.egitmen_kodu == ekod select x.Id).FirstOrDefault();
            //    dr.egitmen_id = eid;
            //    bs.ders.Add(dr);
            //    bs.SaveChanges();

            //}
            //MessageBox.Show("basaılı");

        }
    }
}
