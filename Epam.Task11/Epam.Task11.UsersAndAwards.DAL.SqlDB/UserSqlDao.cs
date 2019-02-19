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
    public class UserSqlDao : IUserDao
    {
        private readonly string _connectionString;
        public UserSqlDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public void Add(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterName = new SqlParameter("@Name", user.Name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterDateOfBirthday = new SqlParameter("@DateOfBirthday", user.DateOfBirthday);
                command.Parameters.Add(parameterDateOfBirthday);
                SqlParameter parameterAge = new SqlParameter("@Age", user.Age);
                command.Parameters.Add(parameterAge);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool AddImage(int userId, string pathOfTheAddedImage)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteUser";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter("@Id", Id);
                command.Parameters.Add(parameterId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public IEnumerable<User> GetAll()
        {
            var result = new List<User>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllUsers";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(reader["DateOfBirthday"] == DBNull.Value)
                    {
                        result.Add(
                            new User
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Age = (int)reader["Age"],
                            });
                    }
                    else
                    {
                        result.Add(
                            new User
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                DateOfBirthday = (DateTime)reader["DateOfBirthday"],
                                Age = (int)reader["Age"],
                            });
                    }
                }
            }
            return result;
        }

        public int[] GetAwardsIdByUserId(int userId)
        {
            int[] result = null;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAwardsIdByUserId";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterUserId = new SqlParameter("@userId", userId);
                command.Parameters.Add(parameterUserId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    int[] result1 = new int[i + 1];
                    if(i>0)
                    {
                        for (int j = 0; j < result.Length; j++)
                        {
                            result1[j] = result[j];
                        }
                    }
                    if(reader["AwardId"] != DBNull.Value)
                    {
                        result1[i] = (int)reader["AwardId"];
                        result = result1;
                    }
                    i++;
                }
            }
            return result;
        }

        public User GetById(int Id)
        {
            var result = new User();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetById";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterUserId = new SqlParameter("@userId", Id);
                command.Parameters.Add(parameterUserId);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["DateOfBirthday"] == DBNull.Value)
                    {
                        result = new User
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Age = (int)reader["Age"],
                            };
                    }
                    else
                    {
                        result = new User
                        {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                DateOfBirthday = (DateTime)reader["DateOfBirthday"],
                                Age = (int)reader["Age"],
                            };
                    }
                }
            }
            return result;
        }

        public bool ToAward(int userId, int awardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "ToAward";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterUserId = new SqlParameter("@userId", userId);
                command.Parameters.Add(parameterUserId);
                SqlParameter parameterAwardId = new SqlParameter("@awardId", awardId);
                command.Parameters.Add(parameterAwardId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool ToRemoveUserReward(int userId, int awardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "ToRemoveUserReward";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterUserId = new SqlParameter("@userId", userId);
                command.Parameters.Add(parameterUserId);
                SqlParameter parameterAwardId = new SqlParameter("@awardId", awardId);
                command.Parameters.Add(parameterAwardId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool Update(User user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "UpdateUser";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter("@Id", user.Id);
                command.Parameters.Add(parameterId);
                SqlParameter parameterName = new SqlParameter("@Name", user.Name);
                command.Parameters.Add(parameterName);
                SqlParameter parameterDateOfBirthday = new SqlParameter("@DateOfBirthday", user.DateOfBirthday);
                command.Parameters.Add(parameterDateOfBirthday);
                SqlParameter parameterAge = new SqlParameter("@Age", user.Age);
                command.Parameters.Add(parameterAge);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
