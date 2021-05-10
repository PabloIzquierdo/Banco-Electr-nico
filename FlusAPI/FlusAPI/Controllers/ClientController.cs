using FlusAPI.Contexts;
using FlusAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext context;
        public ClientController(AppDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return context.Client.ToList();

        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            var client = context.Client.FirstOrDefault(p => p.id == id);
            return client;
        }

    }
}
