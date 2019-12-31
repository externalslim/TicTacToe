using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Data.Models;
using TicTacToe.Service.ChannelService;

namespace TicTacToe.Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private IChannelService _channelService;
        public ChannelController(IChannelService channelService) =>  _channelService = channelService;
        

        [HttpGet]
        public List<Channel> GetChannelList()
        {
            return _channelService.GetChannelList();
        }

        [HttpPost]
        public Channel Insert(Channel input)
        {
            return _channelService.Insert(input);
        }

        [HttpPost]
        public Channel Update(Channel input)
        {
            return _channelService.Update(input);
        }

        [HttpPost]
        public bool Delete(Channel input)
        {
            return _channelService.Delete(input.Id);
        }
    }
}