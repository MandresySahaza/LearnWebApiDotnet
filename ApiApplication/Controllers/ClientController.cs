using ApiApplication.Models;
using ApiApplication.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly VenteContext _dbContext;
        public ClientController(VenteContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Clients.ToList());
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var client = _dbContext.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }


        //[HttpPost]
        //public IActionResult Post(Insert_Client_Dto clientDto)
        //{
        //    var client = new Client
        //    {
        //        Nom = clientDto.Nom,
        //        Prenom = clientDto.Prenom,
        //        Adresse = clientDto.Adresse,
        //        Ville = clientDto.Ville,
        //        CodePostal = clientDto.CodePostal,
        //        Telephone = clientDto.Telephone,
        //        Email = clientDto.Email
        //    };

        //    _dbContext.Clients.Add(client);
        //    _dbContext.SaveChanges();
        //    return Ok(client);
        //}


        //[HttpPost]
        //public async Task<IActionResult> Post(Client client)
        //{
        //    _dbContext.Clients.Add(client);
        //    await _dbContext.SaveChangesAsync();
        //    return Ok(client);
        //}


        [HttpPost]
        public IActionResult Post(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
            return Ok(client);
        }


    }



}
