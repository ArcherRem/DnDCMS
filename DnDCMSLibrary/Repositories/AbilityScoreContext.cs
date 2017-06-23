using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DnDCMSLibrary.Entities;
using DnDCMSLibrary.Interfaces;

namespace DnDCMSLibrary.Repositories
{
    public class AbilityScoreContext : IAbilityScoreRepository
    {
        public List<AbilityScore> GetAbilityScores(int id)
        {
            try
            {
                List<AbilityScore> result = new List<AbilityScore>();
                using (SqlConnection sqlcon = Database.Connection)
                {
                    string query = "SELECT * FROM Character WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(CreateAbilityScoresFromReader(reader));
                            }
                        }
                    }
                    return result;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        private AbilityScore CreateAbilityScoresFromReader(SqlDataReader reader)
        {
            AbilityScore abilityscore = new AbilityScore()
            {
            strength = Convert.ToDecimal(reader["strength"]),
            dexterity = Convert.ToDecimal(reader["dexterity"]),
            constitution = Convert.ToDecimal(reader["constitution"]),
            intelligence = Convert.ToDecimal(reader["intelligence"]),
            wisdom = Convert.ToDecimal(reader["wisdom"]),
            charisma = Convert.ToDecimal(reader["charisma"]),
        };
            return abilityscore;
        }
    }
}
