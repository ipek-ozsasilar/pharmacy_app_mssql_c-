using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eczane_veritabani_uygulamasi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //şifre gizlenmesi ve textbox max girilecek karakter ayarlanmaları yapıldı
            Form1.notVisiblePassword(textBox5);
            //telefon textboxını türk telefon kodu baslattık
            textBox4.Text = "+90";
            textBox5.MaxLength = numberConstant.passwdLenght;
            textBox1.MaxLength = numberConstant.tcLenght;
            textBox4.MaxLength = numberConstant.phoneLenght;

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //telefon başındaki +09 sildik ve geriye kalan 11 haneyi veritabına göndereceğiz
                String telefon = textBox4.Text.Remove(0, 3);
                connect.baglanti.Open();
                bool radio1 = radioButton1.Checked;
                bool radio2 = radioButton2.Checked;
                //eğer kullanıcı rolu ıle kaydolmussa yetki 0 ayarlandı
                //veritabanına bilgiler gönderilip kullanıcılar tablosuna kaydedıldı
                if (radio1)
                {
                    //sp 1(yetkiyeGoreKullaniciEkleme)
                    //--------------------------------------------------------------
                    //kaydolunan yetki turune gore(user mı doctor mı) o kısıyı sp kullanarak kullanıcılar tablosuna ekledık
                    //yetki normal user ıse bu sekılde ekledık
                    SqlCommand ekle = new SqlCommand("sp_yetkiyeGoreKullaniciEkleme", connect.baglanti);
                    ekle.CommandType = CommandType.StoredProcedure;
                    ekle.Parameters.AddWithValue("@tc", textBox1.Text);
                    ekle.Parameters.AddWithValue("@ad", textBox2.Text);
                    ekle.Parameters.AddWithValue("@soyad", textBox3.Text);
                    ekle.Parameters.AddWithValue("@telefon", telefon);
                    ekle.Parameters.AddWithValue("@sifre", textBox5.Text);
                    ekle.Parameters.AddWithValue("@radiovalue","user");
                    ekle.Parameters.AddWithValue("@yetki",0);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("kaydolma başarılı");
                    connect.baglanti.Close();
                    Form9 f9 = new Form9(textBox1);
                    f9.Show();
                }

               
                //eğer doctor rolu ıle kaydolmussa yetki 2 ayarlandı

                else if (radio2)
                {
                   
                    //yetki doctor ıse bu sekılde ekledık
                    SqlCommand ekle = new SqlCommand("sp_yetkiyeGoreKullaniciEkleme", connect.baglanti);
                    ekle.CommandType = CommandType.StoredProcedure;
                    ekle.Parameters.AddWithValue("@tc", textBox1.Text);
                    ekle.Parameters.AddWithValue("@ad", textBox2.Text);
                    ekle.Parameters.AddWithValue("@soyad", textBox3.Text);
                    ekle.Parameters.AddWithValue("@telefon", telefon);
                    ekle.Parameters.AddWithValue("@sifre", textBox5.Text);
                    ekle.Parameters.AddWithValue("@radiovalue","doctor");
                    ekle.Parameters.AddWithValue("@yetki", 2);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("kaydolma başarılı");
                    //doctorun idsini sakladık ve recete yazma sayfasına gonderdık
                    String tcDoctor = textBox1.Text;
                    connect.baglanti.Close();
                    Form8 f8 = new Form8(tcDoctor);
                    f8.Show();
                }


                
            }
            catch (Exception error)
            {
                printErrorClass.printErrorMethod(error);
            }
            finally
            {
                if (connect.baglanti.State == System.Data.ConnectionState.Open)
                    connect.baglanti.Close();
            }
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            Form1.numberContains(textBox1);
        }

       

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
            Form1.numberContains(textBox5);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
          
            Form1.numberContains(textBox4);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    // uygulamada kullandııgmız sabıt verılerı bır classta toplayıp buradan cagırdık
    public class numberConstant
    {
        static public int passwdLenght=6;
        static public int tcLenght = 11;
        static public int phoneLenght = 13;
        static public int cardLenght = 16;
        static public int cvvLenght = 3;
    }
}

