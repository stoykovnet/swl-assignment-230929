using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;

namespace PetStore.DataAccessLayer.Repositories
{
    public class PetRepository : BaseRepository<PetModel>, IPetRepository
    {
        private PetStoreContext context;

        // TODO: Replace with actual Database.
        private IList<PetModel> simpleMockPetList = new List<PetModel>()
        {
            new PetModel() {
                Id = 0,
                Category = new CategoryModel() { Id = 0, Name = "German Shepherd" },
                Name = "Terry",
                PhotoUrls = new List<string>() { "https://1", "https://2" },
                Tags = new List<TagModel>() { new TagModel() { Id = 0, Name = "Super"}, new TagModel() { Id = 1, Name = "Cool"} },
                Status = "sold"
            },

            new PetModel() {
                Id = 1,
                Category = new CategoryModel() { Id = 1, Name = "Bolognese" },
                Name = "Captain Paw",
                PhotoUrls = new List<string>() { "https://a", "https://b" },
                Tags = new List<TagModel>() { new TagModel() { Id = 2, Name = "Fast"}, new TagModel() { Id = 3, Name = "Brave"} },
                Status = "available"
            },

            new PetModel() {
                Id = 2,
                Category = new CategoryModel() { Id = 2, Name = "Corgi" },
                Name = "Queen's Elizabeth Corgi",
                PhotoUrls = new List<string>() { "https://31", "https://asd" },
                Tags = new List<TagModel>() { new TagModel() { Id = 4, Name = "Special"}, new TagModel() { Id = 5, Name = "Rare"} },
                Status = "pending"
            }
        };

        public PetRepository(PetStoreContext context) : base(context)
        {
            this.context = context;
        }

        // TODO: Take care of the identifier logic.
        public override void Insert(PetModel pet, string identifier)
        {
            simpleMockPetList.Add(pet);
        }

        public override void Delete(long? id, string email)
        {
            var pet = simpleMockPetList.First(x => x.Id == id);
            simpleMockPetList.Remove(pet);
        }

        public PetModel GetById(long petId)
        {
            return simpleMockPetList.First(p => p.Id == petId);
        }

        public IEnumerable<PetModel> GetPetsByTags(IEnumerable<string> tags)
        {
            // TODO: Handle case in Name.
            return simpleMockPetList.Where(pet => pet.Tags.Any(tag => tags.Contains(tag.Name))).ToList();
        }

        public void Update(PetModel pet, string identifier)
        {
            var originalPet = simpleMockPetList.First(x => x.Id == pet.Id);

            int index = simpleMockPetList.IndexOf(originalPet);
            simpleMockPetList[index] = pet;
        }

        public void UpdateWithForm(long petId, string name, string status)
        {
            var originalPet = simpleMockPetList.Where(x => x.Id == petId).First();
            int index = simpleMockPetList.IndexOf(originalPet);

            if (index >= 0)
            {
                originalPet.Name = name;
                originalPet.Status = status;

                simpleMockPetList[index] = originalPet;
            }
        }

        public override PetModel? CheckSoftDelete(PetModel? entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<PetModel> GetQueryWithAllIncludes()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        { }
    }
}
