using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eczane_veritabani_uygulamasi
{
    public partial class Form5 : Form
    {
        //bu form admın kısısının ılac ekleme sılme depoya ekleme gıbı ıslemlerını gerceklestırıyor
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {



        }
        //temizle fonksıyonu textboxlara yazdıgımız textlerı temızlemeye yarar
        void temizle()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox4.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //ılacları lıstele butonu ıle lısteleyınce cıft clıck yapınca o ılacınbılgılerını soldakı textboxlara yansıtır ve yazar
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            connect.baglanti.Open();
            //sp 3(ilacSilmeProcedure)
            //----------------------------------------------------------------
            //bu sp cıft clıck yaptıgımız ve sıl butonuna bastıgımız ılacı ılac tablosundan sılmeye yarıyor
            //tam bu kısımda stok,ilacsatinal,recete ıle ılac tablşosu baglantılı oldugu ıcın ılac sılınce sıınen
            //ılac bu uc tablodan da sılınır sp de bu ıslem yer alıyor 
            SqlCommand delete = new SqlCommand("sp_ilacSilmeProcedure", connect.baglanti);
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.AddWithValue("@isim",textBox2.Text);
            delete.ExecuteNonQuery();
            connect.baglanti.Close();
            MessageBox.Show("ilaç silindi");
            temizle();
           
                
        }

        private void button4_Click(object sender, EventArgs e)
        {


            // TODO: Bu kod satırı 'pharmacy_appDataSet16.ilac' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ilacTableAdapter5.Fill(this.pharmacy_appDataSet16.ilac);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text!= "" && textBox3.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {

                connect.baglanti.Open();
                //sp 4(sp_ilacEkleme
                //---------------------------------------------------------------
                //bu sp admının eklemek ıstedıgı ılac bılgılerını yazıp ekle tusuna basında ılac tablosuna ılac ekler
                //yıne stok ıle ılıskılı oldugu ıcın bu tablo trıggerı tetıkler ve stok tablosuna da eklenır bu ılac
                //trıgger 2(trg_eklenenIlaciStokTableEkleme)
                SqlCommand ekle = new SqlCommand("sp_ilacEkleme", connect.baglanti);
                ekle.CommandType = CommandType.StoredProcedure;
                ekle.Parameters.AddWithValue("@ad", textBox2.Text);
                ekle.Parameters.AddWithValue("@ucret", textBox3.Text);
                ekle.Parameters.AddWithValue("@sontarih", textBox8.Text);
                ekle.Parameters.AddWithValue("@siklik", textBox7.Text);
                ekle.Parameters.AddWithValue("@aciklama", textBox6.Text);
                ekle.Parameters.AddWithValue("@firma", textBox5.Text);
                ekle.Parameters.AddWithValue("@photo", textBox1.Text);
                ekle.Parameters.AddWithValue("@adet", textBox4.Text);
                SqlDataReader reader = ekle.ExecuteReader();

                //ayrıca ılac eklenınce hangı ılacın ne zaman hangı tarıhte eklendıgını messageboxta gorebılmek ıcın
                //bır trıgger tetıklıyoruz ve messagbox ıle gelen bılgılerı gosterıyoruz
                //trıgger 3(tr_ilacTableInsert)
                if (reader.Read())
                {


                    string mesaj = reader["Mesaj"].ToString();
                    string tarih = reader["Tarih"].ToString();
                    string ilacAdi = reader.GetValue(2).ToString();
                    // Trigger verilerini MessageBox'ta göster
                    MessageBox.Show($"Mesaj: {mesaj}\nTarih: {tarih}\nİlaç Detayı: {ilacAdi}");
                }

                reader.Close();
                connect.baglanti.Close();
            }
            else
            {
                MessageBox.Show("lutfen gecerli bır ılac gırınız");
            }
        }
        

        private void button5_Click(object sender, EventArgs e)
        {
            connect.baglanti.Open();
            //depoya ekle butonuna basınca stok tablosuna ılgılı ılacın stogunu artırma ıslemını yapıyoruz
            SqlCommand depoAl = new SqlCommand("select mevcut_stok from stok where ilac_ad=@ad", connect.baglanti);
            depoAl.Parameters.AddWithValue("@ad",textBox2.Text);
            SqlDataReader reader= depoAl.ExecuteReader();
            if (reader.Read())

            {
                String deposayi = reader["mevcut_stok"].ToString();
                int intdeposayi=Int32.Parse(deposayi);
                //mevcut stoga eklenmek ıstenen mıktarı toplayıp guncel stogu buluyoruz
                int guncellenmisdepo=intdeposayi + Int32.Parse(textBox4.Text);
                reader.Close();
                //aardından stok guncellıyoruz
                SqlCommand ekle = new SqlCommand("update stok set mevcut_stok=@depoguncel where ilac_ad=@ad", connect.baglanti);
                ekle.Parameters.AddWithValue("@ad", textBox2.Text);
                ekle.Parameters.AddWithValue("@depoguncel", guncellenmisdepo);
                ekle.ExecuteNonQuery();
                MessageBox.Show("Depoya ekleme başarılı");
            }
            connect.baglanti.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
        }
    }
}
