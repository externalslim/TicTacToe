using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;

namespace TicTacToe.Repository.ChannelRepository
{
    public interface IChannelRepository
    {
        List<Channel> GetChannelList();
        Channel GetChannelById(Channel input);
        int Insert(Channel input);
        Channel Update(Channel input);
        bool Delete(int id);
    }
}
