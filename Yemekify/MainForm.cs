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

namespace Yemekify
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool sidebarExpanded = false;
        bool tarifCollapse = true;
        bool depoCollapse = true;


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpanded)
            {
                sidebarContainer.Width -= 10;
                if (sidebarContainer.Width == sidebarContainer.MinimumSize.Width)
                {
                    sidebarExpanded = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebarContainer.Width += 10;
                if (sidebarContainer.Width == sidebarContainer.MaximumSize.Width)
                {
                    sidebarExpanded = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void tarifIslemleriTimer_Tick(object sender, EventArgs e)
        {
            if (tarifCollapse)
            {
                tarifPanel.Height += 10;
                if (tarifPanel.Height == tarifPanel.MaximumSize.Height)
                {
                    tarifCollapse = false;
                    tarifIslemleriTimer.Stop();
                }
            }
            else
            {
                tarifPanel.Height -= 10;
                if (tarifPanel.Height == tarifPanel.MinimumSize.Height)
                {
                    tarifCollapse = true;
                    tarifIslemleriTimer.Stop();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tarifIslemleriTimer.Start();
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            addRecipeForm addRecipeForm = new addRecipeForm();
            addRecipeForm.ShowDialog();
        }

        private void editRecipeButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteRecipeButton_Click(object sender, EventArgs e)
        {

        }

        private void sidebarContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void depotButton_Click(object sender, EventArgs e)
        {
            depoIslemleriTimer.Start();
        }

        private void addIngredientToDepot_Click(object sender, EventArgs e)
        {

        }

        private void deleteIngredient_Click(object sender, EventArgs e)
        {

        }

        private void viewIngredients_Click(object sender, EventArgs e)
        {

        }

        private void depoIslemleriTimer_Tick(object sender, EventArgs e)
        {
            if (depoCollapse)
            {
                depotPanel.Height += 10;
                if (depotPanel.Height == depotPanel.MaximumSize.Height)
                {
                    depoCollapse = false;
                    depoIslemleriTimer.Stop();
                }
            }
            else
            {
                depotPanel.Height -= 10;
                if (depotPanel.Height == depotPanel.MinimumSize.Height)
                {
                    depoCollapse = true;
                    depoIslemleriTimer.Stop();
                }
            }
        }
    }
}


/*Random rnd = new Random();


List<string> tarifAdlari = new List<string> { "Spaghetti", "Kek", "Pilav", "Salata", "Pizza" };
List<string> kategoriler = new List<string> { "Ana Yemek", "Tatlı", "Ara Sıcak", "Salata" };

string randomTarifAdi = tarifAdlari[rnd.Next(tarifAdlari.Count)];
string randomKategori = kategoriler[rnd.Next(kategoriler.Count)];
int randomHazirlamaSuresi = rnd.Next(10, 120);

string randomTarifTalimatlar = $"Adım 1: {randomTarifAdi} için malzemeleri hazırla. Adım 2: Talimatları takip et.";


List<string> malzemeAdlari = new List<string> { "Un", "Şeker", "Tereyağı", "Süt", "Zeytinyağı" };
List<string> malzemeBirimleri = new List<string> { "kg", "litre", "gram" };

string randomMalzemeAdi = malzemeAdlari[rnd.Next(malzemeAdlari.Count)];
string randomMalzemeBirimi = malzemeBirimleri[rnd.Next(malzemeBirimleri.Count)];
string randomToplamMiktar = $"{rnd.Next(1, 100)} {randomMalzemeBirimi}";
decimal randomBirimFiyat = Math.Round((decimal)(rnd.NextDouble() * 100), 2);


string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    try
    {
        int malzemeID;
        int tarifID;
        connection.Open();


        string insertTarifQuery = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar); SELECT SCOPE_IDENTITY();";
        using (SqlCommand command = new SqlCommand(insertTarifQuery, connection))
        {
            command.Parameters.AddWithValue("@TarifAdi", randomTarifAdi);
            command.Parameters.AddWithValue("@Kategori", randomKategori);
            command.Parameters.AddWithValue("@HazirlamaSuresi", randomHazirlamaSuresi);
            command.Parameters.AddWithValue("@Talimatlar", randomTarifTalimatlar);

            tarifID = Convert.ToInt32(command.ExecuteScalar());  // TarifID'yi alıyoruz
            MessageBox.Show($"Tarif başarıyla kaydedildi. TarifID: {tarifID}");
        }

        // Rastgele malzeme veritabanına kaydetme
        string insertMalzemeQuery = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat); SELECT SCOPE_IDENTITY();";
        using (SqlCommand command = new SqlCommand(insertMalzemeQuery, connection))
        {
            command.Parameters.AddWithValue("@MalzemeAdi", randomMalzemeAdi);
            command.Parameters.AddWithValue("@ToplamMiktar", randomToplamMiktar);
            command.Parameters.AddWithValue("@MalzemeBirim", randomMalzemeBirimi);
            command.Parameters.AddWithValue("@BirimFiyat", randomBirimFiyat);

            malzemeID = Convert.ToInt32(command.ExecuteScalar());  // MalzemeID'yi alıyoruz
            MessageBox.Show($"Malzeme başarıyla kaydedildi. MalzemeID: {malzemeID}");
        }

        // Tarif-Malzeme ilişki tablosuna kaydetme
        string insertTarifMalzemeQuery = "INSERT INTO TarifMalzeme (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar);";
        using (SqlCommand command = new SqlCommand(insertTarifMalzemeQuery, connection))
        {
            command.Parameters.AddWithValue("@TarifID", tarifID);
            command.Parameters.AddWithValue("@MalzemeID", malzemeID);
            command.Parameters.AddWithValue("@MalzemeMiktar", rnd.Next(1, 10));  // Rastgele bir malzeme miktarı

            command.ExecuteNonQuery();
            MessageBox.Show($"Tarif-Malzeme ilişkisi başarıyla kaydedildi.");
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Hata: " + ex.Message);
    }
}
*/