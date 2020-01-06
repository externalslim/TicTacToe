using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;

namespace TicTacToe.Repository.RoomRepository
{
    public interface IRoomRepository
    {
        List<Room> GetRoomList();
        List<Room> GetFinishedRoomListByUserId(int id);
        Room GetRoomById(Room input);
        int Insert(Room input);
        Room Update(Room input);
        bool Delete(int id);
    }
}
