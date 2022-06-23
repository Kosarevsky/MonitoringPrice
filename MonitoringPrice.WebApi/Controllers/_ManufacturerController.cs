using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Models;
using MonitoringPrice.WebApi.Interfaces;

namespace MonitoringPrice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _ManufacturerController : ControllerBase
    {
        private readonly IUnitOfWork _database;

        /// <summary>AutoMapper</summary>
        private readonly IMapper _mapper;

        public _ManufacturerController(IUnitOfWork database)
        {
            _database = database;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manufacturer, ManufacturerWebApiModel>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        // GET: api/<ManufacturerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManufacturerWebApiModel>>> Get()
        {
            var model = _mapper.Map<List<ManufacturerWebApiModel>>(await _database.Manufacturer.GetAllAsync());
            return model.ToList();
        }

        // GET api/<ManufacturerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManufacturerWebApiModel>> Get(int id)
        {
            var model = _mapper.Map<ManufacturerWebApiModel>(await _database.Manufacturer.GetByIdAsync(id));
            if (model == null) { NotFound(); }
            return model;
        }

        // PUT api/<ManufacturerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ManufacturerWebApiModel manufacturer)
        {
            if (id != manufacturer?.Id)
            {
                BadRequest();
            }
            var model = _mapper.Map<Manufacturer>(manufacturer);

            try
            {
                await _database.Manufacturer.SaveAsync(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                var result = _database.Manufacturer.GetAllAsync(x => x.Id == id);
                if (result == null)
                {
                    NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST api/<ManufacturerController>
        [HttpPost]
        public async Task<ActionResult<ManufacturerWebApiModel>> Post(ManufacturerWebApiModel manufacturer)
        {
            var result = _mapper.Map<Manufacturer>(manufacturer);
            await _database.Manufacturer.SaveAsync(result);
            return CreatedAtAction("Get", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE api/<ManufacturerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManufacturerWebApiModel>>  Delete(int id)
        {
            var result = _database.Manufacturer.FindAsync(x => x.Id == id);
            if (result == null)
            {
                NotFound();
            }
            _database.Manufacturer.DeleteAsync(id);

            return NoContent();
        }
    }
}
