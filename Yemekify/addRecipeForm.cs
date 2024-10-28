using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        public static List<Malzeme> addedIngredients;
        public string fromWhere = "nothing";
        public string currentTarifId;

        public string imageLocation = "";

        float olusanFiyat = 0;
        



        private void addIngredient_Click(object sender, EventArgs e)
        {
            addIngredint ai = new addIngredint();
            ai.Show();

        }

        private void addRecipeButton_Click(object sender, EventArgs e)
        {
            string tarifAdi = recipeName.Text;
            string kategori = categoryCbox.Text;
            int hazirlanmaSuresi = int.Parse(prepareTime.Text);
            string tarifYapilis = recipeTextBox.Text;
            byte[] imageBytes = ImageToByteArray(selectedImage.Image);

            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Tarifler WHERE TarifAdi = @TarifAdi";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0 && fromWhere.Equals("fromAddRecipe")) 
                        {
                            MessageBox.Show("Bu tarif zaten mevcut. Farklı bir tarif adı deneyin.", "Tarif Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (fromWhere.Equals("fromAddRecipe"))
                    {
                        string insq = "INSERT INTO Tarifler (TarifAdi, Kategori, HazirlamaSuresi, Talimatlar, TarifResmi) VALUES (@TarifAdi, @Kategori, @HazirlamaSuresi, @Talimatlar, @TarifResmi); SELECT SCOPE_IDENTITY();";

                        using (SqlCommand command = new SqlCommand(insq, connection))
                        {
                            command.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                            command.Parameters.AddWithValue("@Kategori", kategori);
                            command.Parameters.AddWithValue("@HazirlamaSuresi", hazirlanmaSuresi);
                            command.Parameters.AddWithValue("@Talimatlar", tarifYapilis);
                            command.Parameters.AddWithValue("@TarifResmi", imageBytes);

                            int tarifID = Convert.ToInt32(command.ExecuteScalar());

                            AddOrUpdateIngredients(tarifID);
                        }
                    }
                    else if (fromWhere.Equals("update"))
                    {
                        string updq = "UPDATE Tarifler SET TarifAdi = @TarifAdi, Kategori = @Kategori, HazirlamaSuresi = @HazirlamaSuresi, Talimatlar = @Talimatlar, TarifResmi = @TarifResmi WHERE TarifID = @TarifID";

                        using (SqlCommand command = new SqlCommand(updq, connection))
                        {
                            command.Parameters.AddWithValue("@TarifAdi", tarifAdi);
                            command.Parameters.AddWithValue("@Kategori", kategori);
                            command.Parameters.AddWithValue("@HazirlamaSuresi", hazirlanmaSuresi);
                            command.Parameters.AddWithValue("@Talimatlar", tarifYapilis);
                            command.Parameters.AddWithValue("@TarifResmi", imageBytes);
                            command.Parameters.AddWithValue("@TarifID", currentTarifId);

                            command.ExecuteNonQuery();

                            string deleteQ = "DELETE FROM TarifMalzeme WHERE TarifID = @TarifID";

                            using (SqlCommand deleteCommand = new SqlCommand(deleteQ, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@TarifID", currentTarifId);
                                deleteCommand.ExecuteNonQuery();
                            }

                            AddOrUpdateIngredients(Convert.ToInt32(currentTarifId));
                        }
                    }

                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }


        private void AddOrUpdateIngredients(int tarifID)
        {
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();

                    for (int i = 0; i < addedIngredientsGridView.Rows.Count; i++)
                    {
                        string malzemeId = addedIngredientsGridView.Rows[i].Cells["addedMalzemeId"].Value?.ToString() ?? string.Empty;
                        string malzemeBirim = addedIngredientsGridView.Rows[i].Cells["addedMalzemeBirim"].Value?.ToString() ?? string.Empty;
                        string eklenenMiktarStr = addedIngredientsGridView.Rows[i].Cells["addedEklenenMiktar"].Value?.ToString() ?? string.Empty;


                        if (!string.IsNullOrEmpty(malzemeId) && !string.IsNullOrEmpty(eklenenMiktarStr))
                        {
                            float eklenenMiktar = float.Parse(eklenenMiktarStr);
                            float eklenenMiktarToBeChecked = eklenenMiktar;

                            if(malzemeBirim.Equals("Mililitre") || malzemeBirim.Equals("Gram"))
                            {
                                eklenenMiktarToBeChecked /= 1000;
                            }

                            string miktarQ = "SELECT ToplamMiktar FROM Malzemeler WHERE MalzemeID = @MalzemeID";

                            using (SqlCommand checkCommand = new SqlCommand(miktarQ, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@MalzemeID", malzemeId);

                                SqlDataReader reader = checkCommand.ExecuteReader();

                                while (reader.Read())
                                {
                                    float mevcutMiktar = float.Parse(reader["ToplamMiktar"].ToString());

                                    if (eklenenMiktarToBeChecked > mevcutMiktar)
                                    {
                                        MessageBox.Show($"Yetersiz stok: {mevcutMiktar} birim mevcut.");
                                        return;
                                    }
                                }

                                reader.Close();
                            }
                            

                            string eklenenMiktarToDb = "";

                            if (malzemeBirim.Equals("Mililitre") || malzemeBirim.Equals("Gram"))
                            {
                                eklenenMiktarToDb = (eklenenMiktar / 1000).ToString();
                            }
                            else
                            {
                                eklenenMiktarToDb = eklenenMiktar.ToString();
                            }

                            string insertQ = "INSERT INTO TarifMalzeme (TarifID, MalzemeID, MalzemeMiktar) VALUES (@TarifID, @MalzemeID, @MalzemeMiktar)";
                            
                            using (SqlCommand ingredientCommand = new SqlCommand(insertQ, connection))
                            {
                                
                                ingredientCommand.Parameters.AddWithValue("@TarifID", tarifID);
                                ingredientCommand.Parameters.AddWithValue("@MalzemeID", malzemeId);
                                ingredientCommand.Parameters.AddWithValue("@MalzemeMiktar", eklenenMiktarToDb);

                                ingredientCommand.ExecuteNonQuery();
                            }


                            string updateQ = "UPDATE Malzemeler SET ToplamMiktar = CAST(ToplamMiktar AS FLOAT) - @EklenenMiktar WHERE MalzemeID = @MalzemeID";
                            using (SqlCommand updateStockCommand = new SqlCommand(updateQ, connection))
                            {

                                updateStockCommand.Parameters.AddWithValue("@EklenenMiktar", float.Parse(eklenenMiktarToDb));
                                updateStockCommand.Parameters.AddWithValue("@MalzemeID", malzemeId);
                                updateStockCommand.ExecuteNonQuery();
                            }


                        }
                    }

                } catch (Exception ex)
                {
                    MessageBox.Show("HATA : " + ex);
                }
            }
                
        }


        private void LoadIngredients(string tarifId)
        {
            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            string query = @"
            SELECT tm.MalzemeMiktar, m.MalzemeBirim, m.MalzemeAdi, m.MalzemeID, m.BirimFiyat
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

                    addedIngredientsGridView.Rows.Clear(); 

                    while (reader.Read())
                    {

                        float miktar = float.Parse(reader["MalzemeMiktar"].ToString());
                        string birim = reader["MalzemeBirim"].ToString();
                        string malzemeAdi = reader["MalzemeAdi"].ToString();
                        string malzemeId = reader["MalzemeID"].ToString();
                        float birimFiyat = float.Parse(reader["BirimFiyat"].ToString());

                        olusanFiyat += birimFiyat * miktar;

                        addedIngredientsGridView.Rows.Add(malzemeId, malzemeAdi, miktar, birim, birimFiyat*miktar);


                       
                    }
                    totalPriceLabel.Text = olusanFiyat + " PLN";
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata : " + ex.Message);
                }
            }
        }



        private void addRecipeForm_Load(object sender, EventArgs e)
        {
            
            allIngredients = new List<Malzeme>();
            currentIngredients = new List<Malzeme>();
            addedIngredients = new List<Malzeme>();


            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
            string query = "SELECT MalzemeId, MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat FROM Malzemeler";

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
                    ingredientsGridView.Rows.Add(malzeme.MalzemeID, malzeme.MalzemeAdi, malzeme.ToplamMiktar, malzeme.MalzemeBirim, malzeme.BirimFiyat);
                }

            if (fromWhere.Equals("update"))
            {
                addRecipeButton.Text = "Tarifi Düzenle";
                query = "SELECT * FROM Tarifler WHERE TarifID = @TarifID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {   

                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("TarifID", currentTarifId);
                            SqlDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                recipeName.Text = reader["TarifAdi"].ToString();
                                prepareTime.Text = reader["HazirlamaSuresi"].ToString();
                                recipeTextBox.Text = reader["Talimatlar"].ToString();
                                selectedImage.Image = dbengine.ByteArrayToImage(reader["TarifResmi"] as byte[]);

                                string kategori = reader["Kategori"].ToString();
                                categoryCbox.SelectedItem = kategori;
                            }

                            
                        }
                        LoadIngredients(currentTarifId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Veri çekme sırasında hata: " + ex.Message);
                    }
                } 
            
            }
            
            
        }
       


        private void deleteSelectedIngredient_Click(object sender, EventArgs e)
        {
            if (addedIngredientsGridView.SelectedRows.Count > 0)
            {
                
                int selectedIndex = addedIngredientsGridView.SelectedRows[0].Index;

               
                int selectedMalzemeID = Convert.ToInt32(addedIngredientsGridView.SelectedRows[0].Cells["addedMalzemeId"].Value.ToString());
                float addedOlusanFiyat = float.Parse(addedIngredientsGridView.SelectedRows[0].Cells["addedOlusanFiyat"].Value.ToString());



                var itemToRemove = allIngredients.FirstOrDefault(m => m.MalzemeID == selectedMalzemeID);
                if (itemToRemove != null)
                {
                    addedIngredientsGridView.Rows.RemoveAt(selectedIndex);
                    olusanFiyat -= addedOlusanFiyat;
                    totalPriceLabel.Text = (float.Parse(totalPriceLabel.Text.Replace(" PLN",string.Empty))-addedOlusanFiyat) + " PLN";
                }
            }
            else
            {
                MessageBox.Show("Satır Seçin!");
            }
        }

        private void addIngredientToDown_Click(object sender, EventArgs e)
        {
            if (ingredientsGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = ingredientsGridView.SelectedRows[0];

                int malzemeId = Convert.ToInt32(selectedRow.Cells["MalzemeId"].Value);
                string malzemeAdi = selectedRow.Cells["MalzemeAdi"].Value.ToString();
                string malzemeBirim = typeOfIngredientCbox.Text;

                foreach (DataGridViewRow row in addedIngredientsGridView.Rows)
                {
                    if (Convert.ToInt32(row.Cells["addedMalzemeId"].Value) == malzemeId)
                    {
                        MessageBox.Show("Bu malzeme zaten eklendi. Önce mevcut malzemeyi silin veya düzenleyin.", "Malzeme Zaten Ekli", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                float birimFiyat = float.Parse(Convert.ToDecimal(selectedRow.Cells["BirimFiyat"].Value).ToString());
                float malzemeFiyati = 0;

                float eklenenMiktar = 0;
                if (!float.TryParse(amountTextBox.Text, out eklenenMiktar) || eklenenMiktar <= 0)
                {
                    MessageBox.Show("Lütfen geçerli bir miktar girin.");
                    return;
                }

                string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string quantityCheck = "SELECT ToplamMiktar FROM Malzemeler WHERE MalzemeID = @MalzemeID";
                    using (SqlCommand cmd = new SqlCommand(quantityCheck, connection))
                    {
                        cmd.Parameters.AddWithValue("@MalzemeID", malzemeId);
                        float mevcutMiktar = (float)Convert.ToDouble(cmd.ExecuteScalar());

                        float eklenenMiktarKontrol = eklenenMiktar;

                        if (malzemeBirim.Equals("Mililitre") || malzemeBirim.Equals("Gram"))
                        {
                            eklenenMiktarKontrol /= 1000;
                        }

                        if (eklenenMiktarKontrol > mevcutMiktar)
                        {
                            MessageBox.Show($"Depoda yetersiz miktar var: Mevcut miktar {mevcutMiktar} {malzemeBirim}.", "Stok Yetersiz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                if (typeOfIngredientCbox.Text.Equals("Mililitre") || typeOfIngredientCbox.Text.Equals("Gram"))
                {
                    malzemeFiyati = eklenenMiktar * birimFiyat / 1000;
                }
                else
                {
                    malzemeFiyati = eklenenMiktar * birimFiyat;
                }

                olusanFiyat += malzemeFiyati;
                totalPriceLabel.Text = olusanFiyat + " PLN";

                addedIngredientsGridView.Rows.Add(malzemeId, malzemeAdi, eklenenMiktar, typeOfIngredientCbox.Text, malzemeFiyati);
            }
            else
            {
                MessageBox.Show("Lütfen malzemeyi seçin.");
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


        private void ingredientsGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ingredientsGridView.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = ingredientsGridView.SelectedRows[0];

                string malzemeBirim = (string)selectedRow.Cells["MalzemeBirim"].Value;

                typeOfIngredientCbox.SelectedIndex = -1;
                typeOfIngredientCbox.Items.Clear();
                

                if (malzemeBirim.Equals("Kilogram") || malzemeBirim.Equals("Gram"))
                {
                    
                    typeOfIngredientCbox.Items.Add("Kilogram");
                    typeOfIngredientCbox.Items.Add("Gram");
                } else if (malzemeBirim.Equals("Litre") || malzemeBirim.Equals("Mililitre"))
                {
                    typeOfIngredientCbox.Items.Add("Litre");
                    typeOfIngredientCbox.Items.Add("Mililitre");
                } else
                {
                    typeOfIngredientCbox.Items.Add("Adet");

                }
            }
            else
            {
                //selectedIngredientLabel.Text = "Seçilen Malzeme Yok";
            }
        }

        private void selectedImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageLocation = openFileDialog.FileName;
                selectedImage.ImageLocation = imageLocation;
            } else
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); 
                return ms.ToArray();
            }
        }

    }
}
