using PetStore.DataAccessLayer.Models;

namespace PetStore.Services.Interfaces
{
    public interface IPetService
    {
        public void AddPet(PetModel entity);
        public void DeletePet(long? id);
        public void FindPetsByTags(long petId);
        public void GetPetById(IEnumerable<string> tags);
        public void UpdatePet(PetModel pet);
        public void UpdatePetWithForm(long petId, string name, string status);
    }
}
