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
            a.fromWhere = "fromAddRecipe";
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
            
            recipesPanel.Controls.Clear();

            
            recipesPanel.AutoScroll = true;  
            recipesPanel.FlowDirection = FlowDirection.TopDown;  
            recipesPanel.WrapContents = false;



            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            string query = "SELECT * FROM Tarifler";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Panel tarifPanel = new Panel
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        Height = 140,
                        Padding = new Padding(10),  
                        AutoSize = false, 
                        Width = recipesPanel.ClientSize.Width - recipesPanel.Padding.Horizontal 
                    };

                    
                    Label tarifAdiLabel = new Label
                    {
                        Text = $"Tarif: {reader["TarifAdi"]}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12)
                    };

                    
                    Label kategoriLabel = new Label
                    {
                        Text = $"Kategori: {reader["Kategori"]}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12)
                    };

                    Label hazirlanmaSuresiLabel = new Label
                    {
                        Text = $"Hazırlanma Süresi: {reader["HazirlamaSuresi"]} dakika",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12)
                    };

                    Label ToplamMaliyetLabel = new Label
                    {
                        Text = "Toplam Maliyet: " +  dbengine.getTotalPrice(reader["TarifID"].ToString()) + " PLN",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12)
                    };


                    Button showRecipeButton = new Button
                    {
                        Text = "Tarifi Göster",
                        Tag = reader["TarifID"],  
                        AutoSize = true,
                        Height = 40,
                        Width = 125,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold)
                    };

                    Button updateRecipeButton = new Button
                    {
                        Text = "Tarifi Düzenle",
                        Tag = reader["TarifID"],
                        AutoSize = true,
                        Height = 40,
                        Width = 100,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold)
                    };


                    showRecipeButton.Click += ShowRecipeButton_Click; 
                    updateRecipeButton.Click += updateRecipeButton_Click;

                    
                    tarifPanel.Controls.Add(tarifAdiLabel);
                    tarifPanel.Controls.Add(kategoriLabel);
                    tarifPanel.Controls.Add(hazirlanmaSuresiLabel);
                    tarifPanel.Controls.Add(ToplamMaliyetLabel);
                    tarifPanel.Controls.Add(showRecipeButton);
                    tarifPanel.Controls.Add(updateRecipeButton);

                    
                    tarifAdiLabel.Location = new Point(10, 10);
                    kategoriLabel.Location = new Point(10, 40);
                    hazirlanmaSuresiLabel.Location = new Point(10, 70);
                    ToplamMaliyetLabel.Location = new Point(10, 100);
                    showRecipeButton.Location = new Point(tarifPanel.Width - 180, 75);
                    updateRecipeButton.Location = new Point(tarifPanel.Width - 180, 25);


                    recipesPanel.Controls.Add(tarifPanel);

                    
                    recipesPanel.Resize += (s, e) => {
                        tarifPanel.Width = recipesPanel.ClientSize.Width - recipesPanel.Padding.Horizontal;
                    };
                }
            }

                
            
        }

        private void updateRecipeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int tarifID = (int)button.Tag;

            addRecipeForm arf = new addRecipeForm();
            arf.fromWhere = "update";
            arf.currentTarifId = tarifID.ToString();
            arf.Show();



        }

        private void ShowRecipeButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int tarifID = (int)button.Tag;

            showRecipeForm srf = new showRecipeForm();
            srf.TarifID = tarifID.ToString();
            srf.Show();
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
            removeIngredientForm rif = new removeIngredientForm();
            rif.Show();
        }

        private void recipesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


/*Random rnd = new Random();
 * 
 * 
 * string newQuery = @"
                    SELECT SUM(tm.MalzemeMiktar * m.BirimFiyat) AS ToplamMaliyet
                    FROM TarifMalzeme tm
                    JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
                    WHERE tm.TarifID = @TarifID
                    GROUP BY tm.TarifID;
                    ";
                        SqlCommand newCommand = new SqlCommand(newQuery, connection);
                        newCommand.Parameters.AddWithValue("@TarifID", reader["TarifID"]);

                        try
                        {
                            object result = newCommand.ExecuteScalar();

                            if (result != null)
                            {
                                decimal toplamMaliyet = (decimal)result;
                                MessageBox.Show(""+toplamMaliyet);
                            }
                            else
                            {
                                Console.WriteLine("Belirtilen tarif için maliyet hesaplanamadı.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }


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