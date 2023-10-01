using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PetStore.API.Swagger.Controllers.Generated;
using PetStore.DataAccessLayer.Models;
using System.Data;
using PetStore.Extensions;
using PetStore.Services.Interfaces;

namespace PetStore.API.Controllers
{
    public class PetController : PetControllerBase
    {
        private IPetService petService;
        private IMapper mapper;

        public PetController(IPetService petService, IMapper mapper)
        {
            this.petService = petService;
            this.mapper = mapper;
        }

        public override async Task<IActionResult> AddPet([BindRequired, FromBody] Pet body)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petService.AddPet(mapper.Map<PetModel>(body));

                    return Ok(); // TODO: Last inserted ID?
                }

                return StatusCode(405);
            }
            catch (DataException)
            {
                return StatusCode(500);
            }
        }

        public override async Task<IActionResult> DeletePet([FromHeader] string api_key, [BindRequired] long petId)
        {
            try
            {
                petService.DeletePet(petId);

                return Ok(petId);
            }
            catch (DataException)
            {
                return StatusCode(500);
            }
        }

        public override async Task<ActionResult<ICollection<Pet>>> FindPetsByTags([BindRequired, FromQuery] IEnumerable<string> tags)
        {
            try
            {
                var pets = petService.FindPetsByTags(tags).ToList();
                return Ok(mapper.Map<ICollection<Pet>>(pets));
            }
            catch (DataException)
            {
                return StatusCode(404);
            }
        }

        public override async Task<ActionResult<Pet>> GetPetById([BindRequired] long petId)
        {
            try
            {
                var pet = petService.GetPetById(petId);
                return Ok(mapper.Map<Pet>(pet));
            }
            catch (DataException)
            {
                return StatusCode(404);
            }
        }

        public override async Task<IActionResult> UpdatePet([BindRequired, FromBody] Pet body)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petService.UpdatePet(mapper.Map<PetModel>(body));
                    return Ok();
                }

                return StatusCode(405);
            }
            catch (DataException)
            {
                return StatusCode(404);
            }
        }

        public override async Task<IActionResult> UpdatePetWithForm([BindRequired] long petId, string name, string status)
        {
            try
            {
                petService.UpdatePetWithForm(petId, name, status);
                return Ok();
            }
            catch (DataException)
            {
                return StatusCode(404);
            }
        }
    }
}
