using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HomeUser { get; set; }
        public int AwayUser { get; set; }
        public int GameType { get; set; }
        public int? Winner { get; set; }
        public int RoomId { get; set; }
        public DateTime CreatedDate { get; private set; }
        public Room()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
