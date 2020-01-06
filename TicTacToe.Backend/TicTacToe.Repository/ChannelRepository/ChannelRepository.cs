using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TicTacToe.Data.Connection;
using TicTacToe.Data.Models;
using TicTacToe.Repository.ChannelRepository;
using Dapper;
using System.Linq;

namespace TicTacToe.Repository.ChannelRepository
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public ChannelRepository()
        {
            _connectionString = Connection.Current.ConnectionString;
        }

        public Channel GetChannelById(Channel input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Channel WHERE Id = @Id" + input.Id;
                    var channel = dbConnection.QueryFirstOrDefault<Channel>(query);
                    return channel;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Channel> GetChannelList()
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Channel";
                    var channelList = dbConnection.Query<Channel>(query).ToList();
                    return channelList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Channel input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"INSERT INTO Channel(Name)VALUES(@Name)
                                 SELECT CAST(SCOPE_IDENTITY() as int)";

                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Name", input.Name);
                    var scopeId = dbConnection.Query<int>(query, dynamicParameter).Single();
                    return scopeId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Channel Update(Channel input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"UPDATE Channel SET Name = @Name WHERE Id = @Id
                                 SELECT * FROM Channel WHERE Id = @Id";

                    var dynamicParameter = new DynamicParameters();
                    dynamicParameter.Add("@Id", input.Id);
                    dynamicParameter.Add("@Name", input.Name);
                    var channel = dbConnection.Query<Channel>(query, dynamicParameter).SingleOrDefault();
                    return channel;
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
                    string query = @"DELETE FROM Channel WHERE Id = @Id
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
