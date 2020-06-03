using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SyncfusionLab.DataModels;
using SyncfusionLab.Services;

namespace SyncfusionLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public IPersonService Service { get; }
        public PersonController(IPersonService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<StandardResponse<List<Person>>> Get()
        {
            StandardResponse<List<Person>> standardResponse = new StandardResponse<List<Person>>();
            var fooItems = await Service.GetAsync();
            standardResponse.Payload = await fooItems.ToListAsync();
            standardResponse.Success = true;
            return standardResponse;
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await Service.GetAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Person person)
        {
            await Service.AddAsync(person);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Person person)
        {
            var item = await Service.GetAsync(id);
            if (item != null)
            {
                await Service.UpdateAsync(person);
            }
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var item = await Service.GetAsync(id);
            if (item != null)
            {
                await Service.DeleteAsync(item);
            }
        }
    }
}
