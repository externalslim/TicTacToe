using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Data.Models;
using TicTacToe.Repository.ChannelRepository;

namespace TicTacToe.Service.ChannelService
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelRepository _channelRepository;
        public ChannelService(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }

        public List<Channel> GetChannelList()
        {
            return _channelRepository.GetChannelList();
        }

        public Channel GetChannelById(Channel input)
        {
            var channel = _channelRepository.GetChannelById(input);
            return channel;
        }

        public Channel Insert(Channel input)
        {
            var scopeId = _channelRepository.Insert(input);
            if (scopeId > 0)
            {
                input.Id = scopeId;
            }
            return input;
        }

        public Channel Update(Channel input)
        {
            var channel = _channelRepository.Update(input);
            return channel;
        }

        public bool Delete(int id)
        {
            return _channelRepository.Delete(id);
        }
    }
}
