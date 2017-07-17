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
    public class ClassContext : IClassRepository
    {
        public List<Class> GetClass(int id)
        {
            try
            {
                List<Class> result = new List<Class>();
                using (SqlConnection sqlcon = Database.Connection)
                {
                    string query = "SELECT * FROM Class WHERE characterid = @id";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(CreateClassFromReader(reader));
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
        private Class CreateClassFromReader(SqlDataReader reader)
        {
            Class classs = new Class()
            {
            Barbarian = Convert.ToInt32(reader["barbarian"]),
            Bard = Convert.ToInt32(reader["bard"]),
            Cleric = Convert.ToInt32(reader["cleric"]),
            Druid = Convert.ToInt32(reader["druid"]),
            Fighter = Convert.ToInt32(reader["fighter"]),
            Monk = Convert.ToInt32(reader["monk"]),
            Paladin = Convert.ToInt32(reader["paladin"]),
            Ranger = Convert.ToInt32(reader["ranger"]),
            Rogue = Convert.ToInt32(reader["rogue"]),
            Sorcerer = Convert.ToInt32(reader["sorcerer"]),
            Warlock = Convert.ToInt32(reader["warlock"]),
            Wizard = Convert.ToInt32(reader["wizard"]),
        };
            return classs;
        }
    }
}
