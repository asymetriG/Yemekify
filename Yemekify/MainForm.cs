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



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTarifler();
        }




        private void recipeEventsTimer_Tick(object sender, EventArgs e)
        {
            if (tarifCollapse)
            {
                recipePanel.Height += 10;
                if (recipePanel.Height == recipePanel.MaximumSize.Height)
                {
                    tarifCollapse = false;
                    recipeEventsTimer.Stop();
                }
            }
            else
            {
                recipePanel.Height -= 10;
                if (recipePanel.Height == recipePanel.MinimumSize.Height)
                {
                    tarifCollapse = true;
                    recipeEventsTimer.Stop();
                }
            }
        }

        private void recipeEventsButton_Click(object sender, EventArgs e)
        {
            recipeEventsTimer.Start();
        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            addRecipeForm a = new addRecipeForm();
            a.ShowDialog();
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

        private void depotEvents_Click(object sender, EventArgs e)
        {
            depoIslemleriTimer.Start();
        }

        private void LoadTarifler()
        {
            // Paneli temizliyoruz
            recipesPanel.Controls.Clear();

            // FlowLayoutPanel ayarları
            recipesPanel.AutoScroll = true;  // Panelde kaydırma çubuğu için
            recipesPanel.FlowDirection = FlowDirection.TopDown;  // Panelleri dikey olarak hizalamak için
            recipesPanel.WrapContents = false;  // Alt satıra geçmeyi sağlar

            // Örnek tarif verileri (veritabanından gelecek)
            var tarifler = new List<(int TarifID, string TarifAdi, string Kategori, string HazirlanmaSuresi)>
    {
        (1, "Makarna", "Ana Yemek", "20 dakika"),
        (2, "Pancake", "Tatlı", "15 dakika"),
        (3, "Tost", "Tatlı","Kurwa"),
        (3, "Tost", "Tatlı","Kurwa"),
        (3, "Tost", "Tatlı","Kurwa"),
        (3, "Tost", "Tatlı","Kurwa"),
    };

            // Tarifler için dinamik olarak paneller ve içerik ekliyoruz
            foreach (var tarif in tarifler)
            {
                // Her tarif için bir panel oluşturuyoruz
                Panel tarifPanel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Height = 100,  // Yükseklik sabit
                    Padding = new Padding(10),  // İçeriklere boşluk eklemek için padding
                    AutoSize = false,  // AutoSize'ı false yapıyoruz
                    Width = recipesPanel.ClientSize.Width - recipesPanel.Padding.Horizontal // Panelin genişliği ayarlanıyor
                };

                // Tarif Adı
                Label tarifAdiLabel = new Label
                {
                    Text = $"Tarif: {tarif.TarifAdi}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                // Kategori
                Label kategoriLabel = new Label
                {
                    Text = $"Kategori: {tarif.Kategori}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                // Hazırlanma Süresi
                Label hazirlanmaSuresiLabel = new Label
                {
                    Text = $"Hazırlanma Süresi: {tarif.HazirlanmaSuresi}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                // "Tarifi Göster" butonu
                Button showRecipeButton = new Button
                {
                    Text = "Tarifi Göster",
                    Tag = tarif.TarifID,  // Tarif ID'yi butonun Tag özelliğine atıyoruz
                    AutoSize = true,
                    Height = 40,
                    Width = 100,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                showRecipeButton.Click += ShowRecipeButton_Click; // Butona tıklama olayı ekliyoruz

                // Panelin içine bu öğeleri ekliyoruz
                tarifPanel.Controls.Add(tarifAdiLabel);
                tarifPanel.Controls.Add(kategoriLabel);
                tarifPanel.Controls.Add(hazirlanmaSuresiLabel);
                tarifPanel.Controls.Add(showRecipeButton);

                // Öğeler arasında boşluk ayarlamak için FlowLayoutPanel veya konum ayarları yapılabilir
                tarifAdiLabel.Location = new Point(10, 10);
                kategoriLabel.Location = new Point(10, 40);
                hazirlanmaSuresiLabel.Location = new Point(10, 70);
                showRecipeButton.Location = new Point(tarifPanel.Width - 180, 35); // Buton sağda yerleşir

                // Tarif panelini FlowLayoutPanel'e ekliyoruz
                recipesPanel.Controls.Add(tarifPanel);

                // Panelin genişliği, FlowLayoutPanel genişliği değiştiğinde de otomatik güncellenir
                recipesPanel.Resize += (s, e) => {
                    tarifPanel.Width = recipesPanel.ClientSize.Width - recipesPanel.Padding.Horizontal;
                };
            }
        }

        // "Tarifi Göster" butonuna tıklanınca yapılacak işlemler
        private void ShowRecipeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int tarifID = (int)button.Tag; // Tarif ID'yi alıyoruz

            // ShowRecipe formunu açıyoruz ve ilgili tarif ID'yi gönderiyoruz
            //showRecipe showRecipeForm = new showRecipe(tarifID);
            //showRecipeForm.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

        }

        private void filterButton_Click(object sender, EventArgs e)
        {

        }

        private void addIngredient_Click(object sender, EventArgs e)
        {
            addIngredint ai = new addIngredint();
            ai.Show();
        }

        private void removeIngredient_Click(object sender, EventArgs e)
        {

        }

        private void recipesPanel_Paint(object sender, PaintEventArgs e)
        {

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