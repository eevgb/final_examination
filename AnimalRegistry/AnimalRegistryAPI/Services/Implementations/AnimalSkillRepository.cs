using AnimalRegistryAPI.DBUtils;
using AnimalRegistryAPI.Models;
using MySql.Data.MySqlClient;

namespace AnimalRegistryAPI.Services.Implementations
{
    public class AnimalSkillRepository : IAnimalSkillRepository
    {
        public int Create(AnimalSkill item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO animal_skill(idanimal, idskill) 
                                        VALUES(@idanimal, @idskill)";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = item.SkilId;
            return command.ExecuteNonQuery();
        }

        public int Update(AnimalSkill item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE animal_skill SET 
                                    idanimal = @idanimal,
                                    idskill = @idskill";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = item.AnimalSkillId;
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = item.SkilId;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM animal_skill WHERE idanimal_skill=@idanimal_skill";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<AnimalSkill> GetAll()
        {
            List<AnimalSkill> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalSkill animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                list.Add(animalSkill);
            }
            return list;
        }

        public IList<AnimalSkill> GetAllByAnimalId(int id)
        {
            List<AnimalSkill> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill WHERE idanimal=@idanimal";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalSkill animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                list.Add(animalSkill);
            }
            return list;
        }

        public IList<AnimalSkill> GetAllBySkillId(int id)
        {
            List<AnimalSkill> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill WHERE idskill=@idskill";
            command.Parameters.Add("@idskill", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AnimalSkill animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                list.Add(animalSkill);
            }
            return list;
        }

        public AnimalSkill GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal_skill WHERE idanimal_skill=@idanimal_skill";
            command.Parameters.Add("@idanimal_skill", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                AnimalSkill animalSkill = new()
                {
                    AnimalSkillId = reader.GetInt32(0),
                    AnimalId = reader.GetInt32(1),
                    SkilId = reader.GetInt32(2),
                };
                return animalSkill;
            }
            else
            {
                return null;
            }
        }
    }
}
