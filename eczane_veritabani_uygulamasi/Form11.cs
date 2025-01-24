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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace eczane_veritabani_uygulamasi
{

   

    public partial class Form11 : Form
    {
        int secilen;
        String id;
        public Form11()
        {
            InitializeComponent();
        }
       
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {
            //şifre gizlenmesi ve textbox max girilecek karakter ayarlanmaları yapıldı
            Form1.notVisiblePassword(textBox6);
            //telefon textboxını türk telefon kodu baslattık
            textBox7.Text = "+90";
            textBox6.MaxLength = numberConstant.passwdLenght;
            textBox2.MaxLength = numberConstant.tcLenght;
            textBox7.MaxLength = numberConstant.phoneLenght;
        }
        void temizle()
        {

           
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
       
        }
        private void button4_Click(object sender, EventArgs e)
        {

            // TODO: Bu kod satırı 'pharmacy_appDataSet20.kullanicilar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.kullanicilarTableAdapter.Fill(this.pharmacy_appDataSet20.kullanicilar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temizle();
            textBox7.Text = "+90";
        }
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            
            connect.baglanti.Open();
            //sp 6(sp_kisiSilmeEkleme)
            //----------------------------------------------------------------
            //bu sp cıft clıck yaptıgımız ve sıl butonuna bastıgımız kisiyi kullanıcılar tablosundan sılmeye yarıyor
            //kişi tablosu bazı tablolarla ılıskılı oldugu ıcın suan burada devreye gırmemız gerek trıgger kullanınca bu sorun cozulmuyr
            //o nedenle bu sp_kisiSilme procedurunde ılıslıkı oldugu bu 3 tablodakı verılerı de sılem ıslemını gerceklestırıyoruz
            
            SqlCommand delete = new SqlCommand("sp_kisiSilmeEkleme", connect.baglanti);
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.AddWithValue("@tc", id.ToCharArray());
            delete.Parameters.AddWithValue("@islem", KisiIslemExtensions.GetIslemKodu(kisiIslem.silme));
            delete.ExecuteNonQuery();
            connect.baglanti.Close();
            MessageBox.Show("kişi silindi");
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            {
                String telefon = textBox7.Text.Remove(0, 3);
                connect.baglanti.Open();
                //sp 6(sp_kisiSilmeEkleme)
                //---------------------------------------------------------------
                //bu sp admının eklemek ıstedıgı kişi bılgılerını yazıp ekle tusuna basında kullanıcılar tablosuna kullanıcı ekler
                SqlCommand ekle = new SqlCommand("sp_kisiSilmeEkleme", connect.baglanti);
                ekle.CommandType = CommandType.StoredProcedure;
                ekle.Parameters.AddWithValue("@islem", KisiIslemExtensions.GetIslemKodu(kisiIslem.ekleme));
                ekle.Parameters.AddWithValue("@tc", textBox2.Text.ToCharArray());
                ekle.Parameters.AddWithValue("@ad", textBox3.Text);
                ekle.Parameters.AddWithValue("@soyad", textBox8.Text);
                ekle.Parameters.AddWithValue("@telefon", telefon.ToCharArray());
                ekle.Parameters.AddWithValue("@sifre", textBox6.Text.ToCharArray());
                ekle.Parameters.AddWithValue("@yetki", (radioButton1.Checked ?2 : 0));
                ekle.Parameters.AddWithValue("@rol", radioButton1.Checked ? radioButton1.Text :radioButton2.Text);
                SqlDataReader reader = ekle.ExecuteReader();
                reader.Close();
                connect.baglanti.Close();
                MessageBox.Show("kişi eklendi");
                temizle();
            }
            else
            {
                MessageBox.Show("lutfen gecerli bır kişi gırınız");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Form1.numberContains(textBox2);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Form1.numberContains(textBox7);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Form1.numberContains(textBox6);
        }
    }
    public enum kisiIslem
    {
        silme,
        ekleme
    }
    //bu sp ye kısı ekleme veya sılmeye gore gonderılen enum degerıne gore gereklı kodu secer ve calıstırır
    //bu extensıons ıle saglıyoruz
    public static class KisiIslemExtensions
    {
        public static int GetIslemKodu(this kisiIslem islem)
        {
            return islem == kisiIslem.silme ? 0 : 1;
        }
    }

}


