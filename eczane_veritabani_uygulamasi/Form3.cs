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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;



namespace eczane_veritabani_uygulamasi
{

    public partial class Form3 : Form
    {
        
        String demoTc;
        char [] kullaniciId;
        //ekranda giris yapan veya kayıt olan kullanıcı adını gorebılmek ıcın ad parametresı aldık
        private string _ad;
        public Form3(String ad, String demoTc)
        {

            InitializeComponent();
            _ad = ad;
            this.demoTc = demoTc;
            //string olarak aldıgımız tcyı char arraye cevırdık
            kullaniciId = demoTc.ToCharArray();

        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'pharmacy_appDataSet11.ilac' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ilacTableAdapter1.Fill(this.pharmacy_appDataSet11.ilac);
            //sayfa yüklenince degılde datagrıdviewe double clıck yapınca bu componentlerın gozukmesını ıstedık
            //o nedenle vısıble false yaptık 
            richTextBox1.Visible = false;
            groupBox1.Visible = false;
            button3.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            label3.Visible = false;
            //kullanıcıya ismi ile hosgeldınız denır
            label1.Text = "Hoşgeldiniz" + " " + _ad;
  
        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        int secilen;
        String id;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //secılen hucrenın ılkını aldı ve onun bulundugu satırın ındexını aldı
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            //satırdakı ılk hucrenın degerını yanı ilac id degerını aldı
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //satırdakı ikinci hucrenın degerını yanı ilac id degerını aldı
            String ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            connect.baglanti.Open();
            //komutlar ıle  fotograf , acıklama ve ılac ısımlerını alarak double clıck yapılan satırdakı
            //ılacın bılgılerını verıtabanında alıp ui da gosterdık
            SqlCommand medicineInformations = new SqlCommand("select photo,aciklama,ilac_ad from ilac where ilac_id=@id", connect.baglanti);
            medicineInformations.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = medicineInformations.ExecuteReader();
            if (reader.Read())
            {
                String link = reader["photo"].ToString();
                if (!string.IsNullOrEmpty(link))
                {
                   
                   
                    button3.Visible = true;
                    groupBox1.Visible = true;
                    richTextBox1.Visible = true;
                    button2.Visible = true;
                    button4.Visible = true;
                    label3.Visible = true;
                    button1.Visible = true;
                    pictureBox1.Load(link);
                    String ilacadi = reader["ilac_ad"].ToString();
                    label2.Text = ilacadi;
                    String acikla = reader["aciklama"].ToString();
                    richTextBox1.Text = acikla;
                    reader.Close();
                       


                    }


                }
                else
                {
                    MessageBox.Show("Geçersiz veya boş fotoğraf bağlantısı girdiniz!!!");


                }
                connect.baglanti.Close();




            }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
     
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

          

        }


        //alınmak istenen ılacların adını ve ucretlerını bır listede toplayıp bu lısteyı dıger forma aktarıp
        //sepete eklme ıslemı ıcın kullanacagız
        
