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
    public partial class addRecipeForm : Form
    {
        public addRecipeForm()
        {
            InitializeComponent();
        }

        public static List<Malzeme> ingredients;

        private bool isPageChanged = false;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void recipeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prepareTime_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void editSelectedIngredientButton_Click(object sender, EventArgs e)
        {

        }

        private void addIngredient_Click(object sender, EventArgs e)
        {
            isPageChanged = true;
            addIngredientForm addIngredientForm = new addIngredientForm();
            addIngredientForm.ShowDialog();
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
                        foreach (Malzeme malzeme in ingredients)
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
            ingredients = new List<Malzeme>();
        }
       

        private void addRecipeForm_MouseClick(object sender, MouseEventArgs e)
        {
                ingredientsGridView.Rows.Clear();
                double totalPrice = 0;

                foreach (Malzeme malzeme in ingredients)
                {
                    ingredientsGridView.Rows.Add(malzeme.MalzemeID,malzeme.MalzemeAdi, malzeme.ToplamMiktar, malzeme.MalzemeBirim, malzeme.BirimFiyat);
                    totalPrice += int.Parse(malzeme.ToplamMiktar) * malzeme.BirimFiyat;
                }
                totalPriceLabel.Text = "Toplam Maliyet : " + totalPrice.ToString() + " PLN";
                isPageChanged = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void deleteSelectedIngredient_Click(object sender, EventArgs e)
        {
            if (ingredientsGridView.SelectedRows.Count > 0)
            {
                
                int selectedIndex = ingredientsGridView.SelectedRows[0].Index;

               
                string selectedMalzemeID = ingredientsGridView.SelectedRows[0].Cells["MalzemeID"].Value.ToString();

                
                var itemToRemove = ingredients.FirstOrDefault(m => m.MalzemeID == selectedMalzemeID);
                if (itemToRemove != null)
                {
                    ingredients.Remove(itemToRemove);

                    ingredientsGridView.Rows.RemoveAt(selectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }
    }
}
