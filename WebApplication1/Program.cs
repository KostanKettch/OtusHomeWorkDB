using OtusHomeWorkDB.Domain;
using OtusHomeWorkDB.Domain.Entity;


using (DataContext db = new DataContext())
    while (true)
    {
        Console.WriteLine("Что вы хотите сделать:  1 - Вывести все данные; 2 - Добавить данные в таблицу; n - Выход");

        string mainMenu = Console.ReadLine();
        switch (mainMenu)
        {
            case "1":
                {
                    var users = db.users.ToList();
                    Console.WriteLine("Users list:");
                    foreach (User u in users)
                    {
                        Console.WriteLine($"{u.id} - {u.login} - {u.email}");
                    }

                    Console.WriteLine();
                    Console.WriteLine();


                    var categories = db.categories.ToList();
                    Console.WriteLine("Categories list:");
                    foreach (Category category in categories)
                    {
                        Console.WriteLine($"{category.id} - {category.name}");
                    }


                    Console.WriteLine();
                    Console.WriteLine();


                    var subcategories = db.subcategories.ToList();
                    Console.WriteLine("Subcategories list:");
                    foreach (Subcategory subcategory in subcategories)
                    {
                        Console.WriteLine($"{subcategory.id} - {subcategory.name}, идентификатор родительской категории: {subcategory.parent_category_id}");
                    }


                    Console.WriteLine();
                    Console.WriteLine();


                    var goods = db.goods.ToList();
                    Console.WriteLine("Goods list:");
                    foreach (Good good in goods)
                    {
                        Console.WriteLine($"{good.id} - {good.name}, цена:{good.price},в наличии:{good.stock}, идентификатор продавца: {good.user_id}, идентификатор подкатегории: {good.subcategory_id}  "
                            );
                    }

                    break;
                }

            case "2":
                {

                    Console.WriteLine("Введите номер таблицы для добавления записи:  1 - Users; 2 - Goods; 3 - Subcategory; 4 - Category; n - Выход");

                    string numberTable = Console.ReadLine();


                    switch (numberTable)
                    {
                        case "1":
                            Console.WriteLine("Введите имя пользователя:");
                            string login = Console.ReadLine();
                            Console.WriteLine("Введите email пользователя:");
                            string email = Console.ReadLine();
                            InsertUser(login, email);
                            break;
                        case "2":
                            Console.WriteLine("Введите название товара:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите цену товара:");
                            string price = Console.ReadLine();

                            Console.WriteLine("Введите логин продавца:");
                            string sellerName = Console.ReadLine();
                            var tseller = db.users.FirstOrDefault(c => c.login == sellerName);
                            Guid sellerId;
                            if (tseller != null)
                            {
                                sellerId = tseller.id;
                            }
                            else
                            {
                                Console.WriteLine("Нет такого логина.");
                                return;
                            }

                            Console.WriteLine("Введите имя подкатегории:");
                            string subcategoryName = Console.ReadLine();
                            var tsubcategory = db.subcategories.FirstOrDefault(c => c.name == subcategoryName);
                            Guid subcategoryId;
                            if (tsubcategory != null)
                            {
                                subcategoryId = tsubcategory.id;
                            }
                            else
                            {
                                Console.WriteLine("Нет такой категории.");
                                return;
                            }

                            Console.WriteLine("Введите Количество товара:");
                            string stock = Console.ReadLine();
                           
                            InsertGood(name, float.Parse(price), float.Parse(stock), sellerId, subcategoryId);

                            break;
                        case "3":
                            Console.WriteLine("Введите имя новой подкатегорию:");
                            string subcategory = Console.ReadLine();

                            Console.WriteLine("Введите имя родительской категории:");
                            string categoryName = Console.ReadLine();
                            var tcategory = db.categories.FirstOrDefault(c => c.name == categoryName);
                            if (tcategory != null)
                            {
                                Guid categoryId = tcategory.id;
                                InsertSubcategory(subcategory, categoryId);
                            }
                            else
                            {
                                Console.WriteLine("Нет такой категории");
                            }

                            break;
                        case "4":
                            Console.WriteLine("Введите категорию:");
                            string category = Console.ReadLine();
                            InsertCategory(category);
                            break;
                        case "n":
                            return;
                        default:
                            Console.WriteLine("Неправильно введен номер таблицы.");
                            break;

                    }

                    break;
                }
            case "n":
                return;
            default:
                Console.WriteLine("Неверное значение");
                break;
        }
        Console.WriteLine();
        Console.WriteLine();

    }

static void InsertUser(string login, string email)
{
    using (DataContext db = new DataContext())
    {
        try
        {
            var user = new User
            {
                id = Guid.NewGuid(),
                login = login,
                email = email
            };
            db.users.Add(user);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

    }
}

static void InsertCategory(string name)
{
    using (DataContext db = new DataContext())
    {
        try
        {

            var category = new Category
            {
                id = Guid.NewGuid(),
                name = name
            };
            db.categories.Add(category);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

static void InsertSubcategory(string name, Guid parentCategoryId)
{
    using (DataContext db = new DataContext())
    {
        try
        {

            var subcategory = new Subcategory
            {
                id = Guid.NewGuid(),
                name = name,
                parent_category_id = parentCategoryId
            };
            db.subcategories.Add(subcategory);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}


static void InsertGood(string name, float price, float stock,  Guid sellerId, Guid subcategoryId)
{
    using (DataContext db = new DataContext())
    {
        try
        {
            var Good = new Good
            {
                id = Guid.NewGuid(),
                name = name,
                price = price,
                stock = stock,
                user_id = sellerId,
                subcategory_id = subcategoryId
            };
            db.goods.Add(Good);

            db.SaveChanges();
            Console.WriteLine("Record Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}