        private List<String> isimListe = new List<String>();
        private List<String> ucretListe = new List<String>();
        //alınan mıktarın lıstesını tutar
        private List<int> counterListe = new List<int>();
        private void button3_Click_1(object sender, EventArgs e)
        {
            connect.baglanti.Open();
            //fonksiyon 2(ilacStokKontrol)
            //--------------------------------------------------------------------------------
            //bu fonksıyon ılac stok kontrol eder 0 da buyukse ıslem yapar yoksa stok yok der
            SqlCommand stokSorgulamaFunction = new SqlCommand("select dbo.ilacStokKontrol(@ilac_id)", connect.baglanti);
            stokSorgulamaFunction.Parameters.AddWithValue("@ilac_id", id);
            int StokBilgisi = Convert.ToInt32(stokSorgulamaFunction.ExecuteScalar());



            if (StokBilgisi != null && StokBilgisi == 1)
            {
                //fonksıyon 3(StokMiktarKontrol)
                //-----------------------------------------------------------
                //bu fonksıyon eger stok varsa ıstenen mıktarın mevcut stoktan buyuk olup olmadıgını kontrol eder
                SqlCommand StokIstenenCompare = new SqlCommand("select dbo.StokMiktarKontrol(@urun_id,@istenenMiktar)", connect.baglanti);
                StokIstenenCompare.Parameters.AddWithValue("@urun_id", id);
                StokIstenenCompare.Parameters.AddWithValue("@istenenMiktar",label3.Text);
                int stokMiktarCompareResult= Convert.ToInt32(StokIstenenCompare.ExecuteScalar());



                if (stokMiktarCompareResult==0)
                {
                    MessageBox.Show("stokta istenen kadar ürün yok");
                }
                else
                {
                    // eger ıstenen mıktar stoktan daha azsa ıslem yapar

                    SqlCommand idAlKomutu = new SqlCommand("select ilac_ad,ucret from ilac where ilac_id=@id", connect.baglanti);
                    idAlKomutu.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = idAlKomutu.ExecuteReader();




                    if (reader.Read()) // Eğer sonuç dönerse
                    {


                        string ilacAd = reader["ilac_ad"].ToString();
                        string ucret = reader["ucret"].ToString();

                        // Değerleri bir sınıfa veya tuple olarak atayın
                        var sonuc = (ilacAd, ucret);
                        reader.Close();
                        //ilacın alınma tarıh ıle suan kı tarıh arası farkı sorgular farkı alır
                        SqlCommand EndBuyDate = new SqlCommand("select DATEDIFF(DAY, alinma_tarihi, GETDATE()) from ilacSatinAl WHERE kullanici_id = @kullanici_id  AND ilac_id = @ilac_id", connect.baglanti);
                        EndBuyDate.Parameters.AddWithValue("@kullanici_id", kullaniciId);
                        EndBuyDate.Parameters.AddWithValue("@ilac_id", id);
                        int? count;
                        count = EndBuyDate.ExecuteScalar() == null ? 0 : (int)EndBuyDate.ExecuteScalar(); // ExecuteScalar() ile tek bir değer alıyoruz
                        //eger kullanıcı 3 gunden daha az once bır vakut aynı ılacı aldıysa suan kullanıcıya bu ılacı verme
                        if (count < 3 || count == 0)
                        {
                            //eger sepete eklenen ılac yokas lıstede lısteye ekle
                            if (isimListe.Contains(sonuc.ilacAd))
                            {
                                // İlgili ilacın index'ini bul
                                int index = isimListe.IndexOf(sonuc.ilacAd);

                                counterListe[index] = Int32.Parse(label3.Text);

                            }
                            //varsa sadece ılacın mıktarını(adetını) guncelle 
                            else
                            {

                                isimListe.Add(sonuc.ilacAd);
                                ucretListe.Add(sonuc.ucret);
                                counterListe.Add(Int32.Parse(label3.Text));
                                // Yeni bir öğe eklendiğinde label3'ü sıfırlıyoruz
                                label3.Text = "0";

                            }

                            MessageBox.Show("sepete eklendi");


                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("bu ilacı yakın bır tarıhte almıssınız suan ekleyemeyız");

                        }
                    }
                }

            }
            else
            {

                MessageBox.Show("stokta ürün yok");
                label3.Text = "0";
            }

            
            connect.baglanti.Close();



        }
        //enum tanımladık + ve - temsıl eden ona gore gereklı fonksıyon cagırıcaz
        enum durum
        {
            arti, eksi
        }
        //+ ve - butonlarında artırma ve eksıltme ıslemını saglayan fonksıyon
        void IncrementButton(Label label, durum state)
        {
            int count = Int32.Parse(label.Text);
            if (state == durum.arti) count++;
            else count--;
            if (count < 0) label.Text = 0.ToString();
            else label.Text = count.ToString();
        }
        //ılacın adı ,ucreti ve ılac sayısını sepet formuna gonderıyoruz
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(isimListe,ucretListe,counterListe);
            f4.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            IncrementButton(label3,durum.arti);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IncrementButton(label3, durum.eksi);
        }
    }


    public class getDatabaseData
    {   //bu fonksıyon ıle tc ye gore kısının adını gerı donduruyor fonksıyon
        public static String getName(String tc)
        {
            String isim = null;
            try
            {
                
                connect.baglanti.Open();
                //sp 2(adAlma)
                //--------------------------------------------------------------
                //bu sp verılen tc ye gore ad almamızı saglayan sorguyu ıcerıyor
                SqlCommand adGetir = new SqlCommand("sp_adAlma", connect.baglanti);
                adGetir.CommandType = CommandType.StoredProcedure;
                char[] tcCharArray = tc.ToCharArray();
                adGetir.Parameters.AddWithValue("@tcAl", tcCharArray);
                SqlDataReader reader = adGetir.ExecuteReader();
                if (reader.Read())

                {
                    isim = reader["ad"].ToString();
                    

                }
                reader.Close();
                connect.baglanti.Close();
                

            }catch(Exception error)
            {
                printErrorClass.printErrorMethod(error);
            }
            finally
            {
                if (connect.baglanti.State == System.Data.ConnectionState.Open)
                    connect.baglanti.Close();
            }

            return isim;



        }
    }

    //verı tabanına baglanmayı saglayan baglantıyı bır classta topladık cok fazla yerde kullandıgımız ıcın
    public  class connect
    {
        static public string conString = "Data Source=LAPTOP-IPEK;Initial Catalog=pharmacy_app;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";
        static public SqlConnection baglanti = new SqlConnection(conString);
    }

}


