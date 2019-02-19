using Epam.Task11.UsersAndAwards.DAL.Interface;
using Epam.Task11.UsersAndAwards.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task11.UsersAndAwards.DAL.SqlDB
{
    public class AwardSqlDao : IAwardDao
    {
        private readonly string _connectionString;
        public AwardSqlDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public bool Add(Award award)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddAward";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterTitle = new SqlParameter("@Title", award.Title);
                command.Parameters.Add(parameterTitle);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteAward(int Id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteAward";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterAwardId = new SqlParameter("@awardId", Id);
                command.Parameters.Add(parameterAwardId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public IEnumerable<Award> GetAllAwards()
        {
            var result = new List<Award>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllAwards";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Award
                        {
                            Id = (int)reader["Id"],
                            Title = (string)reader["Title"],
                        });
                }
            }
            return result;
        }

        public Award GetAwardById(int Id)
        {
            var result = new Award();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAwardById";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterAwardId = new SqlParameter("@awardId", Id);
                command.Parameters.Add(parameterAwardId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = new Award
                    {
                        Id = Id,
                        Title = (string)reader["Title"],
                    };
                }
            }
            return result;
        }

        public Dictionary<int, Award> GetDictionaryOfAwards()
        {
            throw new NotImplementedException();
        }

        public bool UpdateAward(Award award)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateAward";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter("@awardId", award.Id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterTitle = new SqlParameter("@awardTitle", award.Title);
                command.Parameters.Add(parameterTitle);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
