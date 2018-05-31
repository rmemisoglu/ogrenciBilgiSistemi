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
    public partial class egitmenEkle : Form
    {
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public egitmenEkle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                egitman eg = new egitman();
                eg.ad = textBox1.Text;
                eg.soyad = textBox2.Text;
                eg.egitmen_kodu = Convert.ToInt32(textBox3.Text);
                bs.egitmen.Add(eg);
                bs.SaveChanges();
            }
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
            panel2.Show();
            panel1.Hide();
            panel3.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Show();
            panel2.Hide();
            panel1.Hide();
        }

        private void egitmenEkle_Load(object sender, EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            try
            {
                var egitmenler = (from x in bs.egitmen select new { x.egitmen_kodu, x.ad, x.soyad }).ToList();
                string[] dizi = new string[egitmenler.Count];

                for (int i = 0; i < egitmenler.Count; i++)
                {
                    string s = egitmenler[i].egitmen_kodu + "," + egitmenler[i].ad + " " + egitmenler[i].soyad;
                    dizi[i] = s;
                }
                comboBox1.DataSource = dizi;
                comboBox2.DataSource = dizi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] d = comboBox1.SelectedItem.ToString().Split(',');
            int ekod = Convert.ToInt32(d[0]);
            egitman ebilgi = (from x in bs.egitmen where x.egitmen_kodu == ekod select x).FirstOrDefault();
            textBox4.Text = ebilgi.ad;
            textBox5.Text = ebilgi.soyad;
            textBox6.Text = ebilgi.egitmen_kodu.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] d = comboBox1.SelectedItem.ToString().Split(',');
            int ekod = Convert.ToInt32(d[0]);
            egitman ebilgi = (from x in bs.egitmen where x.egitmen_kodu == ekod select x).FirstOrDefault();
            ebilgi.ad = textBox4.Text;
            ebilgi.soyad = textBox5.Text;
            ebilgi.egitmen_kodu = Convert.ToInt32(textBox6.Text);
            bs.SaveChanges();
            MessageBox.Show("basarılı");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string[] d = comboBox1.SelectedItem.ToString().Split(',');
            int ekod = Convert.ToInt32(d[0]);
            egitman ebilgi = (from x in bs.egitmen where x.egitmen_kodu == ekod select x).FirstOrDefault();
            bs.egitmen.Remove(ebilgi);
            bs.SaveChanges();
            MessageBox.Show("basarılı");
        }
    }
}
