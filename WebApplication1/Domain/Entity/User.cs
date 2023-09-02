using OtusHomeWorkDB.Abstractions;

namespace OtusHomeWorkDB.Domain.Entity
{
    public class User: BaseEntity
    {

        public string login { get; set; } = null!;
        public string email { get; set; } = null!;
        public Boolean is_banned { get; set; }
        public Boolean is_approved { get; set; }
        public virtual ICollection<Good> Goods { get; set; } = new List<Good>();


    }
}
