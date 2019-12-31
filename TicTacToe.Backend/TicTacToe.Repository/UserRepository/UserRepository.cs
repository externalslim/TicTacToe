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
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"SELECT * FROM Users";
                var userList = dbConnection.Query<Users>(query).ToList();
                return userList;
            }
        }

        public Users GetUserById(Users input)
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
        public int Insert(Users input)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"INSERT INTO Users
                                (Nickname,Email,Password,ChannelId,WinRate,CreatedDate,IsDeleted)
                                VALUES
                                (@Nickname,@Email,@Password,@ChannelId)
                                 SELECT CAST(SCOPE_IDENTITY() as int)";

                var dynamicParameter = new DynamicParameters();
                dynamicParameter.Add("@Nickname", input.Nickname);
                dynamicParameter.Add("@Email", input.Email);
                dynamicParameter.Add("@Password", input.Password);
                dynamicParameter.Add("@ChannelId", input.ChannelId);
                var scopeId = dbConnection.Query<int>(query, dynamicParameter).Single();
                return scopeId;
            }
        }

        public Users Update(Users input)
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

        public bool Delete(int id)
        {
            using (IDbConnection dbConnection = _connection)
            {
                string query = @"DELETE FROM Users WHERE Id = @Id
                                 SELECT COUNT(Id) FROM Channel WHERE Id = @Id";

                var dynamicParameter = new DynamicParameters();
                dynamicParameter.Add("@Id", id);
                var channel = dbConnection.Query<int>(query, dynamicParameter).SingleOrDefault();
                if (channel == 0)
                {
                    return true;
                }
                return false;
            }
        }

       
    

     
    }
}
