using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;

namespace PetStore.DataAccessLayer.Repositories
{
    public class TagRepository : BaseRepository<TagModel>, ITagRepository
    {
        private PetStoreContext context;

        private IList<TagModel> simpleMockTagList = new List<TagModel>()
        {
            new TagModel() { Id = 0, Name = "Super"},
            new TagModel() { Id = 1, Name = "Cool" },
            new TagModel() { Id = 2, Name = "Fast" },
            new TagModel() { Id = 3, Name = "Brave" },
            new TagModel() { Id = 4, Name = "Special" },
            new TagModel() { Id = 5, Name = "Rare" },
        };

        public TagRepository(PetStoreContext context) : base(context)
        {
            this.context = context;
        }

        public override TagModel? CheckSoftDelete(TagModel? entity)
        {
            throw new NotImplementedException();
        }

        public override IQueryable<TagModel> GetQueryWithAllIncludes()
        {
            throw new NotImplementedException();
        }
    }
}
