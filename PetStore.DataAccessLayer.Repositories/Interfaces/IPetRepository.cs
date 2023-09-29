using PetStore.DataAccessLayer.Models;

namespace PetStore.DataAccessLayer.Repositories.Interfaces
{
    public interface IPetRepository : IRepository<PetModel>
    {
        IEnumerable<PetModel> GetPetsByTags(IEnumerable<string> tags);
        PetModel GetById(long id);
        void UpdateWithForm(long petId, string name, string status);
    }
}
