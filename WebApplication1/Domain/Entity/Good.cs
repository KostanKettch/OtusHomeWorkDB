using OtusHomeWorkDB.Abstractions;
namespace OtusHomeWorkDB.Domain.Entity
{
    public class Good:BaseEntity
    {
        public string name { get; set; } = null!;
        public Guid subcategory_id { get; set; } 
        public Subcategory subcategory { get; set; }=null!;
        public Guid user_id { get; set; }
        public virtual User user { get; set; } = null!;
        public float price { get; set; }
        public float stock { get; set; }
    }
}
