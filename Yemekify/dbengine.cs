using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yemekify
{
    public class dbengine
    {

        public static string connectionString = "Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True";


        public static Tarif getTarifById(string id)
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Tarifler WHERE TarifID = @TarifID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("TarifID", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int TarifID = (int)reader["TarifID"];
                        string TarifAdi = (string)reader["TarifAdi"];
                        string Kategori = (string)reader["Kategori"];
                        string HazirlamaSuresi = ((int)reader["HazirlamaSuresi"]).ToString();
                        string Talimatlar = (string)reader["Talimatlar"];
                        byte[] imageBytes = reader["TarifResmi"] as byte[];

                        Tarif tarif = new Tarif(TarifID, TarifAdi, Kategori, HazirlamaSuresi, Talimatlar, imageBytes);
                        return tarif;

                    }
                }
            }

            return null;
        }

        public static List<Tarif> getRecipeListByIngredients(List<Malzeme> selectedIngredients, List<Malzeme> allIngredients)
        {
            List<Tarif> tarifler = new List<Tarif>();
            HashSet<int> addedTarifIds = new HashSet<int>();

            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-5GMENJ9;Initial Catalog=Yemekify;Integrated Security=True"))
            {
                string query = "SELECT t.*, tm.MalzemeID, m.MalzemeAdi FROM Tarifler t " +
                               "LEFT JOIN TarifMalzeme tm ON t.TarifID = tm.TarifID " +
                               "LEFT JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int tarifID = (int)reader["TarifID"];
                        if (!addedTarifIds.Contains(tarifID))
                        {
                            Tarif tarif = new Tarif(
                                tarifID,
                                reader["TarifAdi"].ToString(),
                                reader["Kategori"].ToString(),
                                reader["HazirlamaSuresi"].ToString(),
                                reader["Talimatlar"].ToString(),
                                reader["TarifResmi"] != DBNull.Value ? (byte[])reader["TarifResmi"] : null
                            );

                            tarifler.Add(tarif);
                            addedTarifIds.Add(tarifID);
                        }

                        var currentTarif = tarifler.FirstOrDefault(t => t.TarifID == tarifID);
                        if (currentTarif != null)
                        {
                            int malzemeID = (int)reader["MalzemeID"];
                            string malzemeAdi = reader["MalzemeAdi"].ToString();

                            currentTarif.RequiredIngredients.Add(new Malzeme(malzemeID, malzemeAdi, "0", "", 0));
                        }
                    }
                    reader.Close();

                    foreach (var tarif in tarifler)
                    {
                        var requiredIngredientIds = tarif.RequiredIngredients.Select(m => m.MalzemeID).ToList();

                        int matchingIngredients = selectedIngredients.Count(s => requiredIngredientIds.Contains(s.MalzemeID));
                        int totalRecipeIngredients = requiredIngredientIds.Count;

                        tarif.MatchingPercentage = (matchingIngredients / (float)totalRecipeIngredients) * 100;


                        tarif.MissingIngredients = tarif.RequiredIngredients
                            .Where(ingredient => !selectedIngredients.Any(s => s.MalzemeID == ingredient.MalzemeID))
                            .ToList();


                        tarif.HasMissingIngredients = tarif.MissingIngredients.Any();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return tarifler;
        }





        public static string getTotalPrice(string tarifId)
        {
            string query = @"
                    SELECT SUM(tm.MalzemeMiktar * m.BirimFiyat) AS ToplamMaliyet
                    FROM TarifMalzeme tm
                    JOIN Malzemeler m ON tm.MalzemeID = m.MalzemeID
                    WHERE tm.TarifID = @TarifID
                    GROUP BY tm.TarifID;
                    ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TarifID", tarifId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string toplamMaliyet = result.ToString();
                        return toplamMaliyet;
                    }
                    else
                    {
                        Console.WriteLine("Maliyet hesaplanamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata : " + ex.Message);
                }
            }
            return string.Empty;
        }

        public static Malzeme getMalzemeById(string id)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Malzemeler WHERE MalzemeID = @MalzemeID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("MalzemeID", id);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int MalzemeID = Convert.ToInt32((string)reader["MalzemeID"]);
                        string MalzemeAdi = (string)reader["MalzemeAdi"];
                        string ToplamMiktar = (string)reader["ToplamMiktar"];
                        string MalzemeBirim = (string)reader["MalzemeBirim"];
                        float BirimFiyat = float.Parse((string)reader["Talimatlar"]);

                        Malzeme malzeme = new Malzeme(MalzemeID,MalzemeAdi,ToplamMiktar,MalzemeBirim,BirimFiyat);
                        return malzeme;

                    }
                }
            }

            return null;
        }

        public static System.Drawing.Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

    }

    
}
