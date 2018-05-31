using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ogrenciBilgiSistemi
{
    public partial class dersSecim : Form
    {
        ArrayList dizi = new ArrayList();
        public int ogrenci;
        bilgiSistemiEntities bs = new bilgiSistemiEntities();
        public dersSecim()
        {
            InitializeComponent();
        }

        private void dersSecim_Load(object sender, EventArgs e)
        {
            var dersler = (from x in bs.ders select x).ToList();
            
            foreach( var i in dersler)
            {
                string s = i.ders_kodu + "," + i.ders_adi + "," + i.kredi +
                    "," + i.sinif;
                dizi.Add(s);
            }
            comboBox1.DataSource = dizi;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!listBox1.Items.Contains(comboBox1.SelectedItem))
            {
                listBox1.Items.Add(comboBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("var");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            alınandersler a = new alınandersler();
            var kontrol = (from x in bs.alınandersler where x.ogrNo == ogrenci select x.ders_kodu).ToList();
            foreach(var i in listBox1.Items)
            {
                string[] dkod = i.ToString().Split(',');
                if (!kontrol.Contains(Convert.ToInt32(dkod[0]))){
                    a.ders_kodu = Convert.ToInt32(dkod[0]);
                    a.ogrNo = ogrenci;
                    bs.alınandersler.Add(a);
                    bs.SaveChanges();
                    MessageBox.Show("basarı");
                }
               
            }
        }
    }
}
