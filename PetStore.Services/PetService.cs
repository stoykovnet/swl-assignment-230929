using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;
using PetStore.Services.Interfaces;
using System.Data;

namespace PetStore.Services
{
    public class PetService : IPetService
    {
        private IPetRepository petRepository;
        private string mockIdentifier = Guid.NewGuid().ToString();
        private string mockEmail = "a@a.a";

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public void AddPet(PetModel pet)
        {
            try
            {
                petRepository.Insert(pet, mockIdentifier);
                petRepository.Save();
            }
            catch (DataException)
            {
            }
        }

        public void DeletePet(long id)
        {
            try
            {
                // TODO: Should we check if it exists first.
                petRepository.Delete(id, mockEmail);
                petRepository.Save();
            }
            catch (DataException)
            {
            }
        }

        public IEnumerable<PetModel> FindPetsByTags(IEnumerable<string> tags)
        {
            var pets = new List<PetModel>();

            try
            {
                pets = petRepository.GetPetsByTags(tags).ToList();
            }
            catch (DataException)
            {
            }

            return pets;
        }

        public PetModel GetPetById(long id)
        {
            try
            {
                return petRepository.GetById(id);
            }
            catch (DataException)
            {
                return null;
            }
        }

        public void UpdatePet(PetModel pet)
        {
            try
            {
                petRepository.Update(pet, mockIdentifier);
            }
            catch (DataException)
            {
            }
        }

        public void UpdatePetWithForm(long petId, string name, string status)
        {
            try
            {
                petRepository.UpdateWithForm(petId, name, status);
            }
            catch (DataException)
            {
            }
        }
    }
}
