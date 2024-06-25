using Iyun25_2024_StoreManager.Abstraction;
using Iyun25_2024_StoreManager.Entities;

namespace Iyun25_2024_StoreManager.Managers
{
    public class ViewManager : Session
    {
        private UserManager _userManager {  get; set; }
        private ProductManager _productManager { get; set; }

        public ViewManager(UserManager userManager)
        {
            _userManager = userManager;
            _productManager = new ProductManager();
        }

        public void MainPage()
        {
            bool isControl = true;

            while (isControl)
            {
                Console.Clear();
             
                Console.WriteLine("1. Login to system");
                Console.WriteLine("2. Exit to Proqram");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            LoginPage();
                            break;
                        }
                    case "2":
                        {
                            isControl = false;
                            return;
                        }
                }
            }
        }

        public void LoginPage()
        {
            bool isControl = true;
            int tryChance = 0;

            Console.Clear();
            while (isControl)
            {
                tryChance++;
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                
                if(_userManager.Login(username, password))
                {
                    isControl = false;
                    HomePage();
                }
                else if(tryChance == 3)
                {
                    isControl = false;
                    Console.WriteLine("Your right of enter is overed. Press any key for continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Username or password is incorrect.");
                }
            }
        }

        public void HomePage()
        {
            bool isControl = true;

            while (isControl)
            {
                Console.Clear();
                foreach (Role role in CurrentUser.Roles)
                {
                    if (role.Id == 1)
                    {
                        Console.WriteLine("a. Sell Product");
                    }
                    if(role.Id == 2)
                    {
                        Console.WriteLine("b. Invoice Manager");
                    }
                    if (role.Id == 3)
                    {
                        Console.WriteLine("c. User Manager");
                    }
                    if (role.Id == 4)
                    {
                        Console.WriteLine("d. Product Manager");
                    }
                }

                Console.WriteLine("e. Exit");

                switch (Console.ReadLine())
                {
                    case "a":
                        {
                            bool canGoTo = false;
                            foreach (Role role in CurrentUser.Roles)
                            {
                                if (role.Id == 1)
                                {
                                    canGoTo = true;
                                    SellPage();
                                }

                            }
                            if (!canGoTo)
                            {
                                Console.Clear();
                                Console.WriteLine("You dont have any access for do that. Press Key For continue...");
                                Console.ReadLine();
                            }
                            break;
                        }
                    case "b":
                        {
                            bool canGoTo = false;
                            foreach (Role role in CurrentUser.Roles)
                            {
                                if (role.Id == 2)
                                {
                                    canGoTo = true;
                                    InvoiceManagePage();
                                }

                            }
                            if (!canGoTo)
                            {
                                Console.Clear();
                                Console.WriteLine("You dont have any access for do that. Press Key For continue...");
                                Console.ReadLine();
                            }
                            break;
                        }
                    case "c":
                        {
                            bool canGoTo = false;
                            foreach (Role role in CurrentUser.Roles)
                            {
                                if (role.Id == 3)
                                {
                                    canGoTo = true;
                                    UserManagePage();
                                }

                            }
                            if (!canGoTo)
                            {
                                Console.Clear();
                                Console.WriteLine("You dont have any access for do that. Press Key For continue...");
                                Console.ReadLine();
                            }
                            break;
                        }
                    case "d":
                        {
                            bool canGoTo = false;
                            foreach (Role role in CurrentUser.Roles)
                            {
                                if (role.Id == 4)
                                {
                                    canGoTo = true;
                                    ProductManagePage();
                                }
                                
                            }
                            if (!canGoTo)
                            {
                                Console.Clear();
                                Console.WriteLine("You dont have any access for do that. Press Key For continue...");
                                Console.ReadLine();
                            }
                            break;
                        }
                    case "e":
                        {
                            CurrentUser = null;
                            isControl = false;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public void ProductManagePage()
        {
            bool isControl = true;

            while (isControl)
            {
                Console.Clear();

                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Add Category");
                Console.WriteLine("3. Update category for Product");
                Console.WriteLine("4. Get All Products");
                Console.WriteLine("5. Get All Categories");
                Console.WriteLine("6. Delete Product");
                Console.WriteLine("7. Delete Category");
                Console.WriteLine("8. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            AddProductPage();
                            break;
                        }
                    case "2":
                        {
                            AddCategoryPage();
                            break;
                        }
                    case "3":
                        {
                            UpdateCategoryForProductPage();
                            break;
                        }
                    case "4":
                        {
                            ShowAllProducts();
                            break;
                        }
                    case "5":
                        {
                            ShowAllCategories();
                            break;
                        }
                    case "6":
                        {
                            DeleteProductPage();
                            break;
                        }
                    case "7":
                        {
                            DeleteCategoryPage();
                            break;
                        }
                    case "8":
                        {
                            isControl = false;
                            break;
                        }
                }
            }
        }

        public void AddProductPage()
        {
            Console.Clear();

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.Write("Enter Product Price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Product Count: ");
            int count = Convert.ToInt32(Console.ReadLine());

            _productManager.AddToDepo(productName, price, count);

            Console.WriteLine($"Succesfully added {productName}. Press any key for continue...");
            Console.ReadKey();
        }

        public void AddCategoryPage()
        {
            Console.Clear();


            Console.Write("Enter Category Name: ");
            string categoryName = Console.ReadLine();

            _productManager.AddToCategory(categoryName);

            Console.WriteLine($"Succesfully added {categoryName}. Press any key for continue...");
            Console.ReadKey();
        }

        public void UpdateCategoryForProductPage()
        {
            Console.Clear();

            Console.Write("Enter Product Id: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Category Id: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());

            _productManager.UpdateCategory(productId, categoryId);

            Console.WriteLine($"Succesfully updated. Press any key for continue...");
            Console.ReadKey();

        }

        public void DeleteProductPage()
        {
            Console.Clear();

            Console.Write("Enter Product Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _productManager.DeleteProduct(id);

            Console.WriteLine($"Succesfully deleted. Press any key for continue...");
            Console.ReadKey();
        }

        public void DeleteCategoryPage()
        {
            Console.Clear();

            Console.Write("Enter Category Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            _productManager.DeleteCategory(id);

            Console.WriteLine($"Succesfully deleted. Press any key for continue...");
            Console.ReadKey();
        }

        public void ShowAllProducts()
        {
            Console.Clear();

            var products = _productManager.GetAllProducts();

            Console.WriteLine("Id // Product Name // Category");
            foreach(var product in products)
            {
                var categoryName = product.Category != null ? product.Category.Name : "";
                Console.WriteLine($"{product.Id} // {product.Name} // {categoryName}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void ShowAllCategories()
        {
            Console.Clear();

            var categories = _productManager.GetAllCategories();

            Console.WriteLine("Id // Category Name");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id} // {category.Name}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void UserManagePage()
        {
            bool isControl = true;

            while (isControl)
            {
                Console.Clear();

                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Set Role for user");
                Console.WriteLine("3. Delete user");
                Console.WriteLine("4. Show all users");
                Console.WriteLine("5. Show all roles");
                Console.WriteLine("6. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            AddUserPage();
                            break;
                        }
                    case "2":
                        {
                            SetRoleForUserPage();
                            break;
                        }
                    case "3":
                        {
                            DeleteUserPage();
                            break;
                        }
                    case "4":
                        {
                            ShowAllUsers();
                            break;
                        }
                    case "5":
                        {
                            ShowAllRoles();
                            break;
                        }
                    case "6":
                        {
                            isControl = false;
                            break;
                        }
                }
            }
        }

        public void AddUserPage()
        {
            Console.Clear();

            Console.Write("Enter User Name: ");
            string username = Console.ReadLine();
            Console.Write("Enter User password : ");
            string password = Console.ReadLine();

            _userManager.AddUser(username, password);

            Console.WriteLine($"Succesfully added {username}. Press any key for continue...");
            Console.ReadKey();
        }

        public void SetRoleForUserPage()
        {
            Console.Clear();

            Console.Write("Enter User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Role Id: ");
            int roleId = Convert.ToInt32(Console.ReadLine());

            _userManager.SetRoleForUser(userId, roleId);

            Console.WriteLine($"Succesfully updated user. Press any key for continue...");
            Console.ReadKey();
        }

        public void DeleteUserPage()
        {
            Console.Clear();

            Console.Write("Enter User Id: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            _userManager.DeleteUser(userId);

            Console.WriteLine($"Succesfully deleted user. Press any key for continue...");
            Console.ReadKey();
        }

        public void ShowAllUsers()
        {
            Console.Clear();


            Console.WriteLine("Id // User // Roles");
            foreach (var user in UserManager.Users)
            {
                string roleList = string.Empty; // ""
                foreach (var role in user.Roles)
                {
                    roleList = roleList + role.Name + ", ";
                    //sell, user manage, 
                }

                Console.WriteLine($"{user.Id} // {user.Name} // {roleList}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void ShowAllRoles()
        {
            Console.Clear();


            Console.WriteLine("Id // Role name");
            foreach (var role in UserManager.Roles)
            {
                Console.WriteLine($"{role.Id} // {role.Name}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void SellPage()
        {
            bool isControl = true;

            Console.Clear();

            Console.WriteLine("Please enter product id to sell");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Invoice invoice = new Invoice();
            invoice.Products = new List<Product>();
            invoice.InvoiceId = _productManager._invoiceId;
            _productManager._invoiceId++;
            while (isControl)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Please enter product id: ");
                string input = Console.ReadLine();
                if(input == "")
                {
                    isControl = false;
                    break;
                }
                int productId = Convert.ToInt32(input);
                Product product = _productManager.GetProductById(productId);
                if(product == null)
                {
                    Console.WriteLine($"We dont have any product number of {productId}.");
                }
                else
                {
                    Console.WriteLine("Product succesfully added");
                    _productManager.DeleteProduct(productId);
                    invoice.Products.Add(product);
                    invoice.TotalAmount = invoice.TotalAmount + product.Price;
                }
            }
            invoice.Seller = CurrentUser;
            invoice.SaleDate = DateTime.Now;
            _productManager.Invoices.Add(invoice);

            Console.Clear();

            ShowReceipt(invoice);

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();

        }

        public void InvoiceManagePage()
        {
            bool isControl = true;

            while (isControl)
            {
                Console.Clear();

                Console.WriteLine("1. Show all Invoices");
                Console.WriteLine("2. Show specific invoice");
                Console.WriteLine("3. Refund Invoice");
                Console.WriteLine("4. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            ShowAllInvoicesPage();
                            break;
                        }
                    case "2":
                        {
                            ShowSpesificInvoicePage();
                            break;
                        }
                    case "3":
                        {
                            RefundInvoicePage();
                            break;
                        }
                    case "4":
                        {
                            isControl = false;
                            break;
                        }
                }
            }
        }

        public void ShowAllInvoicesPage()
        {
            Console.Clear();


            Console.WriteLine("Id // Invoice Date  // Cashier  // TotalAmount // IsRefund");
            foreach (var invoice in _productManager.Invoices)
            {
                Console.WriteLine($"{invoice.InvoiceId} // {invoice.SaleDate.ToString("dd/MM/yyyy HH:mm:ss")} // {invoice.Seller.Name} // {invoice.TotalAmount.ToString()} // {invoice.IsRefund.ToString()}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void ShowSpesificInvoicePage()
        {
            Console.Clear();

            Console.Write("Enter invoice id: ");
            int invoiceId = Convert.ToInt32(Console.ReadLine());
            foreach (var invoice in _productManager.Invoices)
            {
                if(invoice.InvoiceId == invoiceId)
                {
                    ShowReceipt(invoice);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void RefundInvoicePage()
        {
            Console.Clear();

            Console.Write("Enter invoice id: ");
            int invoiceId = Convert.ToInt32(Console.ReadLine());
            Invoice invoice = null;
            foreach (var invoiceItem in _productManager.Invoices)
            {
                if (invoiceItem.InvoiceId == invoiceId)
                {
                    invoice = invoiceItem;
                }
            }
            foreach(Product product in invoice.Products)
            {
                _productManager.DepoProduct.Add(product);
            }
            invoice.IsRefund = true;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Press any key for continue...");
            Console.ReadKey();
        }

        public void ShowReceipt(Invoice invoice)
        {
            Console.WriteLine();
            Console.WriteLine("-----------Info-----------");
            Console.WriteLine();
            Console.WriteLine("Hecer Market");
            Console.WriteLine();
            Console.WriteLine($"Date: {invoice.SaleDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Total Amount: {invoice.TotalAmount.ToString()}");
            Console.WriteLine($"Cashier: {invoice.Seller.Name.ToString()}");
            Console.WriteLine("---------------------------------------");
            foreach (Product product in invoice.Products)
            {
                Console.WriteLine($"{product.Id}  ---  {product.Name}  ---  {product.Price}");
            }

        }
    }
}
