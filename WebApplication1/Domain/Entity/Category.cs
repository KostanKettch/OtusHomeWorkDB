using OtusHomeWorkDB.Abstractions;
namespace OtusHomeWorkDB.Domain.Entity
{
    public class Category: BaseEntity
    {
        public string name { get; set; } = null!;
        public virtual ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}
