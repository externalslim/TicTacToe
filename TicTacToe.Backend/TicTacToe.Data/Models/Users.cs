using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Data.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ChannelId { get; set; }
        public double WinRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public Users()
        {
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
