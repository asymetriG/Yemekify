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
    public partial class addNewIngredientForm : Form
    {
        public addNewIngredientForm()
        {
            InitializeComponent();
        }

        private void addIngredientButton_Click(object sender, EventArgs e)
        {
            string ingredientNameToDb = ingredientName.Text;
            string totalAmountToDb = totalAmount.Text;
            string inredientTypeToDb = ingredientTypeCbox.SelectedItem.ToString();
            double typePriceToDb = double.Parse(typePrice.Text);

            string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string insertIngredientQuery = "INSERT INTO Malzemeler (MalzemeAdi, ToplamMiktar, MalzemeBirim, BirimFiyat) VALUES (@MalzemeAdi, @ToplamMiktar, @MalzemeBirim, @BirimFiyat)";

                    using (SqlCommand command = new SqlCommand(insertIngredientQuery, connection))
                    {
                       
                        command.Parameters.AddWithValue("@MalzemeAdi", ingredientNameToDb);
                        command.Parameters.AddWithValue("@ToplamMiktar", totalAmountToDb);
                        command.Parameters.AddWithValue("@MalzemeBirim", inredientTypeToDb);
                        command.Parameters.AddWithValue("@BirimFiyat", typePriceToDb);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Malzeme başarıyla kaydedildi!");
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

        }

        private void addNewIngredientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
