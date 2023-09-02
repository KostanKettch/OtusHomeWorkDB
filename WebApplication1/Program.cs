using OtusHomeWorkDB.Domain;
using OtusHomeWorkDB.Domain.Entity;


using (DataContext db = new DataContext())
    while (true)
    {
        Console.WriteLine("��� �� ������ �������:  1 - ������� ��� ������; 2 - �������� ������ � �������; n - �����");

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
                        Console.WriteLine($"{subcategory.id} - {subcategory.name}, ������������� ������������ ���������: {subcategory.parent_category_id}");
                    }


                    Console.WriteLine();
                    Console.WriteLine();


                    var goods = db.goods.ToList();
                    Console.WriteLine("Goods list:");
                    foreach (Good good in goods)
                    {
                        Console.WriteLine($"{good.id} - {good.name}, ����:{good.price},� �������:{good.stock}, ������������� ��������: {good.user_id}, ������������� ������������: {good.subcategory_id}  "
                            );
                    }

                    break;
                }

            case "2":
                {

                    Console.WriteLine("������� ����� ������� ��� ���������� ������:  1 - Users; 2 - Goods; 3 - Subcategory; 4 - Category; n - �����");

                    string numberTable = Console.ReadLine();


                    switch (numberTable)
                    {
                        case "1":
                            Console.WriteLine("������� ��� ������������:");
                            string login = Console.ReadLine();
                            Console.WriteLine("������� email ������������:");
                            string email = Console.ReadLine();
                            InsertUser(login, email);
                            break;
                        case "2":
                            Console.WriteLine("������� �������� ������:");
                            string name = Console.ReadLine();
                            Console.WriteLine("������� ���� ������:");
                            string price = Console.ReadLine();

                            Console.WriteLine("������� ����� ��������:");
                            string sellerName = Console.ReadLine();
                            var tseller = db.users.FirstOrDefault(c => c.login == sellerName);
                            Guid sellerId;
                            if (tseller != null)
                            {
                                sellerId = tseller.id;
                            }
                            else
                            {
                                Console.WriteLine("��� ������ ������.");
                                return;
                            }

                            Console.WriteLine("������� ��� ������������:");
                            string subcategoryName = Console.ReadLine();
                            var tsubcategory = db.subcategories.FirstOrDefault(c => c.name == subcategoryName);
                            Guid subcategoryId;
                            if (tsubcategory != null)
                            {
                                subcategoryId = tsubcategory.id;
                            }
                            else
                            {
                                Console.WriteLine("��� ����� ���������.");
                                return;
                            }

                            Console.WriteLine("������� ���������� ������:");
                            string stock = Console.ReadLine();
                           
                            InsertGood(name, float.Parse(price), float.Parse(stock), sellerId, subcategoryId);

                            break;
                        case "3":
                            Console.WriteLine("������� ��� ����� ������������:");
                            string subcategory = Console.ReadLine();

                            Console.WriteLine("������� ��� ������������ ���������:");
                            string categoryName = Console.ReadLine();
                            var tcategory = db.categories.FirstOrDefault(c => c.name == categoryName);
                            if (tcategory != null)
                            {
                                Guid categoryId = tcategory.id;
                                InsertSubcategory(subcategory, categoryId);
                            }
                            else
                            {
                                Console.WriteLine("��� ����� ���������");
                            }

                            break;
                        case "4":
                            Console.WriteLine("������� ���������:");
                            string category = Console.ReadLine();
                            InsertCategory(category);
                            break;
                        case "n":
                            return;
                        default:
                            Console.WriteLine("����������� ������ ����� �������.");
                            break;

                    }

                    break;
                }
            case "n":
                return;
            default:
                Console.WriteLine("�������� ��������");
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