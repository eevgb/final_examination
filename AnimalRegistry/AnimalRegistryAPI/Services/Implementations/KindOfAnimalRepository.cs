using AnimalRegistryAPI.DBUtils;
using AnimalRegistryAPI.Models;
using MySql.Data.MySqlClient;

namespace AnimalRegistryAPI.Services.Implementations
{
    public class KindOfAnimalRepository : IKindOfAnimalRepository
    {
        public int Create(KindOfAnimal item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"INSERT INTO kind_of_animal(kind) 
                                        VALUES(@kind)";
            command.Parameters.Add("@kind", MySqlDbType.VarChar).Value = item.Kind;
            return command.ExecuteNonQuery();
        }

        public int Update(KindOfAnimal item)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"UPDATE kind_of_animal SET 
                                    kind = @kind
                                    WHERE idkind_of_animal=@idkind_of_animal";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = item.KindOfAnimalId;
            command.Parameters.Add("@kind", MySqlDbType.VarChar).Value = item.Kind;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM kind_of_animal WHERE idkind_of_animal=@idkind_of_animal";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = id;
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<KindOfAnimal> GetAll(int id = 0)
        {
            List<KindOfAnimal> list = new();
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM kind_of_animal";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                KindOfAnimal kind_of_animal = new()
                {
                    KindOfAnimalId = reader.GetInt32(0),
                    Kind = reader.GetString(1)
                };
                list.Add(kind_of_animal);
            }
            return list;
        }

        public KindOfAnimal GetById(int id)
        {
            using MySqlConnection connection = new DBMySQLUtils().GetMySQLConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM kind_of_animal WHERE idkind_of_animal=@idkind_of_animal";
            command.Parameters.Add("@idkind_of_animal", MySqlDbType.Int32).Value = id;
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                KindOfAnimal kind_of_animal = new()
                {
                    KindOfAnimalId = reader.GetInt32(0),
                    Kind = reader.GetString(1)
                };
                return kind_of_animal;
            }
            else
            {
                return null;
            }
        }

    }
}
