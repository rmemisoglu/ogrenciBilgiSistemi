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
    public partial class ogrenciEkle : Form
    {
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public ogrenciEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ogrenci o = new ogrenci();
                o.numara = Convert.ToInt32(textBox1.Text);
                o.ad = textBox2.Text;
                o.soyad = textBox3.Text;
                o.sinif = Convert.ToInt32(textBox4.Text);
                string[] b = comboBox3.SelectedItem.ToString().Split(',');
                o.bolum = Convert.ToInt32(b[1]);
                bs.ogrencis.Add(o);
                bs.SaveChanges();
                MessageBox.Show("basarili");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string[] d = comboBox1.SelectedItem.ToString().Split(',');
                int numara = Convert.ToInt32(d[0]);
                ogrenci obilgi = (from x in bs.ogrencis where x.numara == numara select x).FirstOrDefault();
                obilgi.numara = Convert.ToInt32(textBox5.Text);
                obilgi.ad = textBox6.Text;
                obilgi.soyad = textBox7.Text;
                obilgi.sinif = Convert.ToInt32(textBox8.Text);
                bs.SaveChanges();
                MessageBox.Show("basarili");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string[] d = comboBox1.SelectedItem.ToString().Split(',');
                int numara = Convert.ToInt32(d[0]);
                ogrenci obilgi = (from x in bs.ogrencis where x.numara == numara select x).FirstOrDefault();
                bs.ogrencis.Remove(obilgi);
                bs.SaveChanges();
                MessageBox.Show("basarili");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ogrenciEkle_Load(object sender, EventArgs e)
        {
            try
            {
                panel1.Hide();
                panel2.Hide();
                panel3.Hide();

                var ogrenciler = (from x in bs.ogrencis select x).ToList();
                string[] dizi = new string[ogrenciler.Count];

                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    string s = ogrenciler[i].numara + "," + ogrenciler[i].ad + " " + ogrenciler[i].soyad;
                    dizi[i] = s;
                }
                comboBox1.DataSource = dizi;
                comboBox2.DataSource = dizi;

                var bolumler = (from x in bs.bolums select x).ToList();
                string[] dizi2 = new string[bolumler.Count];

                for (int i = 0; i < bolumler.Count; i++)
                {
                    string s = bolumler[i].bolum_adi + "," + bolumler[i].bolum_kodu;
                    dizi2[i] = s;
                }
                comboBox3.DataSource = dizi2;            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] d = comboBox1.SelectedItem.ToString().Split(',');
                int numara = Convert.ToInt32(d[0]);
                ogrenci obilgi = (from x in bs.ogrencis where x.numara == numara select x).FirstOrDefault();
                textBox5.Text = obilgi.numara.ToString();
                textBox6.Text = obilgi.ad;
                textBox7.Text = obilgi.soyad;
                textBox8.Text = obilgi.sinif.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void comboUpdate()
        {
            var ogrenciler = (from x in bs.ogrencis select x).ToList();
            string[] dizi = new string[ogrenciler.Count];

            for (int i = 0; i < ogrenciler.Count; i++)
            {
                string s = ogrenciler[i].numara + "," + ogrenciler[i].ad + " " + ogrenciler[i].soyad;
                dizi[i] = s;
            }
            comboBox1.DataSource = dizi;
            comboBox2.DataSource = dizi;
        }
    }
}
