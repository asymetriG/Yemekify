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

                    ingredientsListBox.Items.Clear(); // Önce listeyi temizle

                    while (reader.Read())
                    {
                        //MessageBox.Show("dfgdfgs");
                        
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
    }
}
