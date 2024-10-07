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
    public partial class addIngredientForm : Form
    {
        private bool isNewPageOpened = false;
        public addIngredientForm()
        {
            InitializeComponent();
        }

        private void refreshIngredients()
        {
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // SQL sorgusunu tanımlayın.
                    string query = "SELECT MalzemeID, MalzemeAdi FROM Malzemeler";

                    // SqlCommand ile sorguyu çalıştırın.
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // SqlDataReader ile verileri okuyun.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // ComboBox1'i temizle
                            ingredientsCbox.Items.Clear();

                            // Verileri oku ve ComboBox'a ekle
                            while (reader.Read())
                            {
                                // Veritabanından MalzemeAdi'ni okuyup ComboBox'a ekliyoruz
                                string malzemeAdi = reader["MalzemeAdi"].ToString();
                                ingredientsCbox.Items.Add(malzemeAdi);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }


        private void addIngredientForm_Load(object sender, EventArgs e)
        {
            refreshIngredients();
            ingredientsCbox.SelectedIndex = -1;
        }

        private void addNewIngredientRecipe_Click(object sender, EventArgs e)
        {
            isNewPageOpened = true;
            addNewIngredientForm _addNewIngredientForm = new addNewIngredientForm();
            _addNewIngredientForm.Show();
        }

        private void addIngredientForm_MouseClick(object sender, MouseEventArgs e)
        {
            if(isNewPageOpened)
            {
                refreshIngredients();
                isNewPageOpened= false;
            }
            
        }

        private void ingredientsCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // SQL sorgusunu tanımlayın.
                    string query = "SELECT MalzemeID, MalzemeBirim FROM Malzemeler WHERE MalzemeAdi = @malzemeAdi";

                    // SqlCommand ile sorguyu çalıştırın.
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ingredientsCbox.SelectedItem kullanarak doğru seçimi alıyoruz
                        command.Parameters.AddWithValue("@malzemeAdi", ingredientsCbox.SelectedItem.ToString());

                        // SqlDataReader ile verileri okuyun.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string malzemeBirim = reader["MalzemeBirim"].ToString();
                                amountLabel.Text = malzemeBirim;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }


        private void ingredientsCbox_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void addIngredientToRecipeButton_Click(object sender, EventArgs e)
        {

            string ingredientName = ingredientsCbox.SelectedItem.ToString();
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // Bağlantıyı aç

                    // SQL sorgusunu tanımlayın.
                    string query = "SELECT * FROM Malzemeler WHERE MalzemeAdi = @malzemeAdi";

                    // SqlCommand ile sorguyu çalıştırın.
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // ingredientsCbox.SelectedItem kullanarak doğru seçimi alıyoruz
                        command.Parameters.AddWithValue("@malzemeAdi", ingredientName);

                        // SqlDataReader ile verileri okuyun.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string MalzemeID = reader["MalzemeID"].ToString();
                                string MalzemeAdi = reader["MalzemeAdi"].ToString();
                                int toplamMiktar = int.Parse(amountTextBox.Text);
                                string MalzemeBirim = reader["MalzemeBirim"].ToString();
                                double BirimFiyat = double.Parse(reader["BirimFiyat"].ToString());

                                int eldekiMiktar = int.Parse(reader["ToplamMiktar"].ToString());

                                if (toplamMiktar>eldekiMiktar)
                                {
                                    MessageBox.Show("Elimizde Yok");
                                } else
                                {
                                    Malzeme malzeme = new Malzeme(MalzemeID, MalzemeAdi, amountTextBox.Text, MalzemeBirim, BirimFiyat);
                                    addRecipeForm.ingredients.Add(malzeme);
                                    MessageBox.Show("Tarife Eklendi");
                                    this.Hide();
                                }

                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata durumunda mesaj göster
                    MessageBox.Show("Veritabanı bağlantı hatası: " + ex.Message);
                }
                finally
                {
                    // Bağlantıyı kapat
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

            
        }
    }
}
