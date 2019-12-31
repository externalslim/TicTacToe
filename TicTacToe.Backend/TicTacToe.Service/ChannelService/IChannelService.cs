using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;

namespace TicTacToe.Service.ChannelService
{
    public interface IChannelService
    {
        List<Channel> GetChannelList();
        Channel GetChannelById(Channel input);
        Channel Insert(Channel input);
        Channel Update(Channel input);
        bool Delete(int id);
    }
}
