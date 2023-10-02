using PetStore.DataAccessLayer.Models;

namespace PetStore.Services.Interfaces
{
    public interface IPetService
    {
        public void AddPet(PetModel entity);
        public void DeletePet(long id);
        public IEnumerable<PetModel> FindPetsByTags(IEnumerable<string> tags);
        public PetModel GetPetById(long petId);
        public void UpdatePet(PetModel pet);
        public void UpdatePetWithForm(long petId, string name, string status);
    }
}
