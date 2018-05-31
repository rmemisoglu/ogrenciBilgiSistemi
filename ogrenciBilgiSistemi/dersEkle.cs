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
    public partial class dersEkle : Form
    {
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public dersEkle()
        {
            InitializeComponent();
        }

        private void dersEkle_Load(object sender, EventArgs e)
        {
            try
            {
                panel3.Hide();
                panel1.Hide();
                panel2.Hide();

                var egitmenler = (from x in bs.egitmen select new { x.egitmen_kodu, x.ad, x.soyad }).ToList();
                string[] dizi = new string[egitmenler.Count];

                for (int i = 0; i < egitmenler.Count; i++)
                {
                    string s = egitmenler[i].egitmen_kodu + "," + egitmenler[i].ad + " " + egitmenler[i].soyad;
                    dizi[i] = s;
                }

                var dersler = (from x in bs.ders select new {x.ders_kodu,x.ders_adi }).ToList();
                string[] dizi2 = new string[dersler.Count];

                for(int i = 0; i < dizi2.Length; i++)
                {
                    string s = dersler[i].ders_kodu + "," + dersler[i].ders_adi;
                    dizi2[i] = s;
                }
                comboBox1.DataSource = dizi;
                comboBox2.DataSource = dizi;
                
                comboBox4.DataSource = dizi2;
                comboBox3.DataSource = dizi2;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            //StreamReader sr = new StreamReader("bilgisayar.txt");


            //while (!sr.EndOfStream)
            //{
            //    string[] dr = sr.ReadLine().Split(',');
            //    der d = new der();
            //    d.ders_kodu =Convert.ToInt32(dr[0]);
            //    d.ders_adi = dr[1];
            //    d.kredi = Convert.ToInt32(dr[2]);
            //    d.sinif = Convert.ToInt32(dr[3]);
            //    int ekod = Convert.ToInt32(dr[4]);
            //    int eid = (from x in bs.egitmen where x.egitmen_kodu == ekod select x.Id).FirstOrDefault();
            //    d.egitmen_id = eid;
            //    bs.ders.Add(d);
            //    bs.SaveChanges();
            //}
            //MessageBox.Show("Başarılı");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                der d = new der();
                d.ders_kodu = Convert.ToInt32(textBox1.Text);
                d.ders_adi = textBox2.Text;
                d.kredi = Convert.ToInt32(textBox3.Text);
                d.sinif = Convert.ToInt32(textBox4.Text);
                string[] dizi = comboBox1.SelectedItem.ToString().Split(',');
                int ekod = Convert.ToInt32(dizi[0]);
                int eid = (from x in bs.egitmen where x.egitmen_kodu == ekod select x.Id).FirstOrDefault();
                d.egitmen_id = eid;
                bs.ders.Add(d);
                bs.SaveChanges();
                MessageBox.Show("Başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel1.Hide();
            panel2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] dd = comboBox4.SelectedItem.ToString().Split(',');
                int derskod = Convert.ToInt32(dd[0]);
                der d = (from x in bs.ders where x.ders_kodu == derskod select x).FirstOrDefault();
                d.ders_kodu = Convert.ToInt32(textBox5.Text);
                d.ders_adi = textBox6.Text;
                d.kredi = Convert.ToInt32(textBox7.Text);
                d.sinif = Convert.ToInt32(textBox8.Text);
                string[] dizi = comboBox2.SelectedItem.ToString().Split(',');
                int ekod = Convert.ToInt32(dizi[0]);
                int eid = (from x in bs.egitmen where x.egitmen_kodu == ekod select x.Id).FirstOrDefault();
                d.egitmen_id = eid;
                bs.SaveChanges();
                MessageBox.Show("Başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] d = comboBox4.SelectedItem.ToString().Split(',');
            int derskod = Convert.ToInt32(d[0]);
            der dersBilgi = (from x in bs.ders where x.ders_kodu == derskod select x).FirstOrDefault();
            textBox5.Text = dersBilgi.ders_kodu.ToString();
            textBox6.Text = dersBilgi.ders_adi;
            textBox7.Text = dersBilgi.kredi.ToString();
            textBox8.Text = dersBilgi.sinif.ToString();

            int index = 0;
            var ekod = (from x in bs.egitmen where x.Id == dersBilgi.egitmen_id select x.egitmen_kodu).FirstOrDefault();
            for(int i = 0; i < comboBox2.Items.Count; i++)
            {
                if (comboBox2.Items[i].ToString().Contains(ekod.ToString()))
                {
                    index = i;
                }
            }
            comboBox2.SelectedIndex = index;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string[] d = comboBox4.SelectedItem.ToString().Split(',');
                int derskod = Convert.ToInt32(d[0]);
                der dersBilgi = (from x in bs.ders where x.ders_kodu == derskod select x).FirstOrDefault();
                bs.ders.Remove(dersBilgi);
                bs.SaveChanges();
                MessageBox.Show("basarılı");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
