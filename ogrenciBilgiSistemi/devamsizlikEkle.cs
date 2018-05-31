using System;
using System.Collections;
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
    public partial class devamsizlikEkle : Form
    {
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public devamsizlikEkle()
        {
            InitializeComponent();
        }

        private void devamsizlikEkle_Load(object sender, EventArgs e)
        {
            try
            {
                panel2.Hide();
                panel1.Hide();

                //var dersler = (from x in bs.ders select new { x.ders_kodu, x.ders_adi, x.kredi, x.sinif }).ToList();
                //string[] dizi = new string[dersler.Count];

                //for (int i = 0; i < dersler.Count; i++)
                //{
                //    string s = dersler[i].ders_kodu + "," + dersler[i].ders_adi + "," + dersler[i].kredi + "," + dersler[i].sinif;
                //    dizi[i] = s;
                //}
                //comboBox1.DataSource = dizi;
                //comboBox2.DataSource = dizi;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                devamsizlik d = new devamsizlik();
                d.ogrNo = Convert.ToInt32(textBox1.Text);
                d.devamsiz = Convert.ToInt32(textBox2.Text);
                string[] dd = comboBox1.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(dd[0]);
                d.ders_kodu = dersk;
                bs.devamsizliks.Add(d);
                bs.SaveChanges();
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
                string[] dd = comboBox1.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(dd[0]);
                int ogrno = Convert.ToInt32(textBox3.Text);
                devamsizlik d = (from x in bs.devamsizliks where x.ogrNo == ogrno && x.ders_kodu == dersk select x).FirstOrDefault();
                d.devamsiz = Convert.ToInt32(textBox4.Text);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                int no = Convert.ToInt32(textBox3.Text);
                var alınan = (from x in bs.alınandersler where x.ogrNo == no select x.ders_kodu).ToList();
                ArrayList dizi = new ArrayList();
                foreach (var j in alınan)
                {
                    var dersler = (from x in bs.ders where x.ders_kodu == j select x.ders_kodu + "," + x.ders_adi + "," + x.kredi + "," + x.sinif).ToList();
                    dizi.AddRange(dersler);
                }
                comboBox2.DataSource = dizi;
                string[] dd = comboBox2.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(dd[0]);
                int ogrno = Convert.ToInt32(textBox3.Text);
                var dev = (from x in bs.devamsizliks where x.ogrNo == ogrno && x.ders_kodu == dersk select x.devamsiz).FirstOrDefault();
                textBox4.Text = dev.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                int no = Convert.ToInt32(textBox1.Text);
                var alınan = (from x in bs.alınandersler where x.ogrNo == no select x.ders_kodu).ToList();
                ArrayList dizi = new ArrayList();
                foreach (var j in alınan)
                {
                    var dersler = (from x in bs.ders where x.ders_kodu == j select x.ders_kodu + "," + x.ders_adi + "," + x.kredi + "," + x.sinif).ToList();
                    dizi.AddRange(dersler);
                }
                comboBox1.DataSource = dizi;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
