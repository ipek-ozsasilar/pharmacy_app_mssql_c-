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
    public partial class Form8 : Form
    {
        //kullanıcının(doctor) tcsını parametre olarak aldık
        String charsId;
        public Form8(String charsId)
        {
            this.charsId = charsId;
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //doktorun recete yazma formuna geldık
            connect.baglanti.Open();
            DateTime tarih = Form6.DateTimeConverter(dateTimePicker1.Value);
            //doktor recete yazınca recete bılgısı recete tablosuna eklenır
            SqlCommand receteEkleme = new SqlCommand("insert into recete (doktor_id,ilac_id,tarih,doz,kullanim_suresi,recete_durum,ilac_ad,kullanici_id) values(@doktorid,@ilacid,@tarih,@doz,@sure,@durum,@ad,@kulllaniciid)", connect.baglanti);
            receteEkleme.Parameters.AddWithValue("@doktorid", textBox6.Text);
            receteEkleme.Parameters.AddWithValue("@ilacid", textBox2.Text);
            receteEkleme.Parameters.AddWithValue("@tarih", tarih);
            receteEkleme.Parameters.AddWithValue("@doz", textBox3.Text);
            receteEkleme.Parameters.AddWithValue("@sure", textBox4.Text);
            receteEkleme.Parameters.AddWithValue("@kulllaniciid", textBox5.Text);
            receteEkleme.Parameters.AddWithValue("@durum", comboBox1.Text);
            receteEkleme.Parameters.AddWithValue("@ad", textBox1.Text);
            receteEkleme.ExecuteNonQuery();
            MessageBox.Show("reçete oluşturuldu");
            connect.baglanti.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'pharmacy_appDataSet19.ilac' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ilacTableAdapter1.Fill(this.pharmacy_appDataSet19.ilac);

            connect.baglanti.Open();
            //recete yazma formu yuklenınce receteler taranıyor ve recetenın yazılması 1 gunu gecmıs ıse suresı gecmıs olarak degıstırılıyor recete durumu
            SqlCommand durumUpdateRecete = new SqlCommand("update recete set recete_durum = case  when DATEDIFF(DAY, tarih, GETDATE()) > 1 then 'suresi gecmis' else recete_durum end where  recete_durum = 'aktif'", connect.baglanti);
            durumUpdateRecete.ExecuteNonQuery();
            textBox6.Text = charsId;
            dateTimePicker1.Value = DateTime.Now;
            connect.baglanti.Close();
        }
        //recete yazaarken ıstedıgımız ılaca cıft clıck yaparsak bazı bılgılerı otomatık olarak receteye dolacaktır
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }
    }
}
