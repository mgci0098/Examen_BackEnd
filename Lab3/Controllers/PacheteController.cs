using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Services;
using Lab3.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacheteController : ControllerBase
    {
        private IPacheteService pacheteService;

        public PacheteController(IPacheteService pacheteService)
        {
            this.pacheteService = pacheteService;
        }



        /// <summary>
        /// Returneaza toate pachetele
        /// </summary>
        /// <returns>O lista cu Pachete</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<PachetGetModel> Get()
        {
            return pacheteService.GetAll();
        }


        /// <summary>
        /// Cauta pachete dupa expeditor
        /// </summary>
        /// <param name="expeditor">Numele expeditorului care a trimis pachetul</param>
        /// <returns>O lista de pachete ale aceluiasi expeditor</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{expeditor}", Name = "Get")]
        public IEnumerable<PachetGetModel> Get(string expeditor)
        {
            var found = pacheteService.GetByExpeditor(expeditor);
            if (found == null)
            {
                return null;
            }
            return found;
        }


        /// <summary>
        /// Adauga un pachet in DB
        /// </summary>
        /// Sample request:
        ///
        ///     Post /pachete
        ///      { taraOrigine: "Romania",
        ///        denumireExpeditor: "Alin",
        ///        taraDestinatie: "Germania",
        ///        denumireDestinatar: "Maria",
        ///        adresaDestinatar: "acasa",
        ///        cost: 200,
        ///        codTracking: "123"          
        ///      }
        /// <param name="pachetPostModel">Datele pachetului</param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public void Post([FromBody] PachetPostModel pachetPostModel)
        {
            pacheteService.Create(pachetPostModel);
        }


        /// <summary>
        /// Modifica datele pentru un ID de pachet dat
        /// </summary>
        ///     Sample request:
        ///
        ///     Put /pachete/4
        ///      { taraOrigine: "Romania",
        ///        denumireExpeditor: "Alin",
        ///        taraDestinatie: "Germania",
        ///        denumireDestinatar: "Maria",
        ///        adresaDestinatar: "acasa",
        ///        cost: 200,
        ///        codTracking: "123"          
        ///      }
        /// <param name="id">Id-ul pachetului de modificat</param>
        /// <param name="pachetPostModel">Datele modificate ale pachetului</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PachetPostModel pachetPostModel)
        {
            var result = pacheteService.Upsert(id, pachetPostModel);
            return Ok(result);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = pacheteService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }



    }
}