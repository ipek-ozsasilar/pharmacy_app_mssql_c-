using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eczane_veritabani_uygulamasi
{
    public partial class Form6 : Form
    {
        decimal toplamTutar;
        private List<String> isimListe;
        List<int> counter;
        public Form6(decimal toplamTutar,List<String> isimListe, List<int> counter)
        {
            InitializeComponent();
            this.toplamTutar = toplamTutar;
            this.isimListe = isimListe;
            this.counter = counter;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //kredı kartı ve cvv ye bellı uzunluk kısıtlamaları getırıyoruz
            textBox2.MaxLength = numberConstant.cardLenght;
            textBox3.MaxLength = numberConstant.cvvLenght;
            label6.Text = toplamTutar.ToString();        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Form1.numberContains(textBox2);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Form1.numberContains(textBox3);
        }

        //bu fonksıyon ıcıne gonderdıgımız datetıme verısının : ozel karakterlerını - ıle degıstırmeyı saglıyor
        static public DateTime DateTimeConverter(DateTime dt)
        {
 

            //Tarihi "yyyy-MM-dd" formatına çeviriyoruz
            String formattedDate = dt.ToString("yyyy-MM-dd");

            //Formatlanmış string'i tekrar DateTime türüne dönüştürüyoruz
            DateTime finalDate = DateTime.ParseExact(formattedDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return finalDate;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            connect.baglanti.Open();
            //odemeyı tamamla butonuna bastıktan sonra
            //yazılan odeme bılgılerını sorgulayacak ve verıtabanında varsa odeme ıslemını tamamlayacak yoksa kart bılgılerını dogru gırmeını ısteyecek
            SqlCommand odemeSorgu = new SqlCommand("select * from odemeBilgileri where kart_sahip_ad=@ad and kart_no=@no and son_kullanma_tarihi=@tarih and cvv=@cvv ", connect.baglanti);
            odemeSorgu.Parameters.AddWithValue("@ad", textBox1.Text);
            odemeSorgu.Parameters.AddWithValue("@no", textBox2.Text);
            DateTime finalDate = Form6.DateTimeConverter(dateTimePicker1.Value);
            odemeSorgu.Parameters.AddWithValue("@tarih", finalDate);
            odemeSorgu.Parameters.AddWithValue("@cvv", textBox3.Text);
            SqlDataReader reader = odemeSorgu.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                String tc = Form1.getTc();

              
                    for (int i = 0; i < isimListe.Count; i++)
                    {
                    String isim = isimListe[i].Trim();
                    int adet= counter[i];
                    //her seferınde lıstedekı elemanları gezıp ısımlerıne gore ıdlerını bulacak
                    SqlCommand ilacInformations = new SqlCommand("select ilac_id from ilac where ilac_ad=@listeIsim", connect.baglanti);
                        ilacInformations.Parameters.AddWithValue("@listeIsim", isim);
                        SqlDataReader idReader = ilacInformations.ExecuteReader();
                        if (idReader.Read())
                        {
                            
                            int ilac_id = Int32.Parse(idReader["ilac_id"].ToString());
                            idReader.Close();
                        //ardından odeme bılglerı dogru ıse satın alma gerceklesecek ve satın alma tablosuna satın alam bılgısı eklenecek
                        //ve satın alınan mıktar mevcut stoktan yanı stok tablosundan dusmesı gereklı 
                        //bunun ıcınde alınan mıktarı stok tablosundan dusmesı ıcın bır trıggerı tetıkleyecek
                        //trigger 4(trg_satinAlInsert)
                        SqlCommand satinAlEkleme = new SqlCommand("insert into ilacSatinAl (kullanici_id,ilac_id,ilac_ad,alinma_tarihi,miktar) values (@tc,@id,@listeIsim,@date,@miktar)", connect.baglanti);
                            satinAlEkleme.Parameters.AddWithValue("@id", ilac_id);
                            DateTime date = DateTime.Now;
                            satinAlEkleme.Parameters.AddWithValue("@miktar", adet);
                            satinAlEkleme.Parameters.AddWithValue("@date", date);
                            satinAlEkleme.Parameters.AddWithValue("@listeIsim", isim);
                            satinAlEkleme.Parameters.AddWithValue("@tc", tc);
                           satinAlEkleme.ExecuteNonQuery();
                        
                    

                    }




                       
                }


               
                connect.baglanti.Close();
                Form7 f7 = new Form7();
                f7.Show();


            } 
              
            
            else{
                 MessageBox.Show("Lütfen geçerli bir kart giriniz");
                connect.baglanti.Close();
            }
            
        }
    }
}
