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
    public partial class addIngredint : Form
    {
        public addIngredint()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
        public static List<Malzeme> currentIngredients;
        public static List<Malzeme> allIngredients;

        private void addIngredint_Load(object sender, EventArgs e)
        {
            
            string query = "SELECT MalzemeId, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat FROM Malzemeler";

            currentIngredients = new List<Malzeme>();
            allIngredients = new List<Malzeme>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    ingredientsGridView.Rows.Clear();

                    
                    while (reader.Read())
                    {

                        ingredientsGridView.Rows.Add(
                            reader["MalzemeId"],
                            reader["MalzemeAdi"],
                            reader["ToplamMiktar"],
                            reader["MalzemeBirim"],
                            reader["BirimFiyat"]
                        );

                        int MalzemeId = Convert.ToInt32(reader["MalzemeId"]);
                        string MalzemeAdi = (string)reader["MalzemeAdi"];
                        string ToplamMiktar = (string)reader["ToplamMiktar"];
                        string MalzemeBirim = (string)reader["MalzemeBirim"];
                        double BirimFiyat = Convert.ToDouble(reader["BirimFiyat"]);

                        Malzeme malzeme = new Malzeme(MalzemeId, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat);
                        allIngredients.Add(malzeme);
                        currentIngredients.Add(malzeme);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekme sırasında hata: " + ex.Message);
                }
            }
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {

            if (ingredientsGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = ingredientsGridView.SelectedRows[0];

                int malzemeId = Convert.ToInt32(selectedRow.Cells["MalzemeId"].Value);
                decimal mevcutMiktar = Convert.ToDecimal(selectedRow.Cells["ToplamMiktar"].Value);

                
                decimal eklenecekMiktar = 0;
                if (!decimal.TryParse(toBeAddedAmountTextBox.Text, out eklenecekMiktar) || eklenecekMiktar <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin.");
                    return;
                }

                
                decimal yeniMiktar = mevcutMiktar + eklenecekMiktar;
;
                string query = "UPDATE Malzemeler SET ToplamMiktar = @YeniMiktar WHERE MalzemeId = @MalzemeId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            
                            command.Parameters.AddWithValue("@YeniMiktar", yeniMiktar);
                            command.Parameters.AddWithValue("@MalzemeId", malzemeId);

                            
                            command.ExecuteNonQuery();
                        }

                        
                        MessageBox.Show("Malzeme miktarı başarıyla güncellendi.");

                        
                        selectedRow.Cells["ToplamMiktar"].Value = yeniMiktar;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen eklemek istediğiniz malzemeyi seçin.");
            }

        }

        private void addNewIngredientButton_Click(object sender, EventArgs e)
        {
            addNewIngredient ani = new addNewIngredient();
            ani.Show();
        }

        private void ingredientsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ingredientsGridView.SelectedRows.Count > 0)
            {
                
                DataGridViewRow selectedRow = ingredientsGridView.SelectedRows[0];

                
                string malzemeAdi = "Seçilen Malzeme : " + (string)selectedRow.Cells["MalzemeAdi"].Value;
                string malzemeBirim = (string)selectedRow.Cells["MalzemeBirim"].Value;

                selectedIngredientLabel.Text = malzemeAdi + " (" + malzemeBirim + ")";
            }
            else
            {
                selectedIngredientLabel.Text = "Seçilen Malzeme Yok";
            }
        }

        private void ingredientTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = ingredientTextBox.Text;


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

        private void ingredientsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


                
    }
}



