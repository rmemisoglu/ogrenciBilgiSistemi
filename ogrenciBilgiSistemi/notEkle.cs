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
    public partial class notEkle : Form
    {
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public notEkle()
        {
            InitializeComponent();
        }

        private void notEkle_Load(object sender, EventArgs e)
        {
            
            panel1.Hide();
            panel2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = Convert.ToInt32(textBox1.Text);
                string[] d = comboBox1.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(d[0]);

                not n = (from x in bs.nots where x.ogrNo == ogrNo && x.ders_kodu == dersk select x).FirstOrDefault();
                n.vize = Convert.ToInt32(textBox2.Text);
                bs.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = Convert.ToInt32(textBox1.Text);
                string[] d = comboBox1.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(d[0]);

                not n = (from x in bs.nots where x.ogrNo == ogrNo && x.ders_kodu == dersk select x).FirstOrDefault();
                n.final = Convert.ToInt32(textBox3.Text);
                bs.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = Convert.ToInt32(textBox1.Text);
                string[] d = comboBox1.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(d[0]);

                not n = (from x in bs.nots where x.ogrNo == ogrNo && x.ders_kodu == dersk select x).FirstOrDefault();
                n.but = Convert.ToInt32(textBox4.Text);
                bs.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = Convert.ToInt32(textBox5.Text);
                string[] d = comboBox2.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(d[0]);

                not n = new not();
                n.vize = Convert.ToInt32(textBox6.Text);
                n.ders_kodu = dersk;
                n.ogrNo = ogrNo;
                bs.nots.Add(n);
                bs.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = Convert.ToInt32(textBox5.Text);
                string[] d = comboBox2.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(d[0]);

                not n = (from x in bs.nots where x.ogrNo == ogrNo && x.ders_kodu == dersk select x).FirstOrDefault();
                n.final = Convert.ToInt32(textBox7.Text);

                bs.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int ogrNo = Convert.ToInt32(textBox5.Text);
                string[] d = comboBox2.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(d[0]);

                not n = (from x in bs.nots where x.ogrNo == ogrNo && x.ders_kodu == dersk select x).FirstOrDefault();
                n.but = Convert.ToInt32(textBox8.Text);
                bs.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            try
            {

                int no = Convert.ToInt32(textBox5.Text);
                var alınan = (from x in bs.alınandersler where x.ogrNo == no select x.ders_kodu).ToList();
                ArrayList dizi = new ArrayList();
                foreach (var j in alınan)
                {
                    var dersler = (from x in bs.ders where x.ders_kodu == j select x.ders_kodu + "," + x.ders_adi + "," + x.kredi + "," + x.sinif).ToList();
                    dizi.AddRange(dersler);
                }
                comboBox2.DataSource = dizi;
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
                string[] dd = comboBox1.SelectedItem.ToString().Split(',');
                int dersk = Convert.ToInt32(dd[0]);
                int ogrno = Convert.ToInt32(textBox1.Text);
                var notlar = (from x in bs.nots where x.ogrNo == ogrno && x.ders_kodu == dersk select x).FirstOrDefault();
                textBox2.Text = notlar.vize.ToString();
                textBox3.Text = notlar.final.ToString();
                textBox4.Text = notlar.but.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
