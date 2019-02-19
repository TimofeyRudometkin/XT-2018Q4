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
    public class SiteUserSqlDao : ISiteUserDao
    {
        private readonly string _connectionString;
        public SiteUserSqlDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
        public bool Add(string siteUserName, string userPassword)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "AddSiteUser";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                command.Parameters.Add(parameterSiteUserName);
                SqlParameter parameteruserPassword = new SqlParameter("@userPassword", userPassword);
                command.Parameters.Add(parameteruserPassword);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool AddImage(string siteUserName, string pathOfTheAddedImage)
        {
            throw new NotImplementedException();
        }

        public bool CorrectionOfAccessPermission(string siteUserName, bool admin)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "CorrectionOfAccessPermission";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                command.Parameters.Add(parameterSiteUserName);
                SqlParameter parameteradminPermission = new SqlParameter("@adminPermission", admin.ToString());
                command.Parameters.Add(parameteradminPermission);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool Delete(string siteUserName)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "DeleteSiteUser";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                command.Parameters.Add(parameterSiteUserName);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public IEnumerable<SiteUser> GetAll()
        {
            var result = new List<SiteUser>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAllSiteUsersWithoutAwardsId";
                command.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if(reader["AccessPermission"]!=DBNull.Value)
                    {
                        result.Add(
                            new SiteUser
                            {
                                Name = (string)reader["Name"],
                                Password = (string)reader["Password"],
                                AccessPermission = (string)reader["AccessPermission"],
                            });
                    }
                    else
                    {
                        result.Add(
                            new SiteUser
                            {
                                Name = (string)reader["Name"],
                                Password = (string)reader["Password"],
                            });
                    }
                }
            }
            int i;
            foreach(var siteUser in result)
            {
                int[] arrayAwardsSiteUsers = null;
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAwardsIdBySiteUserName";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUser.Name);
                    command.Parameters.Add(parameterSiteUserName);

                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    i = 0;
                    while (reader.Read())
                    {
                        int[] arrayAwardsSiteUsers1 = new int[i + 1];
                        if (i > 0)
                        {
                            for (int j = 0; j < arrayAwardsSiteUsers.Length; j++)
                            {
                                arrayAwardsSiteUsers1[j] = arrayAwardsSiteUsers[j];
                            }
                        }
                        if (reader["AwardId"] != DBNull.Value)
                        {
                            arrayAwardsSiteUsers1[i] = (int)reader["AwardId"];
                            arrayAwardsSiteUsers = arrayAwardsSiteUsers1;
                        }
                        i++;
                    }
                    siteUser.AwardId = arrayAwardsSiteUsers;
                }
            }
            return result;
        }

        public int[] GetAwardsIdBySiteUserName(string siteUserName)
        {
            int[] arrayAwardsSiteUsers = null;
            int i;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetAwardsIdBySiteUserName";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                command.Parameters.Add(parameterSiteUserName);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                i = 0;
                while (reader.Read())
                {
                    int[] arrayAwardsSiteUsers1 = new int[i + 1];
                    if (i > 0)
                    {
                        for (int j = 0; j < arrayAwardsSiteUsers.Length; j++)
                        {
                            arrayAwardsSiteUsers1[j] = arrayAwardsSiteUsers[j];
                        }
                    }
                    if (reader["AwardId"] != DBNull.Value)
                    {
                        arrayAwardsSiteUsers1[i] = (int)reader["AwardId"];
                        arrayAwardsSiteUsers = arrayAwardsSiteUsers1;
                    }
                    i++;
                }
            }
            return arrayAwardsSiteUsers;
        }

        public SiteUser GetBySiteUserName(string siteUserName)
        {
            var result = new SiteUser();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "GetBySiteUserName";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                command.Parameters.Add(parameterSiteUserName);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["AccessPermission"] != DBNull.Value)
                    {
                        result = new SiteUser
                            {
                                Name = (string)reader["Name"],
                                Password = (string)reader["Password"],
                                AccessPermission = (string)reader["AccessPermission"],
                            };
                    }
                    else
                    {
                        result = new SiteUser
                        {
                                Name = (string)reader["Name"],
                                Password = (string)reader["Password"],
                            };
                    }
                }
            }
            int i;
                int[] arrayAwardsSiteUsers = null;
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var command = sqlConnection.CreateCommand();
                    command.CommandText = "GetAwardsIdBySiteUserName";
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                    command.Parameters.Add(parameterSiteUserName);

                    sqlConnection.Open();
                    var reader = command.ExecuteReader();
                    i = 0;
                    while (reader.Read())
                    {
                        int[] arrayAwardsSiteUsers1 = new int[i + 1];
                        if (i > 0)
                        {
                            for (int j = 0; j < arrayAwardsSiteUsers.Length; j++)
                            {
                                arrayAwardsSiteUsers1[j] = arrayAwardsSiteUsers[j];
                            }
                        }
                        if (reader["AwardId"] != DBNull.Value)
                        {
                            arrayAwardsSiteUsers1[i] = (int)reader["AwardId"];
                            arrayAwardsSiteUsers = arrayAwardsSiteUsers1;
                        }
                        i++;
                    }
                    result.AwardId = arrayAwardsSiteUsers;
                }
            return result;
        }

        public bool ToAwardSiteUser(string siteUserName, int awardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = "ToAwardSiteUser";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
                command.Parameters.Add(parameterSiteUserName);
                SqlParameter parameterAwardId = new SqlParameter("@awardId", awardId);
                command.Parameters.Add(parameterAwardId);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool ToRemoveSiteUserReward(string siteUserName, int awardId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var command = sqlConnection.CreateCommand();
            command.CommandText = "ToRemoveSiteUserReward";
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter parameterSiteUserName = new SqlParameter("@siteUserName", siteUserName);
            command.Parameters.Add(parameterSiteUserName);
            SqlParameter parameterAwardId = new SqlParameter("@awardId", awardId);
            command.Parameters.Add(parameterAwardId);

            sqlConnection.Open();
            command.ExecuteNonQuery();
            }
            return true;
        }
    }
}
