using Microsoft.AspNetCore.Identity;
using OrderSystem2024.Models;

namespace OrderSystem2024.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            if (context.Category.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category {CategoryName="Nabiał", Description="nabial"},
                new Category {CategoryName="Mięso", Description="mięso"},
                new Category {CategoryName="Warzywa", Description="warzywa"}
            };
            foreach (var category in categories)
            {
                context.Category.Add(category);
            }
            context.SaveChanges();

            var suppliers = new Supplier[]
            {
                new Supplier
                {
                    SupplierName = "Dostawca 1",
                    ContactName = "Jan Kowalski",
                    Address = "ul. Kwiatowa 1",
                    City = "Warszawa",
                    PostalCode = "00-001",
                    Country = "Polska",
                    Phone = "123456789"
                },
                new Supplier
                {
                    SupplierName = "Dostawca 2",
                    ContactName = "Anna Nowak",
                    Address = "ul. Różana 2",
                    City = "Kraków",
                    PostalCode = "30-002",
                    Country = "Polska",
                    Phone = "987654321"
                },
                new Supplier
                {
                    SupplierName = "Dostawca 3",
                    ContactName = "Piotr Wiśniewski",
                    Address = "ul. Tulipanowa 3",
                    City = "Gdańsk",
                    PostalCode = "80-003",
                    Country = "Polska",
                    Phone = "456123789"
                }
            };
            foreach (var supplier in suppliers)
            {
                context.Supplier.Add(supplier);
            }
            context.SaveChanges();

            var products = new Product[]
            {
                new Product
                {
                    ProductName = "Mleko",
                    Unit = "1 litr",
                    Price = 2.50m,
                    SupplierId = 1,
                    CategoryId = 1,
                },
                new Product
                {
                    ProductName = "Jabłko",
                    Unit = "1 kg",
                    Price = 3.00m,
                    SupplierId = 2,
                    CategoryId = 3,
                },
                new Product
                {
                    ProductName = "Kurczak",
                    Unit = "1 kg",
                    Price = 10.00m,
                    SupplierId = 3,
                    CategoryId = 2,
                }
            };
            foreach (var product in products)
            {
                context.Product.Add(product);
            }
            context.SaveChanges();

            var shippers = new Shipper[]
            {
                new Shipper
                {
                    ShipperName = "Kurier 1",
                    Phone = "111222333"
                },
                new Shipper
                {
                    ShipperName = "Kurier 2",
                    Phone = "444555666"
                },
                new Shipper
                {
                    ShipperName = "DHL",
                    Phone = "444555666"
                }
            };
            foreach (var shipper in shippers)
            {
                context.Shipper.Add(shipper);
            }
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee
                {
                    LastName = "Kowalski",
                    FirstName = "Jan",
                    BirthDate = new DateTime(1980, 1, 1),
                    Photo = "kowalski.jpg",
                    Notes = "Pracownik magazynu"
                },
                new Employee
                {
                    LastName = "Nowak",
                    FirstName = "Anna",
                    BirthDate = new DateTime(1990, 2, 2),
                    Photo = "nowak.jpg",
                    Notes = "Pracownik biurowy"
                },
                new Employee
                {
                    LastName = "Twardowska",
                    FirstName = "Janina",
                    BirthDate = new DateTime(1990, 2, 2),
                    Photo = "nowak.jpg",
                    Notes = "Pracownik biurowy"
                }
            };
            foreach (var employee in employees)
            {
                context.Employee.Add(employee);
            }
            context.SaveChanges();

            var cos = await roleManager.CreateAsync(new IdentityRole("Admin"));
            var adminUser = new IdentityUser
            {
                UserName = "admin@admin.pl",
                NormalizedUserName = "ADMIN@ADMIN.PL",
                Email = "admin@admin.pl",
                NormalizedEmail = "ADMIN@ADMIN.PL",
                EmailConfirmed = true
            };
            if (context.Users.All(u => u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);
                var result = await userManager.CreateAsync(adminUser, "Admin1!");
                await userManager.AddToRoleAsync(adminUser, "Admin");

            }
            context.SaveChanges();
            var customers = new Customer[]
            {
                new Customer
                {
                    CustomerName = "Klient 1",
                    ContactName = "Adam Małysz",
                    Address = "ul. Skoczków 1",
                    City = "Zakopane",
                    PostalCode = "34-500",
                    Country = "Polska",
                    CustomerUserId = adminUser.Id,
                },
                
            };
            foreach (var customer in customers)
            {
                context.Customer.Add(customer);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = 1,
                    EmployeeId = 1,
                    ShipperId = 1
                },
                new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = 1,
                    EmployeeId = 2,
                    ShipperId = 2
                },
                new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = 1,
                    EmployeeId = 3,
                    ShipperId = 3
                }
            };
            foreach (var order in orders)
            {
                context.Order.Add(order);
            }
            context.SaveChanges();

            var orderDetails = new OrderDetail[]
            {
                new OrderDetail
                {
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 10
                },
                new OrderDetail
                {
                    OrderId = 2,
                    ProductId = 2,
                    Quantity = 5
                },
                new OrderDetail
                {
                    OrderId = 2,
                    ProductId = 3,
                    Quantity = 2
                },
                new OrderDetail
                {
                    OrderId = 3,
                    ProductId = 1,
                    Quantity = 10
                },
                new OrderDetail
                {
                    OrderId = 3,
                    ProductId = 2,
                    Quantity = 5
                },
                new OrderDetail
                {
                    OrderId = 3,
                    ProductId = 3,
                    Quantity = 2
                }
            };
            foreach (var orderDetail in orderDetails)
            {
                context.OrderDetail.Add(orderDetail);
            }
            context.SaveChanges();

        }
    }
}