/*
 var malzemeler = new[]
        {
            new { MalzemeAdi = "Un", ToplamMiktar = 500, MalzemeBirim = "Kilogram", BirimFiyat = 10.50m },
            new { MalzemeAdi = "Şeker", ToplamMiktar = 300, MalzemeBirim = "Kilogram", BirimFiyat = 8.25m },
            new { MalzemeAdi = "Tuz", ToplamMiktar = 150, MalzemeBirim = "Kilogram", BirimFiyat = 3.50m },
            new { MalzemeAdi = "Zeytinyağı", ToplamMiktar = 50, MalzemeBirim = "Litre", BirimFiyat = 35.00m },
            new { MalzemeAdi = "Sıvı Yağ", ToplamMiktar = 75, MalzemeBirim = "Litre", BirimFiyat = 20.00m },
            new { MalzemeAdi = "Domates Salçası", ToplamMiktar = 120, MalzemeBirim = "Kilogram", BirimFiyat = 12.00m },
            new { MalzemeAdi = "Bulgur", ToplamMiktar = 200, MalzemeBirim = "Kilogram", BirimFiyat = 6.75m },
            new { MalzemeAdi = "Pirinç", ToplamMiktar = 220, MalzemeBirim = "Kilogram", BirimFiyat = 9.50m },
            new { MalzemeAdi = "Makarna", ToplamMiktar = 180, MalzemeBirim = "Kilogram", BirimFiyat = 7.00m },
            new { MalzemeAdi = "Yumurta", ToplamMiktar = 120, MalzemeBirim = "Adet", BirimFiyat = 1.25m },
            new { MalzemeAdi = "Süt", ToplamMiktar = 100, MalzemeBirim = "Litre", BirimFiyat = 4.50m },
            new { MalzemeAdi = "Peynir", ToplamMiktar = 75, MalzemeBirim = "Kilogram", BirimFiyat = 35.00m },
            new { MalzemeAdi = "Tereyağı", ToplamMiktar = 50, MalzemeBirim = "Kilogram", BirimFiyat = 40.00m },
            new { MalzemeAdi = "Kaşar Peyniri", ToplamMiktar = 60, MalzemeBirim = "Kilogram", BirimFiyat = 30.00m },
            new { MalzemeAdi = "Patates", ToplamMiktar = 250, MalzemeBirim = "Kilogram", BirimFiyat = 4.00m },
            new { MalzemeAdi = "Soğan", ToplamMiktar = 230, MalzemeBirim = "Kilogram", BirimFiyat = 3.50m },
            new { MalzemeAdi = "Sarımsak", ToplamMiktar = 40, MalzemeBirim = "Kilogram", BirimFiyat = 20.00m },
            new { MalzemeAdi = "Biber", ToplamMiktar = 130, MalzemeBirim = "Kilogram", BirimFiyat = 10.00m },
            new { MalzemeAdi = "Domates", ToplamMiktar = 150, MalzemeBirim = "Kilogram", BirimFiyat = 8.00m },
            new { MalzemeAdi = "Elma", ToplamMiktar = 180, MalzemeBirim = "Kilogram", BirimFiyat = 6.00m },
            new { MalzemeAdi = "Armut", ToplamMiktar = 100, MalzemeBirim = "Kilogram", BirimFiyat = 7.50m },
            new { MalzemeAdi = "Muz", ToplamMiktar = 80, MalzemeBirim = "Kilogram", BirimFiyat = 12.00m },
            new { MalzemeAdi = "Limon", ToplamMiktar = 90, MalzemeBirim = "Kilogram", BirimFiyat = 9.00m },
            new { MalzemeAdi = "Portakal", ToplamMiktar = 110, MalzemeBirim = "Kilogram", BirimFiyat = 6.50m },
            new { MalzemeAdi = "Salatalık", ToplamMiktar = 130, MalzemeBirim = "Kilogram", BirimFiyat = 4.50m },
            new { MalzemeAdi = "Marul", ToplamMiktar = 80, MalzemeBirim = "Adet", BirimFiyat = 2.50m },
            new { MalzemeAdi = "Maydanoz", ToplamMiktar = 70, MalzemeBirim = "Adet", BirimFiyat = 1.75m },
            new { MalzemeAdi = "Nohut", ToplamMiktar = 150, MalzemeBirim = "Kilogram", BirimFiyat = 9.00m },
            new { MalzemeAdi = "Mercimek", ToplamMiktar = 100, MalzemeBirim = "Kilogram", BirimFiyat = 8.75m },
            new { MalzemeAdi = "Fasulye", ToplamMiktar = 140, MalzemeBirim = "Kilogram", BirimFiyat = 10.50m }
        };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var malzeme in malzemeler)
                {
                    
                    string query = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) " +
                                   "VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@MalzemeAdi", malzeme.MalzemeAdi);
                        command.Parameters.AddWithValue("@ToplamMiktar", malzeme.ToplamMiktar);
                        command.Parameters.AddWithValue("@MalzemeBirim", malzeme.MalzemeBirim);
                        command.Parameters.AddWithValue("@BirimFiyat", malzeme.BirimFiyat);

                        
                        command.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Malzemeler başarıyla eklendi!");
            }
 
 */
