using FloverShop.Models;
using FloverShop.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloverShop.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    [Authorize]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _service;

        public ShopController(ShopService service)
        {
            _service = service;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<Bouquet> Get()
        {
            var bouquet = _service.GetAllBouquets();
            return bouquet;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public Bouquet Get(string id)
        {
            var bouquet = _service.GetBouquet(id);
            return bouquet;
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] Bouquet bouquet)
        {
            _service.AddBouquet(bouquet);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Bouquet bouquet)
        {
            _service.UpdateBouquet(id, bouquet);
        }

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    _service.RemoveOrder(id);
        //}
    }
}
