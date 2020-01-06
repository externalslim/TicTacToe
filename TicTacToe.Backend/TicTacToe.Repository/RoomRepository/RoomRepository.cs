using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TicTacToe.Data.Connection;
using TicTacToe.Data.Models;

namespace TicTacToe.Repository.RoomRepository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly string _connectionString;
        private IDbConnection _connection { get { return new SqlConnection(_connectionString); } }

        public RoomRepository()
        {
            _connectionString = Connection.Current.ConnectionString;
        }
        public List<Room> GetRoomList()
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Room";
                    var roomList = dbConnection.Query<Room>(query).ToList();
                    return roomList;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<Room> GetFinishedRoomListByUserId(int id)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Room WHERE Winner = @Id OR Looser = @Id AND EndDate IS NOT NULL";
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Id", id);
                    var roomList = dbConnection.Query<Room>(query, dynamicParameters).ToList();
                    return roomList;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Room GetRoomById(Room input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"SELECT * FROM Room WHERE Id = @Id";
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Id", input.Id);
                    var room = dbConnection.Query<Room>(query, dynamicParameters).FirstOrDefault();
                    return room;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Room input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"INSERT INTO Room
                                     (HomeUser, GameType, RoomId)
                                     VALUES
                                     (@HomeUser, @GameType, @RoomId)";

                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@HomeUser", input.HomeUser);
                    dynamicParameters.Add("@GameType", input.GameType);
                    dynamicParameters.Add("@RoomId", input.RoomId);
                    var scopeId = dbConnection.Query<int>(query, dynamicParameters).Single();
                    return scopeId;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Room Update(Room input)
        {
            try
            {
                using (IDbConnection dbConnection = _connection)
                {
                    string query = @"UPDATE Room SET
                                     HomeUser = @HomeUser,
                                     AwayUser = @AwayUser,
                                     GameType = @GameType,                                    
                                     Winner = @Winner,
                                     Looser = @Looser,
                                     RoomId = @RoomId,
                                     EndDate = @EndDate,
                                     IsDeleted = @IsDeleted
                                     WHERE Id = @Id";
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@HomeUser", input.HomeUser);
                    dynamicParameters.Add("@AwayUser", input.AwayUser);
                    dynamicParameters.Add("@GameType", input.GameType);
                    dynamicParameters.Add("@Winner", input.Winner);
                    dynamicParameters.Add("@Looser", input.Looser);
                    dynamicParameters.Add("@RoomId", input.RoomId);
                    dynamicParameters.Add("@IsDeleted", input.IsDeleted);
                    dynamicParameters.Add("@EndDate", input.EndDate);
                    dynamicParameters.Add("@Id", input.Id);

                    var room = dbConnection.Query<Room>(query, dynamicParameters).SingleOrDefault();
                    return room;
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
                    string query = @"UPDATE Room SET
                                     IsDeleted = @IsDeleted
                                     WHERE Id = @Id";
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@IsDeleted", true);
                    dynamicParameters.Add("@Id", id);


                    var room = dbConnection.Query<int>(query, dynamicParameters).SingleOrDefault();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
