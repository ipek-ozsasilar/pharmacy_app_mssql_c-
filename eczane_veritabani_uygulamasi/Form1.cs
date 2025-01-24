using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eczane_veritabani_uygulamasi
{
    public partial class Form1 : Form
    {
        public static String tc;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            //şifre textbxına girilen değerlerin gözükmemesi için * koyduk
            notVisiblePassword(textBox2);
            //sifre kutucuguna max 6 karakter girilebilmesini sağladık
            textBox2.MaxLength = numberConstant.passwdLenght;
            //tc kutucuguna max 6 karakter girilebilmesini sağladık
            textBox1.MaxLength = numberConstant.tcLenght;
            

        }
        


        private async void button1_Click(object sender, EventArgs e)
        {

            //Bağlantı vs ile ilgili olası bir hatayı önlemek için try-catch mekanizması koyduk
            try
            {
                //fonksiyon 1 (loginKontrolFunction)
                //-------------------------------------------------------------
                //baglantı açtık ve giriş ekranında girlen tc ve şifreyi böyle bir kullanıcı tanımlı mı diye fonksiyon ile sorguladık
                //fonksıyondan yetki bilgisi döndü
                connect.baglanti.Open();
                SqlCommand tcVeSifreSorgula = new SqlCommand("select dbo.LoginKontrolFunction(@tc,@sifre)", connect.baglanti);
                tcVeSifreSorgula.Parameters.AddWithValue("@tc", textBox1.Text);
                tcVeSifreSorgula.Parameters.AddWithValue("@sifre", textBox2.Text);

                //datayı okumak için reader kullandık
                SqlDataReader reader = tcVeSifreSorgula.ExecuteReader();


                // Eğer bir sonuç varsa
                if (reader.Read()) 
                {
                    reader.Close();
                    MessageBox.Show("Giriş başarili");
                    //yetkiyi aldık
                    int yetkiNo = Convert.ToInt32(tcVeSifreSorgula.ExecuteScalar());
                    
                    tc = textBox1.Text;
                        //yetki 0 ise normal kullanıcı
                        if (yetkiNo==0) {
                        
                            connect.baglanti.Close();
                            Form9 f9 = new Form9(textBox1);
                            f9.Show();
                        }
                        //yetki 1 ise admin
                        else if (yetkiNo == 1)
                        {
                        
                        connect.baglanti.Close();
                            Form5 f5 = new Form5();
                            f5.Show();
                        }
                        //yetki 2 ise doktor 
                        else if(yetkiNo == 2)
                        {
                      
                        String input= textBox1.Text; 
                            connect.baglanti.Close();
                            Form8 f8 = new Form8(input);
                            f8.Show();

                        }
                    else
                    {
                        MessageBox.Show("yetki turu gecersiz");
                    }
                       
                    }

                else
                {
                    MessageBox.Show("Üzgünüm kullanıcı bulunamadı.");
                }

               

                               
            }
            //bir hata çıkarsa hata mesajını yazdırır
            catch (Exception error)
            {
                printErrorClass.printErrorMethod(error);
            }
            //her halükarda çalışır bu blok ve eğer bağlantı açıksa bağlantıyı kapatır
            finally
            {
                if (connect.baglanti.State == System.Data.ConnectionState.Open)
                    connect.baglanti.Close();
            }

           
        }

        //kullanıcı tcsini gerı donduren fonksıyon
        public static string getTc()
        {

            return tc;
        }
        //kullanıcının hesabı yoksa üyeolacak ve üye olma formuna yönlendirir
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //şifre kutucuklarında girilen şifrenin gizlenmesi için 
        static public void notVisiblePassword(System.Windows.Forms.TextBox tb)
        {
            tb.PasswordChar = '*';
        }

        //0-9 arası rakam gırılmesını sagladık
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            numberContains(textBox1);
            
        }

        //tc veya şifre textboxına sadece rakam girilmesini sağlayan method
       public static void numberContains(TextBox textbox)
        {

            List<String> firstList = new List<String>();

            // listeye eleman ekledik
            firstList.Add(0.ToString());
            firstList.Add(1.ToString());
            firstList.Add(2.ToString());
            firstList.Add(3.ToString());
            firstList.Add(4.ToString());
            firstList.Add(5.ToString());
            firstList.Add(6.ToString());
            firstList.Add(7.ToString());
            firstList.Add(8.ToString());
            firstList.Add(9.ToString());

            String text = textbox.Text;

            if (text.Length != 0)
            {
                //her seferinde girilen textin sonuncu karakterini alırız 
                
                char lastCharacter = text[text.Length - 1];
                //girilen karakter liste içindeki karaktelerden biri mi diye bakarız
                if (firstList.Contains(lastCharacter.ToString()) == false)
                {
                    //eğer rakam harici bir şey girilirse texti temizler
                    MessageBox.Show("sadece 0-9 arası karakterler girebilirsiniz");
                    textbox.Text = "";
                }

            }

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            numberContains(textBox2);
            
        }
    }

    //catch dusen kısımların hata mesajı yazdırmasını saglayan fonksıyon
    public class printErrorClass
    {
        public static void printErrorMethod(Exception error)
        {
            MessageBox.Show($"Hata mesaji: {error.Message}");
        }
    }

   



}

