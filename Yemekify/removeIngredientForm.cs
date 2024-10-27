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
    public partial class removeIngredientForm : Form
    {
        public removeIngredientForm()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
        public static List<Malzeme> currentIngredients;
        public static List<Malzeme> allIngredients;

        private void toBeAddedAmountTextBox_TextChanged(object sender, EventArgs e)
        {

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

        private void removeIngredientForm_Load(object sender, EventArgs e)
        {
            string query = "SELECT MalzemeId, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat FROM Malzemeler";

            currentIngredients = new List<Malzeme>();
            allIngredients = new List<Malzeme>();

            // SqlConnection kullanarak bağlantı oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // SqlCommand oluştur
                    SqlCommand command = new SqlCommand(query, connection);

                    // SqlDataReader kullanarak verileri çek
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

        private void removeIngredientButton_Click(object sender, EventArgs e)
        {
            if (ingredientsGridView.SelectedRows.Count > 0)
            {
                // Seçili satırdaki verileri al
                DataGridViewRow selectedRow = ingredientsGridView.SelectedRows[0];

                int malzemeId = Convert.ToInt32(selectedRow.Cells["MalzemeId"].Value);
                decimal mevcutMiktar = Convert.ToDecimal(selectedRow.Cells["ToplamMiktar"].Value);

                // Girilen çıkarılacak miktarı al
                decimal silinecekMiktar = 0;
                if (!decimal.TryParse(toBeAddedAmountTextBox.Text, out silinecekMiktar) || silinecekMiktar <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin.");
                    return;
                }

                // Miktarın 0'dan düşük olmaması için kontrol
                if (silinecekMiktar > mevcutMiktar)
                {
                    MessageBox.Show("Çıkarılacak miktar mevcut miktardan fazla olamaz.");
                    return;
                }

                // Yeni miktarı hesapla
                decimal yeniMiktar = mevcutMiktar - silinecekMiktar;

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
                MessageBox.Show("Lütfen çıkarmak istediğiniz malzemeyi seçin.");
            }
        }

    }
}
