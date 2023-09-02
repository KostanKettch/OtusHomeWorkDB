using OtusHomeWorkDB.Abstractions;

namespace OtusHomeWorkDB.Domain.Entity
{
    public class Subcategory: BaseEntity
    {

        public Guid parent_category_id { get; set; }
        public Category parent_category { get; set; } = null!;
        public string name { get; set; } = null!;
        public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
        
    }
}
