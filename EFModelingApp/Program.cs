using EFModelingApp;
using EFWelcomeApp;

using (CompaniesContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    Employee bob = new Employee() { Name = "Bobby", 
                                    Phone = "+7 999 123-45-67"
                                    };
    context.Employees.Add(bob);
    context.SaveChanges();

    Thread.Sleep(5000);

    Employee tom = new Employee() { Name = "Bobby",
                                    Phone = "+7 900 333-44-55"
                                    };
    context.Employees.Add(tom);
    context.SaveChanges();

}