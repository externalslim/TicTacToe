using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TicTacToe.Data.Connection;
using TicTacToe.Data.Models;

namespace TicTacToe.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public UserRepository()
        {
            _connectionString = Connection.Current.ConnectionString;
        }

        public List<Users> GetUserList()
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Users";
                    var userList = dbConnection.Query<Users>(query).ToList();
                    return userList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users GetUserByNicknameAndPassword(Users input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT Id FROM Users WHERE Nickname = @Nickname AND Password = @Password AND IsDeleted = 0";
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Nickname", input.Nickname);
                    dynamicParameter.Add("@Password", input.Password);
                    var user = dbConnection.Query<Users>(query, dynamicParameter).SingleOrDefault();
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users GetUserById(Users input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Users WHERE Id = @Id";
                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Id", input.Id);
                    var user = dbConnection.Query<Users>(query, dynamicParameter).SingleOrDefault();
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Insert(Users input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"IF NOT EXISTS(select Id from Users WHERE Email = @Email OR Nickname = @Nickname)
                                    BEGIN
                                    INSERT INTO Users
                                    (Nickname,Email,Password,ChannelId,WinRate)
                                    VALUES
                                    (@Nickname,@Email,@Password,@ChannelId,@WinRate)
                                     SELECT CAST(SCOPE_IDENTITY() as int)
                                     END
                                    ELSE
                                    SELECT 0";

                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Nickname", input.Nickname);
                    dynamicParameter.Add("@Email", input.Email);
                    dynamicParameter.Add("@Password", input.Password);
                    dynamicParameter.Add("@ChannelId", input.ChannelId);
                    dynamicParameter.Add("@WinRate", input.WinRate);
                    var scopeId = dbConnection.Query<int>(query, dynamicParameter).Single();
                    return scopeId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Users Update(Users input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"UPDATE Users SET
                                Nickname = @Nickname ,
                                Email = @Email ,
                                Password = @Password,
                                ChannelId = @ChannelId,
                                WinRate = @WinRate,
                                IsDeleted = @IsDeleted
                                WHERE Id = @Id
                                SELECT * FROM Users WHERE Id = @Id";

                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Nickname", input.Nickname);
                    dynamicParameter.Add("@Email", input.Email);
                    dynamicParameter.Add("@Password", input.Password);
                    dynamicParameter.Add("@ChannelId", input.ChannelId);
                    dynamicParameter.Add("@WinRate", input.WinRate);
                    dynamicParameter.Add("@IsDeleted", input.IsDeleted);
                    dynamicParameter.Add("@Id", input.Id);
                    var user = dbConnection.Query<Users>(query, dynamicParameter).SingleOrDefault();
                    return user;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"UPDATE Users SET IsDeleted = true
                                 WHERE Id = @Id
                                 SELECT COUNT(Id) FROM Users WHERE Id = @Id";

                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Id", id);
                    var user = dbConnection.Query<int>(query, dynamicParameter).SingleOrDefault();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
