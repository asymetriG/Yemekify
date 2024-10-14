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

namespace Yemekify
{
    public partial class addRecipeForm : Form
    {
        public addRecipeForm()
        {
            InitializeComponent();
        }

        public static List<Malzeme> allIngredients;
        public static List<Malzeme> currentIngredients;

        private bool isPageChanged = false;

        

        private void addIngredient_Click(object sender, EventArgs e)
        {
            isPageChanged = true;
            addIngredint ai = new addIngredint();
            ai.Show();

        }

        private void recipeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            string tarifAdi = recipeName.Text;
            string kategori = categoryCbox.Text;
            int hazirlanmaSuresi = int.Parse(prepareTime.Text);
            string tarifYapilis = recipeTextBox.Text;

            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Tarifler tablosuna ekleme ve TarifID'yi alma
                    string insertRecipeQuery = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand command = new SqlCommand(insertRecipeQuery, connection))
                    {
                        command.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                        command.Parameters.AddWithValue("@Kategori", kategori);
                        command.Parameters.AddWithValue("@HazirlamaSuresi", hazirlanmaSuresi);
                        command.Parameters.AddWithValue("@Talimatlar", tarifYapilis);

                        // TarifID'yi al
                        int tarifID = Convert.ToInt32(command.ExecuteScalar());

                        // ingredients listesindeki her malzemeyi TarifMalzeme tablosuna ekle ve ToplamMiktar'ı güncelle
                        foreach (Malzeme malzeme in currentIngredients)
                        {
                            // TarifMalzeme tablosuna ekleme
                            string insertIngredientQuery = "INSERT INTO TarifMalzeme (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";

                            using (SqlCommand ingredientCommand = new SqlCommand(insertIngredientQuery, connection))
                            {
                                ingredientCommand.Parameters.AddWithValue("@TarifID", tarifID);
                                ingredientCommand.Parameters.AddWithValue("@MalzemeID", malzeme.MalzemeID);
                                ingredientCommand.Parameters.AddWithValue("@MalzemeMiktar", malzeme.ToplamMiktar); // Burada malzeme miktarını kullanıyoruz.

                                ingredientCommand.ExecuteNonQuery();
                            }

                      
                        }

                     
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }



        private void addRecipeForm_Load(object sender, EventArgs e)
        {
            allIngredients = new List<Malzeme>();
            currentIngredients = new List<Malzeme>();

            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            string query = "SELECT MalzemeId, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat FROM Malzemeler";

            // SqlConnection kullanarak bağlantı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                    
                    SqlCommand command = new SqlCommand(query, connection);

                    
                    SqlDataReader reader = command.ExecuteReader();

                    
                    ingredientsGridView.AutoGenerateColumns = false;

                    
                    ingredientsGridView.Rows.Clear();

                   
                    while (reader.Read())
                    {
                      
                        int MalzemeId = Convert.ToInt32(reader["MalzemeId"]);
                        string MalzemeAdi = (string)reader["MalzemeAdi"];
                        string ToplamMiktar = (string)reader["ToplamMiktar"];
                        string MalzemeBirim = (string)reader["MalzemeBirim"];
                        double BirimFiyat = Convert.ToDouble(reader["BirimFiyat"]);

                        Malzeme malzeme = new Malzeme(MalzemeId, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat);
                        currentIngredients.Add(malzeme);
                        allIngredients.Add(malzeme);

                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme sırasında hata: " + ex.Message);
                }
            }

            foreach (Malzeme malzeme in currentIngredients)
            {
                ingredientsGridView.Rows.Add(malzeme.MalzemeID,malzeme.MalzemeAdi,malzeme.ToplamMiktar,malzeme.MalzemeBirim,malzeme.BirimFiyat);
            }
        }
       

        private void addRecipeForm_MouseClick(object sender, MouseEventArgs e)
        {

        }


        private void deleteSelectedIngredient_Click(object sender, EventArgs e)
        {
            if (addedIngredientsGridView.SelectedRows.Count > 0)
            {
                
                int selectedIndex = addedIngredientsGridView.SelectedRows[0].Index;

               
                int selectedMalzemeID = Convert.ToInt32(addedIngredientsGridView.SelectedRows[0].Cells["MalzemeID"].Value.ToString());

                
                var itemToRemove = allIngredients.FirstOrDefault(m => m.MalzemeID == selectedMalzemeID);
                if (itemToRemove != null)
                {
                    addedIngredientsGridView.Rows.RemoveAt(selectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }

        private void addIngredientToDown_Click(object sender, EventArgs e)
        {
            
            if (ingredientsGridView.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = ingredientsGridView.SelectedRows[0];

                int malzemeId = Convert.ToInt32(selectedRow.Cells["MalzemeId"].Value);
                string malzemeAdi = selectedRow.Cells["MalzemeAdi"].Value.ToString();
                string malzemeBirim = selectedRow.Cells["MalzemeBirim"].Value.ToString();
                decimal birimFiyat = Convert.ToDecimal(selectedRow.Cells["BirimFiyat"].Value);

                
                decimal eklenenMiktar = 0;
                if (!decimal.TryParse(amountTextBox.Text, out eklenenMiktar) || eklenenMiktar <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin.");
                    return;
                }

                
                decimal olusanFiyat = eklenenMiktar * birimFiyat;
                totalPriceLabel.Text = "Toplam Maliyet : " + olusanFiyat + " PLN";



                addedIngredientsGridView.Rows.Add(malzemeId, malzemeAdi, eklenenMiktar, malzemeBirim, olusanFiyat);
            }
            else
            {
                MessageBox.Show("Lütfen tarif için eklemek istediğiniz malzemeyi seçin.");
            }
        }


        private void ingredientSeachBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = ingredientSeachBar.Text;


            if (!string.IsNullOrEmpty(searchText))
            {

                currentIngredients.Clear();
                ingredientsGridView.Rows.Clear();


                foreach (Malzeme malzeme in allIngredients)
                {

                    if (malzeme.MalzemeAdi.ToLower().Contains(searchText.ToLower()))
                    {
                        currentIngredients.Add(malzeme);
                    }
                }

                foreach (Malzeme malzeme1 in currentIngredients)
                {
                    ingredientsGridView.Rows.Add(malzeme1.MalzemeID, malzeme1.MalzemeAdi, malzeme1.ToplamMiktar, malzeme1.MalzemeBirim, malzeme1.BirimFiyat);
                }
            }
            else
            {
                ingredientsGridView.Rows.Clear();
                foreach (Malzeme malzeme1 in allIngredients)
                {
                    
                    ingredientsGridView.Rows.Add(malzeme1.MalzemeID, malzeme1.MalzemeAdi, malzeme1.ToplamMiktar, malzeme1.MalzemeBirim, malzeme1.BirimFiyat);
                }
            }
        }
    }
}
