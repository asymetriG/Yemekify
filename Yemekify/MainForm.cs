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
using Yemekify;

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
        public List<Tarif> allRecipes;
        public List<Tarif> currentRecipes;
        private List<Malzeme> selectedIngredients = new List<Malzeme>();
        private List<Malzeme> allIngredients = new List<Malzeme>();


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            filterCbox.Visible = false;
            allRecipes = new List<Tarif>();
            currentRecipes= new List<Tarif>();
            LoadTarifler();
            LoadIngredientsPanel();
        }

        private void LoadIngredientsPanel()
        {
            // ingredientsPanel'i temizle
            ingredientsPanel.Controls.Clear();

            // Malzemeler listesinde her bir malzeme için bir Label ekleyelim
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            string query = "SELECT * FROM Malzemeler";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string malzemeAdi = reader["MalzemeAdi"].ToString();
                        int MalzemeID = (int)reader["MalzemeID"];
                        string ToplamMiktar = reader["ToplamMiktar"].ToString();
                        string MalzemeBirim = reader["MalzemeBirim"].ToString();
                        double BirimFiyat = double.Parse(reader["BirimFiyat"].ToString());

                        Malzeme malzeme = new Malzeme(MalzemeID, malzemeAdi, ToplamMiktar,MalzemeBirim,BirimFiyat);
                        allIngredients.Add(malzeme);

                        // Yeni bir Label oluştur ve özelliklerini ayarla
                        Label malzemeLabel = new Label
                        {
                            Text = $"{malzemeAdi}",
                            AutoSize = true,
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            Margin = new Padding(10),
                            BackColor = Color.FromArgb(255, 238, 173) // İlk arka plan rengi kırmızı
                        };

                        // Click olayını bağla
                        malzemeLabel.Click += (s, e) => MalzemeLabel_Click(malzemeLabel);

                        // Label'i ingredientsPanel'e ekle
                        ingredientsPanel.Controls.Add(malzemeLabel);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        private void MalzemeLabel_Click(Label clickedLabel)
        {
            string malzemeAdi = clickedLabel.Text;

            // Malzeme listesinde label'daki adı kullanarak ilgili malzemeyi bul
            Malzeme selectedMalzeme = allIngredients.FirstOrDefault(m => m.MalzemeAdi == malzemeAdi);

            if (selectedMalzeme != null)
            {
                // Label'in rengini değiştir ve listeye ekle veya çıkar
                if (clickedLabel.BackColor == Color.FromArgb(255, 238, 173))
                {
                    clickedLabel.BackColor = Color.Green;
                    if (!selectedIngredients.Contains(selectedMalzeme))
                    {
                        selectedIngredients.Add(selectedMalzeme);
                    }
                }
                else
                {
                    clickedLabel.BackColor = Color.FromArgb(255, 238, 173);
                    selectedIngredients.Remove(selectedMalzeme);
                }

                ingredientsPanel.Controls.SetChildIndex(clickedLabel, 0);
                FilterRecipesByIngredients();
            }
        }

        /*private void FilterRecipesByIngredients()
        {
            currentRecipes.Clear();

            if (selectedIngredients.Count == 0)
            {
                // Hiçbir malzeme seçilmemişse tüm tarifleri göster
                currentRecipes.AddRange(allRecipes);
                LoadTariflerFromList();
                return;
            }

            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Seçilen malzemeleri içeren tarifleri bulmak için SQL sorgusu
                    string query = $@"
                SELECT t.TarifID, t.TarifAdi, t.Kategori, t.HazirlamaSuresi, t.Talimatlar, t.TarifResmi
                FROM Tarifler t
                JOIN TarifMalzeme tm ON t.TarifID = tm.TarifID
                JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
                WHERE m.MalzemeAdi IN ({string.Join(",", selectedIngredients.Select((_, i) => $"@MalzemeAdi{i}"))})
                    ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Her malzemeyi parametre olarak ekleyelim
                        for (int i = 0; i < selectedIngredients.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@MalzemeAdi{i}", selectedIngredients[i]);
                        }
                        command.Parameters.AddWithValue("@SelectedIngredientsCount", selectedIngredients.Count);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            Tarif tarif = new Tarif(
                                (int)reader["TarifID"],
                                reader["TarifAdi"].ToString(),
                                reader["Kategori"].ToString(),
                                reader["HazirlamaSuresi"].ToString(),
                                reader["Talimatlar"].ToString(),
                                reader["TarifResmi"] as byte[]
                            );

                            currentRecipes.Add(tarif);
                        }
                        reader.Close();
                    }

                    // Seçilen malzemelere uygun tarifleri göster
                    LoadTariflerFromList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }*/


        private void FilterRecipesByIngredients()
        {
            currentRecipes.Clear();

            if (selectedIngredients.Count == 0)
            {
                
                currentRecipes.AddRange(allRecipes);
                LoadTariflerFromList();
                return;
            } else
            {
                currentRecipes = dbengine.getRecipeListByIngredients(selectedIngredients);
            }


            LoadTariflerFromList();
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

        private void LoadTariflerFromList()
        {
            recipesPanel.Controls.Clear();
            recipesPanel.AutoScroll = true;
            recipesPanel.FlowDirection = FlowDirection.TopDown;
            recipesPanel.WrapContents = false;

            foreach (Tarif tarif in currentRecipes)
            {
                Panel tarifPanel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Height = 170, // Butonlar için ekstra yükseklik ekledik
                    Padding = new Padding(10),
                    AutoSize = false,
                    Width = recipesPanel.ClientSize.Width - recipesPanel.Padding.Horizontal,
                    BackColor = tarif.HasMissingIngredients ? Color.Red : Color.Green
                };

                Label tarifAdiLabel = new Label
                {
                    Text = $"Tarif: {tarif.TarifAdi}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                Label kategoriLabel = new Label
                {
                    Text = $"Kategori: {tarif.Kategori}",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                Label hazirlanmaSuresiLabel = new Label
                {
                    Text = $"Hazırlanma Süresi: {tarif.HazirlamaSuresi} dakika",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                Label toplamMaliyetLabel = new Label
                {
                    Text = "Toplam Maliyet: " + dbengine.getTotalPrice(tarif.TarifID.ToString()) + " PLN",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                Label matchingPercentageLabel = new Label
                {
                    Text = $"Eşleşme Yüzdesi: {tarif.MatchingPercentage:F2}%", // Yüzdeyi göster
                    AutoSize = true,
                    Font = new Font("Segoe UI", 12)
                };

                // Tarifi Göster butonu
                Button showRecipeButton = new Button
                {
                    Text = "Tarifi Göster",
                    Tag = tarif.TarifID,
                    AutoSize = true,
                    Height = 40,
                    Width = 125,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                showRecipeButton.Click += ShowRecipeButton_Click;

                // Tarifi Güncelle butonu
                Button updateRecipeButton = new Button
                {
                    Text = "Tarifi Güncelle",
                    Tag = tarif.TarifID,
                    AutoSize = true,
                    Height = 40,
                    Width = 125,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };
                updateRecipeButton.Click += updateRecipeButton_Click;

                // Tüm bileşenleri tarife paneline ekleyelim
                tarifPanel.Controls.Add(tarifAdiLabel);
                tarifPanel.Controls.Add(kategoriLabel);
                tarifPanel.Controls.Add(hazirlanmaSuresiLabel);
                tarifPanel.Controls.Add(toplamMaliyetLabel);
                tarifPanel.Controls.Add(matchingPercentageLabel);
                tarifPanel.Controls.Add(showRecipeButton);
                tarifPanel.Controls.Add(updateRecipeButton);

                // Konumları ayarlayalım
                tarifAdiLabel.Location = new Point(10, 10);
                kategoriLabel.Location = new Point(10, 40);
                hazirlanmaSuresiLabel.Location = new Point(10, 70);
                toplamMaliyetLabel.Location = new Point(10, 100);
                matchingPercentageLabel.Location = new Point(10, 130);
                showRecipeButton.Location = new Point(tarifPanel.Width - 220, 45);
                updateRecipeButton.Location = new Point(tarifPanel.Width - 220, 95);

                // Paneli ekleyelim
                recipesPanel.Controls.Add(tarifPanel);

                // Panel genişliği güncellemesi
                recipesPanel.Resize += (s, e) =>
                {
                    tarifPanel.Width = recipesPanel.ClientSize.Width - recipesPanel.Padding.Horizontal;
                };
            }
        }

        // ShowRecipeButton_Click ve UpdateRecipeButton_Click event metodlarını eklemeyi unutmayın.





        private void LoadTarifler()
        {
            
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            string query = "SELECT * FROM Tarifler";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Tarif tarif = new Tarif((int)reader["TarifID"], reader["TarifAdi"].ToString(), reader["Kategori"].ToString(), reader["HazirlamaSuresi"].ToString(), reader["Talimatlar"].ToString(), reader["TarifResmi"] as byte[]);
                    
                    allRecipes.Add(tarif);
                    currentRecipes.Add(tarif);
                    
                }
            }

            LoadTariflerFromList();
                
            
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
            filterCbox.Visible = true;
            filterCbox.SelectedIndex = 0;
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

    

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBar.Text;



            if (!string.IsNullOrEmpty(searchText))
            {

                currentRecipes.Clear();

                foreach (Tarif tarif in allRecipes)
                {

                    if (tarif.TarifAdi.ToLower().Contains(searchText.ToLower()))
                    {
                        currentRecipes.Add(tarif);
                    }
                }

            }
            else
            {
                currentRecipes.Clear();
                foreach (Tarif tarif in allRecipes)
                {
                    currentRecipes.Add(tarif);
                }
            }

            LoadTariflerFromList();

        }

        private void filterCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortRecipes();
            LoadTariflerFromList();
        }

        private void SortRecipes()
        {
            switch (filterCbox.SelectedItem.ToString())
            {
                case "Fiyata Göre Artan":
                    currentRecipes = currentRecipes.OrderBy(r => float.Parse(dbengine.getTotalPrice(r.TarifID.ToString()))).ToList();
                    break;
                case "Fiyata Göre Azalan":
                    currentRecipes = currentRecipes.OrderByDescending(r => float.Parse(dbengine.getTotalPrice(r.TarifID.ToString()))).ToList();
                    break;
                case "İsme Göre(A-Z)":
                    currentRecipes = currentRecipes.OrderBy(r => r.TarifAdi).ToList();
                    break;
                case "İsme Göre(Z-A)":
                    currentRecipes = currentRecipes.OrderByDescending(r => r.TarifAdi).ToList();
                    break;
                case "Kategoriye Göre":
                    currentRecipes = currentRecipes.OrderBy(r => r.Kategori).ToList();
                    break;
                case "Hazırlama Süresine Göre":
                    currentRecipes = currentRecipes.OrderBy(r => float.Parse(r.HazirlamaSuresi)).ToList();
                    break;
                default:
                    break;
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            LoadTarifler();
            LoadIngredientsPanel();
        }

        /*Fiyata Göre Artan
        Fiyata Göre Azalan
        İsme Göre(A-Z)
        İsme Göre(Z-A)
        Kategoriye Göre*/
    }
}

/**/