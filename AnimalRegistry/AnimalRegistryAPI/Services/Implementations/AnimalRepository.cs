using AnimalRegistryAPI.DBUtils;
using AnimalRegistryAPI.Models;
using MySql.Data.MySqlClient;

namespace AnimalRegistryAPI.Services.Implementations
{
    public class AnimalRepository : IAnimalRepository
    {
        public int Create(Animal item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO kind_of_animal(idkind_of_animal, name, birthday, description) 
                                        VALUES(@idkind_of_animal, @name, @birthday, @description)";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = item.KindOfAnimalId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.Name;
            command.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = item.Birthday;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = item.Description;
            return command.ExecuteNonQuery();
        }

        public int Update(Animal item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE animal SET 
                                    idkind_of_animal = @idkind_of_animal,
                                    name = @name,
                                    birthday = @birthday,
                                    description = @description
                                    WHERE idanimal=@idanimal";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = item.AnimalId;
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = item.KindOfAnimalId;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.Name;
            command.Parameters.Add("@birthday", MySqlDbType.DateTime).Value = item.Birthday;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = item.Description;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM animal WHERE idanimal=@idanimal";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Animal> GetAll()
        {
            List<Animal> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Animal animal = new()
                {
                    AnimalId = reader.GetInt32(0),
                    KindOfAnimalId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Description = reader.GetString(4)
                };
                list.Add(animal);
            }
            return list;
        }

        public IList<Animal> GetAllByKindOfAnimalId(int id)
        {
            List<Animal> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal WHERE idkind_of_animal=@idkind_of_animal";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = id;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Animal animal = new()
                {
                    AnimalId = reader.GetInt32(0),
                    KindOfAnimalId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Description = reader.GetString(4)
                };
                list.Add(animal);
            }
            return list;
        }

        public Animal GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM animal WHERE idanimal=@idanimal";
            command.Parameters.Add("@idanimal", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Animal animal = new()
                {
                    AnimalId = reader.GetInt32(0),
                    KindOfAnimalId = reader.GetInt32(1),
                    Name = reader.GetString(2),
                    Birthday = reader.GetDateTime(3),
                    Description = reader.GetString(4)
                };
                return animal;
            }
            else
            {
                return null;
            }
        }

    }
}
