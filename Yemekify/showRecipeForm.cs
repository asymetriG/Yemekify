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
    public partial class showRecipeForm : Form
    {
        public string TarifID;
        public Tarif tarif;
        public showRecipeForm()
        {
            InitializeComponent();
        }

        private void showRecipeForm_Load(object sender, EventArgs e)
        {
            tarif = dbengine.getTarifById(TarifID);
            recipeNameLabel.Text = tarif.TarifAdi + " (" + tarif.Kategori + ")";
            
            recipeImagePictureBox.Image = dbengine.ByteArrayToImage(tarif.imageBytes);

            LoadIngredients(TarifID);

            totalPriceLabel.Text ="Toplam Maliyet: " + dbengine.getTotalPrice(TarifID) + " PLN";
            prepareTimeLabel.Text = "Hazırlanma Süresi: " + tarif.HazirlamaSuresi +" dakika";

            recipeInstructionsTextBox.Text = tarif.Talimatlar.ToString();


        }

        private void LoadIngredients(string tarifId)
        {
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            string query = @"
            SELECT tm.MalzemeMiktar, m.MalzemeBirim, m.MalzemeAdi
            FROM TarifMalzeme tm
            JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
            WHERE tm.TarifID = @TarifID;
        ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    ingredientsListBox.Items.Clear();


                    while (reader.Read())
                    {

                        float miktar = float.Parse(reader["MalzemeMiktar"].ToString()); 
                        string birim = reader["MalzemeBirim"].ToString(); 
                        string malzemeAdi = reader["MalzemeAdi"].ToString(); 

                        
                        string item = $"{miktar} {birim} {malzemeAdi}";
                        ingredientsListBox.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void removeRecipeButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            DialogResult dialogResult = MessageBox.Show("Bu tarifi silmek istediğinize emin misiniz?", "Tarifi Sil", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        List<(int MalzemeID, float MalzemeMiktar, float MevcutMiktar)> malzemeListesi = new List<(int, float, float)>();

                        string selectIngredientsQuery = @"
                    SELECT tm.MalzemeID, tm.MalzemeMiktar, m.ToplamMiktar
                    FROM TarifMalzeme tm
                    JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
                    WHERE tm.TarifID = @TarifID;
                ";

                        using (SqlCommand selectCommand = new SqlCommand(selectIngredientsQuery, connection))
                        {
                            selectCommand.Parameters.AddWithValue("@TarifID", TarifID);
                            SqlDataReader reader = selectCommand.ExecuteReader();

                            while (reader.Read())
                            {
                                int malzemeId = Convert.ToInt32(reader["MalzemeID"]);
                                float malzemeMiktar = float.Parse(reader["MalzemeMiktar"].ToString());
                                float mevcutMiktar = float.Parse(reader["ToplamMiktar"].ToString());
                                malzemeListesi.Add((malzemeId, malzemeMiktar, mevcutMiktar));
                            }
                            reader.Close();
                        }

                        foreach (var malzeme in malzemeListesi)
                        {
                            string updateStockQuery = "UPDATE Malzemeler SET ToplamMiktar = @YeniMiktar WHERE MalzemeID = @MalzemeID";
                            using (SqlCommand updateCommand = new SqlCommand(updateStockQuery, connection))
                            {
                                float yeniMiktar = malzeme.MevcutMiktar + malzeme.MalzemeMiktar;
                                updateCommand.Parameters.AddWithValue("@YeniMiktar", yeniMiktar);
                                updateCommand.Parameters.AddWithValue("@MalzemeID", malzeme.MalzemeID);
                                updateCommand.ExecuteNonQuery();
                            }
                        }

                        string deleteIngredientsQuery = "DELETE FROM TarifMalzeme WHERE TarifID = @TarifID";
                        using (SqlCommand deleteIngredientsCommand = new SqlCommand(deleteIngredientsQuery, connection))
                        {
                            deleteIngredientsCommand.Parameters.AddWithValue("@TarifID", TarifID);
                            deleteIngredientsCommand.ExecuteNonQuery();
                        }

                        string deleteRecipeQuery = "DELETE FROM Tarifler WHERE TarifID = @TarifID";
                        using (SqlCommand deleteRecipeCommand = new SqlCommand(deleteRecipeQuery, connection))
                        {
                            deleteRecipeCommand.Parameters.AddWithValue("@TarifID", TarifID);
                            deleteRecipeCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show("Tarif ve malzemeleri başarıyla silindi. Malzemeler stoğa geri eklendi.");

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Silme işlemi iptal edildi.");
            }
        }


    }
}
