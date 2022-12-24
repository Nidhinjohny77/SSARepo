
namespace DataAccess.Entities
{
    public class Item
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public int ItemTypeUID { get; set; }
        public ItemType ItemType { get; set; }  
    }
}
