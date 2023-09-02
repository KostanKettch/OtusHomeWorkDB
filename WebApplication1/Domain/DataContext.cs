using OtusHomeWorkDB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace OtusHomeWorkDB.Domain
{
    public class DataContext:DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
    //        Database.EnsureCreated();
        }

        public DbSet<User> users { get; set; } = null!;
        public DbSet<Category> categories { get; set; }
        public DbSet<Subcategory> subcategories { get; set; }
        public DbSet<Good> goods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string? connectionString = config.GetConnectionString("db");

            optionsBuilder.UseNpgsql(connectionString);

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(s => s.is_approved)
                .HasDefaultValue(false);
            modelBuilder.Entity<User>()
                .Property(s => s.is_banned)
                .HasDefaultValue(false);

            var user1 = new User { id = Guid.NewGuid(), login = "romeNoMe", email = "romeNoMe@email.com" };
            var user2 = new User { id = Guid.NewGuid(), login = "tHErSagN", email = "tHErSagN@email.com" };
            var user3 = new User { id = Guid.NewGuid(), login = "bletrove", email = "bletrove@email.com" };
            var user4 = new User { id = Guid.NewGuid(), login = "cichatra", email = "cichatra@email.com" };
            var user5 = new User { id = Guid.NewGuid(), login = "sleynxic", email = "sleynxic@email.com" };
            modelBuilder.Entity<User>()
                .HasData(user1, user2, user3, user4, user5);


            var category1 = new Category { id = Guid.NewGuid(), name = "Видеоигры и приставки" };
            var category2 = new Category { id = Guid.NewGuid(), name = "Игрушки и хобби" };

            modelBuilder.Entity<Category>().HasData(category1, category2);


            var subcategory1 = new Subcategory { id = Guid.NewGuid(), name = "Игровые приставки", parent_category_id = category1.id };
            var subcategory2 = new Subcategory { id = Guid.NewGuid(), name = "Товары для видеоигр", parent_category_id = category1.id };
            var subcategory3 = new Subcategory { id = Guid.NewGuid(), name = "Видеоигры", parent_category_id = category1.id };
            var subcategory4 = new Subcategory { id = Guid.NewGuid(), name = "Игры", parent_category_id = category2.id };
            var subcategory5 = new Subcategory { id = Guid.NewGuid(), name = "Строительные игрушки", parent_category_id = category2.id };
            var subcategory6 = new Subcategory { id = Guid.NewGuid(), name = "Миниатюры и военные игры", parent_category_id = category2.id };
            var subcategory7 = new Subcategory { id = Guid.NewGuid(), name = "Настольные и традиционные игры", parent_category_id = category2.id };
            var subcategory8 = new Subcategory { id = Guid.NewGuid(), name = "Ролевые игры", parent_category_id = category2.id };
            var subcategory9 = new Subcategory { id = Guid.NewGuid(), name = "Электронные игры", parent_category_id = category2.id };
            var subcategory10 = new Subcategory { id = Guid.NewGuid(), name = "Игрушки-конструкторы LEGO (R)", parent_category_id = category2.id };

            modelBuilder.Entity<Subcategory>()
                .HasData(subcategory1, subcategory2, subcategory3, subcategory4, subcategory5, subcategory6, subcategory7, subcategory8, subcategory9,subcategory10 );


            modelBuilder.Entity<Good>()
                .HasOne(s => s.subcategory)
                .WithMany(s => s.Goods)
                .HasForeignKey(p => p.subcategory_id);

            modelBuilder.Entity<Good>()
                .HasOne(s => s.user)
                .WithMany(s => s.Goods)
                .HasForeignKey(p => p.user_id);

            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.parent_category)
                .WithMany(s => s.Subcategories)
                .HasForeignKey(p => p.parent_category_id);

            var good1 = new Good { id = Guid.NewGuid(), name = "Nintendo Game Boy Advance", subcategory_id = subcategory1.id, user_id = user2.id, price = 200, stock = 10 };
            var good2 = new Good { id = Guid.NewGuid(), name = "DND Dice", subcategory_id = subcategory8.id, user_id = user2.id, price = 20, stock = 1 };
            var good3 = new Good { id = Guid.NewGuid(), name = "Rubiks cube", subcategory_id = subcategory7.id, user_id = user2.id, price = 5, stock = 15 };
            var good4 = new Good { id = Guid.NewGuid(), name = "Knight-Arcanum - Stormcast Eternals Questor Relictor - Warhammer Age Of Sigmar", subcategory_id = subcategory6.id, user_id = user4.id, price = 3, stock = 33 };
            var good5 = new Good { id = Guid.NewGuid(), name = "ELEKTRONIKA 24-01 Game Nu Pogodi Eggs Soviet Nintendo USSR WORKING", subcategory_id = subcategory9.id, user_id = user5.id, price = 110, stock = 1 };
            var good6 = new Good { id = Guid.NewGuid(), name = "Lego Western Set 6764 Sherrif Lock", subcategory_id = subcategory10.id, user_id = user4.id, price = 299, stock = 7 };
            modelBuilder.Entity<Good>()
                .HasData(good1, good2, good3, good4, good5, good6);
        }
    }
}
