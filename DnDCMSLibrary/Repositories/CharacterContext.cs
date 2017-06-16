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
    class CharacterContext : ICharacterRepository
    {
        public List<Character> GetCharacter()
        {
            try
            {
                List<Character> result = new List<Character>();
                using (SqlConnection sqlcon = Database.Connection)
                {
                    string query = "SELECT id, charactername FROM Character";
                    using (SqlCommand cmd = new SqlCommand(query, sqlcon))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(CreateCharacterFromReader(reader));
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
        private Character CreateCharacterFromReader(SqlDataReader reader)
        {
            Character character = new Character()
            {
            id = Convert.ToInt32(reader["id"]),
            name = reader["charactername"].ToString(),
            picturepath = reader["picture_path"].ToString(),
            race = (Race)Enum.Parse(typeof(Race), reader["race"].ToString()),
            subrace = (SubRace)Enum.Parse(typeof(SubRace), reader["subrace"].ToString()),
            background = reader["background"].ToString(),
            alignment = reader["alignment"].ToString(),
            experience = Convert.ToInt32(reader["experience"]),
            weight = reader["weight"].ToString(),
            height = reader["height"].ToString(),
            age = Convert.ToInt32(reader["age"]),
            haircolor = reader["haircolor"].ToString(),
            skincolor = reader["skincolor"].ToString(),
            eyecolor = reader["eyecolor"].ToString(),
            currenthp = Convert.ToInt32(reader["currenthp"]),
            maxhp = Convert.ToInt32(reader["maxhp"]),
            gender = reader["gender"].ToString(),
        };
            return character;
        }
    }
}
