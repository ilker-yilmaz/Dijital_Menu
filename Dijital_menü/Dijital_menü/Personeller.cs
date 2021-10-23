using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Dijital_menü
{
    class Personeller
    {
        Genel gnl = new Genel();//genel sınıfının bir nesnesini oluşturduk.
        #region Field
        private int _PersonelId;
        private int _PersonelGorevId;
        private string _PersonelAd;
        private string _PersonelSoyad;
        private string _PersonelParola;
        private string _PersonelKullaniciAdi;
        private bool _PersonelDurum;
        #endregion
        #region Properties
        public int PersonelId { get => _PersonelId; set => _PersonelId = value; }
        public int PersonelGorevId { get => _PersonelGorevId; set => _PersonelGorevId = value; }
        public string PersonelAd { get => _PersonelAd; set => _PersonelAd = value; }
        public string PersonelSoyad { get => _PersonelSoyad; set => _PersonelSoyad = value; }
        public string PersonelParola { get => _PersonelParola; set => _PersonelParola = value; }
        public string PersonelKullaniciAdi { get => _PersonelKullaniciAdi; set => _PersonelKullaniciAdi = value; }
        public bool PersonelDurum { get => _PersonelDurum; set => _PersonelDurum = value; }
        #endregion

        public bool personalEntryControl(string password, int UserId)
        {
            bool result = false;

            SqlConnection conn = new SqlConnection(gnl.conString);//veritabanına bağlandık.
            SqlCommand cmd = new SqlCommand("Select * from Personeller where ID=@Id and PAROLA=@password", conn);//gelen ID ve PAROLA'yı kontrol ettik.
            cmd.Parameters.Add("@Id", SqlDbType.VarChar).Value = UserId;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            try
            {
                if (conn.State == ConnectionState.Closed)//eğer bağlantı yoksa, kapalıysa;
                {
                    conn.Open();//bağlantı açılacak.
                }
                result = Convert.ToBoolean(cmd.ExecuteScalar());//sonucumuz boolean veri tipinde geri gelecek
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }

            return result;
        }
        public void personelGetByInformation(ComboBox cb)
        {
            cb.Items.Clear();//öncelikle comboBox'ı temizliyoruz.

            //veritabanına bağlanıp bilgileri getireceğiz.
            SqlConnection conn = new SqlConnection(gnl.conString);//veritabanına bağlandık.
            SqlCommand cmd = new SqlCommand("Select * from Personeller", conn);//gelen ID ve PAROLA'yı kontrol ettik.


            if (conn.State == ConnectionState.Closed)//eğer bağlantı yoksa, kapalıysa;
            {
                conn.Open();

            }

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())//ne kadar bilgi varsa okuyacağız.
            {
                Personeller p = new Personeller();
                p._PersonelId = Convert.ToInt32(dr["ID"]);
                p._PersonelGorevId = Convert.ToInt32(dr["GOREVID"]);
                p._PersonelAd = Convert.ToString(dr["AD"]);
                p._PersonelSoyad = Convert.ToString(dr["SOYAD"]);
                p._PersonelParola = Convert.ToString(dr["PAROLA"]);
                p._PersonelKullaniciAdi = Convert.ToString(dr["KULLANICIADI"]);
                p._PersonelDurum = Convert.ToBoolean(dr["DURUM"]);
                cb.Items.Add(p);//obje türüne nesneyi ekledik.


            }
            dr.Close();
            conn.Close();

        }

        public override string ToString()
        {
            return PersonelAd;
        }
    }
}
