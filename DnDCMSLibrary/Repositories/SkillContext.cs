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
    public class SkillContext : ISkillRepository
    {
        public List<Skill> GetSkills(int id)
        {
            try
            {
                List<Skill> result = new List<Skill>();
                using (SqlConnection sqlcon = Database.Connection)
                {
                    string query = "SELECT * FROM Skills WHERE characterid = @id";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(CreateSkillFromReader(reader));
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
        private Skill CreateSkillFromReader(SqlDataReader reader)
        {
            Skill skill = new Skill()
            {
            acrobatics = Convert.ToBoolean(reader["acrobatics"]),
            animalhandling = Convert.ToBoolean(reader["animalhandling"]),
            arcana = Convert.ToBoolean(reader["arcana"]),
            athletics = Convert.ToBoolean(reader["athletics"]),
            deception = Convert.ToBoolean(reader["deception"]),
            history = Convert.ToBoolean(reader["history"]),
            insight = Convert.ToBoolean(reader["history"]),
            intimidation = Convert.ToBoolean(reader["intimidation"]),
            investigation = Convert.ToBoolean(reader["investigation"]),
            medicine = Convert.ToBoolean(reader["medicine"]),
            nature = Convert.ToBoolean(reader["nature"]),
            perception = Convert.ToBoolean(reader["perception"]),
            performance = Convert.ToBoolean(reader["performance"]),
            persuasion = Convert.ToBoolean(reader["persuasion"]),
            religion = Convert.ToBoolean(reader["religion"]),
            sleightofhand = Convert.ToBoolean(reader["sleightofhand"]),
            stealth = Convert.ToBoolean(reader["stealth"]),
            survival = Convert.ToBoolean(reader["survival"]),
        };
            return skill;
        }
    }
}
