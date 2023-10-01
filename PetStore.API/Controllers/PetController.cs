using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PetStore.API.Swagger.Controllers.Generated;
using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;
using System.Data;
using PetStore.Extensions;

namespace PetStore.API.Controllers
{
    public class PetController : PetControllerBase
    {
        private IPetRepository petRepository;
        private IMapper mapper;
        private string mockIdentifier = Guid.NewGuid().ToString();
        private string mockEmail = "a@a.a";

        public PetController(IPetRepository petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }

        public override async Task<IActionResult> AddPet([BindRequired, FromBody] Pet body)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    petRepository.Insert(mapper.Map<PetModel>(body), mockIdentifier);
                    petRepository.Save();

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
                // TODO: Should we check if it exists first.
                petRepository.Delete(petId, mockEmail);
                petRepository.Save();

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
                var pets = petRepository.GetPetsByTags(tags).ToList();
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
                var pet = petRepository.GetById(petId);
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
                    petRepository.Update(mapper.Map<PetModel>(body), mockIdentifier);
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
                petRepository.UpdateWithForm(petId, name, status);
                return Ok();
            }
            catch (DataException)
            {
                return StatusCode(404);
            }
        }
    }
}
