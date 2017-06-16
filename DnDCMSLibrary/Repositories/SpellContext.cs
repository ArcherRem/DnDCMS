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
    public class SpellContext : ISpellRepository
    {
        public List<Spell> GetAllSpells()
        {
            try
            {
                List<Spell> result = new List<Spell>();
                using (SqlConnection sqlcon = Database.Connection)
                {
                    string query = "SELECT * FROM Spells";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(CreateSpellFromReader(reader));
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
        public List<Spell> GetSearchedSpell(string query)
        {
            try
            {
                List<Spell> result = new List<Spell>();
                using (SqlConnection sqlcon = Database.Connection)
                {
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(CreateSpellFromReader(reader));
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
        private Spell CreateSpellFromReader(SqlDataReader reader)
        {
            Spell spell = new Spell()
            {
            id = Convert.ToInt32(reader["id"]),
            name = reader["name"].ToString(),
            level = reader["spelllevel"].ToString(),
            type = reader["spelltype"].ToString(),
            ritual = Convert.ToBoolean(reader["ritual"]),
            effect = reader["effect"].ToString(),
            castingtime = reader["casting time"].ToString(),
            range = reader["range"].ToString(),
            components = reader["components"].ToString(),
            duration = reader["duration"].ToString(),
        };
            return spell;
        }
    }
}

