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
    public partial class Form9 : Form
    {

        System.Windows.Forms.TextBox tb;
        
        public Form9(System.Windows.Forms.TextBox tb)
        {
            InitializeComponent();
            this.tb = tb;

        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            connect.baglanti.Open();
            //sp 5(sp_ReceteSorgula)
            //-----------------------------------------------------------------
            //bu sp recete sorgulama ıslemı yapar 
            //uygulamada ıkı tane bırbırıne benzer recete uzerınde yapılan sorgu oldugu ıcın parametre olarak ıslem turunu verdık ve
            //secılen ısleme gore farklı komut calıstırılır
            //burada ıslem 1 secılmıs ve kullanıcıya aıt recete sayısı sorgulanır
            SqlCommand receteVarMi = new SqlCommand("sp_ReceteSorgula", connect.baglanti);
            receteVarMi.CommandType = CommandType.StoredProcedure;
            receteVarMi.Parameters.AddWithValue("@tc", tb.Text);
            receteVarMi.Parameters.AddWithValue("@islemTuru", 1);
            int count = Convert.ToInt32(receteVarMi.ExecuteScalar());

            //sorgu sonucu 0 ise bulunamdı der
            if (count == 0)
            {
                MessageBox.Show("bu kullanıcıya aıt recete bulunmamaktadır");
            }
            else
            {
                //eger kısıye aıt recete bulunursa recete ıle alma sayfasına yonlendırır
                connect.baglanti.Close();
                String ad = getDatabaseData.getName(tb.Text);
                Form10 f10 = new Form10(tb,ad);
                f10.Show();


            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {//eger kısı recetesız ılac almayı ısterse bu forma yonlendırır
            String ad =getDatabaseData.getName(tb.Text);
            Form3 f3 = new Form3(ad, tb.Text);
            f3.Show();
        }
    }
}
