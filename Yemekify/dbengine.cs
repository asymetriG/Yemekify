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

        public static List<Tarif> getRecipeListByIngredients(List<Malzeme> ingredients)
        {
            List<Tarif> tarifler = new List<Tarif>();
            HashSet<int> addedTarifIds = new HashSet<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT t.TarifID, t.TarifAdi, t.Kategori, t.HazirlamaSuresi, t.Talimatlar, t.TarifResmi, tm.MalzemeID
                         FROM Tarifler t
                         JOIN TarifMalzeme tm ON t.TarifID = tm.TarifID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    Dictionary<int, List<int>> tarifToIngredientsMap = new Dictionary<int, List<int>>();

                    while (reader.Read())
                    {
                        int tarifID = (int)reader["TarifID"];
                        int malzemeID = (int)reader["MalzemeID"];

                        if (!tarifToIngredientsMap.ContainsKey(tarifID))
                        {
                            tarifToIngredientsMap[tarifID] = new List<int>();
                        }
                        tarifToIngredientsMap[tarifID].Add(malzemeID);
                    }
                    reader.Close();

                    foreach (var tarifEntry in tarifToIngredientsMap)
                    {
                        int tarifID = tarifEntry.Key;
                        var tarifIngredients = tarifEntry.Value;

                        // Seçilen malzemeler arasından tarifte olanları bul
                        int matchingIngredientsCount = ingredients.Count(ing => tarifIngredients.Contains(ing.MalzemeID));
                        int selectedIngredientsCount = ingredients.Count; // Seçili malzeme sayısı
                        double matchingPercentage = (double)matchingIngredientsCount / selectedIngredientsCount * 100;

                        bool hasMissingIngredients = matchingIngredientsCount < selectedIngredientsCount;

                        SqlCommand tarifDetailsCommand = new SqlCommand("SELECT * FROM Tarifler WHERE TarifID = @TarifID", connection);
                        tarifDetailsCommand.Parameters.AddWithValue("@TarifID", tarifID);

                        using (SqlDataReader tarifReader = tarifDetailsCommand.ExecuteReader())
                        {
                            if (tarifReader.Read())
                            {
                                Tarif tarif = new Tarif(
                                    tarifID,
                                    tarifReader["TarifAdi"].ToString(),
                                    tarifReader["Kategori"].ToString(),
                                    tarifReader["HazirlamaSuresi"].ToString(),
                                    tarifReader["Talimatlar"].ToString(),
                                    tarifReader["TarifResmi"] != DBNull.Value ? (byte[])tarifReader["TarifResmi"] : null
                                );

                                tarif.HasMissingIngredients = hasMissingIngredients;
                                tarif.MatchingPercentage = matchingPercentage; // Güncellenmiş eşleşme yüzdesini atadık
                                tarifler.Add(tarif);
                            }
                        }
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
                        Console.WriteLine("Belirtilen tarif için maliyet hesaplanamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
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
