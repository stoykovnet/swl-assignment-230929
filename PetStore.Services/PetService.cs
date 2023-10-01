using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;
using PetStore.Services.Interfaces;

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

        public void AddPet(PetModel entity)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(long? id)
        {
            throw new NotImplementedException();
        }

        public void FindPetsByTags(long petId)
        {
            throw new NotImplementedException();
        }

        public void GetPetById(IEnumerable<string> tags)
        {
            throw new NotImplementedException();
        }

        public void UpdatePet(PetModel pet)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetWithForm(long petId, string name, string status)
        {
            throw new NotImplementedException();
        }
    }
}
