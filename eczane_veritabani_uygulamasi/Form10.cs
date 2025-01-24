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

namespace eczane_veritabani_uygulamasi
{
    public partial class Form10 : Form

    {
        System.Windows.Forms.TextBox tb;
        String ad;
        public Form10(System.Windows.Forms.TextBox tb, String ad)
        {
            InitializeComponent();
            this.tb = tb;
            this.ad = ad;
     
     
        }

      
        private void Form10_Load(object sender, EventArgs e)
        {
            String tc = tb.Text;
            connect.baglanti.Open();
            //sp 5(sp_ReceteSorgula) onceden tanımlanmıstı yıne burada da kullandık ıslem turu 2 oldugu ıcn 
            //kullanıcının recete bılgılerını getırıyor
            //--------------------------------------------------------------
            SqlCommand sonRecete = new SqlCommand("sp_ReceteSorgula", connect.baglanti);
            sonRecete.CommandType = CommandType.StoredProcedure;
            sonRecete.Parameters.AddWithValue("@tc", tb.Text);
            sonRecete.Parameters.AddWithValue("@islemTuru", 2);
            //tablo halınde bu recete bılgılerını alıyor ve datagrıdvıew yazdırıyor
            SqlDataAdapter adapter = new SqlDataAdapter(sonRecete);
            DataTable receteTablosu = new DataTable();
            adapter.Fill(receteTablosu);
            dataGridView1.DataSource = receteTablosu;
            connect.baglanti.Close();







        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            String id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            connect.baglanti.Open();
            //receteye cıft tıklanıyor ve recetenın durumu sorgulanıyor 
            SqlCommand receteDurumSorgu = new SqlCommand("select recete_durum from recete where recete_id=@recete_id",connect.baglanti);
            receteDurumSorgu.Parameters.AddWithValue("@recete_id",id);
            SqlDataReader reader= receteDurumSorgu.ExecuteReader();
            if (reader.Read())
            {

                String durum = reader["recete_durum"].ToString();
                reader.Close();
                //recete durumu suresı gecmısse tarıhı gecmıs dıyıp hata verır
                if (durum == "suresi gecmis")
                {
                    MessageBox.Show("maalesef bu reçetenin tarihi geçmiş");

                }
                //recete durumu aktıf ıse ılac satın alma sayfasına gıder
                else
                {

                    Form3 f3 = new Form3(ad, tb.Text);
                    f3.Show();
                }
                
            }
            connect.baglanti.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
