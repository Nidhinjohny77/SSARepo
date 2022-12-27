

namespace DataModels.Models
{
    public  class ItemModel
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public ItemTypeModel ItemType { get; set; }
    }
}
