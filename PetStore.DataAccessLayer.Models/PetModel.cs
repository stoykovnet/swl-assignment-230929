using System.Collections.Generic;

namespace PetStore.DataAccessLayer.Models
{
    public class PetModel : BaseModel
    {
        public CategoryModel Category { get; set; }

        public string Name { get; set; }

        public List<string> PhotoUrls { get; set; } = new System.Collections.Generic.List<string>();

        public List<TagModel> Tags { get; set; }

        public string Status { get; set; }
    }
}
