using System;
using System.Collections;
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
    public partial class Form7 : Form
    {
        String urunAd;
        String ad;
        DateTime tarih;
        int adet;
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label1.Size = new Size(40,40);
            //tum raporları alırsa top 1 yap
            //view 1
            //---------------------------------------------------------------------------
            //vıew raporu ılacın satın alındıktan sonra ılac ,ılacsatınal,kullanıcılar tablolarını bırlestırır
            //ve bır satın alma raporu olusturur bunu messagebox ıle ekranda gosterır
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from vw_ilacSatisRaporu", connect.baglanti);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            
            foreach (DataRow rows in dataTable.Rows)
            {
                
                urunAd = rows["kisi_tc"].ToString();
                ad = rows["ad"].ToString();
                tarih = Convert.ToDateTime(rows["tarih"]);
                adet = Int32.Parse(rows["adet"].ToString());
                decimal toplamTutar = Convert.ToDecimal(rows["toplam_tutar"]);
                
            }
            MessageBox.Show("satın alan kişi tc :"+urunAd+" fiyat :"+ad+" tarih :"+ tarih+" adet :"+adet);


        }

       
        }
    }

