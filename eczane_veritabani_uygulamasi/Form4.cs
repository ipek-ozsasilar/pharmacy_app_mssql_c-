using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace eczane_veritabani_uygulamasi
{
    public partial class Form4 : Form

    {
 
        private List<String> isimListe;
        private List<String> ucretListe;
        List<int> counter;

        public Form4(List<String> isimListe,List<String> ucretListe, List<int> counter)
        {
            InitializeComponent();
            this.isimListe = isimListe;
            this.ucretListe = ucretListe;
            this.counter = counter;
    
   
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //listview kullanarak gelen lıstelerı ıtem olarak lıstvıewe yazdırıyoruz
            //ılac adı ucretı ve toplam tutarı olarak yazdırıyoruz lıstvıewe sepet formu yapıyoruz
            listView1.View = View.Details;
            listView1.Columns.Add("ilaç adı", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Ücret", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Tutar", 150, HorizontalAlignment.Left);
            // Örnek ilaç listesi
            decimal toplam=0;

            //her seferınde lısteyı dolasıp ıtemları alıp lıstvıewe eklıyor
            for (int i = 0; i < isimListe.Count; i++)
            {
                // Yeni bir ListViewItem oluştur
                ListViewItem item = new ListViewItem(isimListe[i]); 

                // Ücret ve tutar sütunlarını ekle
                item.SubItems.Add($"{ucretListe[i]} x {counter[i]} TL");
                item.SubItems.Add($"{Convert.ToDecimal(ucretListe[i]) * counter[i]} TL"); // Örnek tutar (miktar: 1)

                // ListView'e öğeyi ekle
                listView1.Items.Add(item);

               toplam+= Convert.ToDecimal(ucretListe[i]) *counter[i];
                

            }
            label3.Text = toplam.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
          
        }
        
        
        private void button12_Click(object sender, EventArgs e)
        {
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
         
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ardından alınan urunlerı,sayısını ve tutarını odeme adımı ıcın odeme formuna gonderıyoruz
            Form6 f6 = new Form6(Convert.ToDecimal(label3.Text),isimListe,counter);
            f6.Show();
        }
    }
}
