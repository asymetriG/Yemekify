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
    public partial class addNewIngredient : Form
    {
        public addNewIngredient()
        {
            InitializeComponent();
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            string malzemeAdi = ingredientNameTextBox.Text;
            string toplamMiktar = totalAmountTextBox.Text;
            string malzemeBirim = typeOfIngredientCbox.Text;
            double birimFiyat = double.Parse(birimFiyatTextBox.Text);

            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkQuery = "SELECT COUNT(*) FROM Malzemeler WHERE MalzemeAdi = @MalzemeAdi";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0) 
                        {
                            MessageBox.Show("Bu malzeme zaten depoda mevcut. Yeni malzeme eklemek için farklı bir ad kullanın.", "Malzeme Mevcut", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string queryy = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";
                    using (SqlCommand command = new SqlCommand(queryy, connection))
                    {
                        command.Parameters.AddWithValue("@MalzemeAdi", malzemeAdi);
                        command.Parameters.AddWithValue("@ToplamMiktar", toplamMiktar);
                        command.Parameters.AddWithValue("@MalzemeBirim", malzemeBirim);
                        command.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Malzeme başarıyla kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata : " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void addNewIngredient_Load(object sender, EventArgs e)
        {

        }
    }
}
