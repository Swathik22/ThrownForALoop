// See https://aka.ms/new-console-template for more information
using System.Net;

 List<Product> products = new List<Product>()
    {
    new Product()
        { 
            Name = "Football", 
            Price = 15.00M, 
            Sold = false,
            StockDate = new DateTime(2022, 10, 20),
            ManufactureYear = 2010,
            Condition = 4.2
        },
        new Product() 
        { 
            Name = "Hockey Stick", 
            Price = 12.02M, 
            Sold = false,
            StockDate = new DateTime(2022, 1, 20),
            ManufactureYear = 2010,
            Condition = 3.6
        },
        new Product() 
        { 
            Name = "Cricket Bat", 
            Price = 100.99M, 
            Sold = false,
            StockDate = new DateTime(2022, 6, 20),
            ManufactureYear = 2000,
            Condition = 3.8
        },
        new Product() 
        { 
            Name = "Cricket Ball", 
            Price = 50.99M, 
            Sold = false,
            StockDate = new DateTime(2022, 1, 20),
            ManufactureYear = 2000,
            Condition = 2.6
        },
        new Product() 
        { 
            Name = "Tennis Bat", 
            Price = 72.67M, 
            Sold = false,
            StockDate = new DateTime(2022, 3, 20),
            ManufactureYear = 2009,
            Condition = 3.6
        }
    };

string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. ViewLatestProducts");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if(choice=="3")
    {
        ViewLatestProducts();
    }
}

//>>>>>>>>>>>>>>>>>class<<<<<<<<<<<<<<<<<<

//Method
void ViewProductDetails()
{      
    ListProducts();
    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
    {
    int response = int.Parse(Console.ReadLine().Trim());
    chosenProduct = products[response - 1];
    }
    catch (FormatException)
    {
    Console.WriteLine("Please type only integers!");
    }
    catch (ArgumentOutOfRangeException)
    {
    Console.WriteLine("Please choose an existing item only!");
    }
    catch (Exception ex)
    {
    Console.WriteLine(ex);
    Console.WriteLine("Do Better!");
    }
    }
    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine(@$"You chose: 
    {chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
    It is {now.Year - chosenProduct.ManufactureYear} years old. 
    It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    // create a new empty List to store the latest products
    List<Product> latestProducts = new List<Product>();
    // Calculate a DateTime 90 days in the past
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    //loop through the products
    foreach (Product product in products)
    {
        //Add a product to latestProducts if it fits the criteria
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    Console.WriteLine(latestProducts.Count);
    // print out the latest products to the console 
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}
//>>>>>>>>>>>>>String<<<<<<<<<<<<<<<<<<<

// Console.WriteLine("Please enter a product name: ");
// string response=Console.ReadLine().Trim();

// if(string.IsNullOrEmpty(response))
// {
//     Console.WriteLine("You didn't choose anything");
// }
// else
// {
//      Console.WriteLine($"You entered :{response}");
// }

//Replacing above code with while loop by asking again if not entered

// while(!string.IsNullOrEmpty(response)){
//     Console.WriteLine("You didn't choose,try again!");
//     response=Console.ReadLine().Trim();
// }
// Console.WriteLine($"You chose: {response}");

//>>>>>>>>>>>>Integer<<<<<<<<<<<<<<<
// Console.WriteLine(@"Products:
// 1. Football
// 2. Hockey Stick
// 3. Boomerang
// 4. Frisbee
// 5. Golf Putter");
// Console.WriteLine("Please enter a product number: ");
// int response=int.Parse(Console.ReadLine());
// while(response>5||response<1)
// {
//     Console.WriteLine("Choose a number between 1 and 5");
//     response=int.Parse(Console.ReadLine().Trim());
// }

//>>>>>>>>>>>>>List<<<<<<<<<<<<<<<<<
// List<string> products = new List<string>()
// {
//     "Football",
//     "Hockey Stick",
//     "Boomerang",
//     "Frisbee",
//     "Golf Putter"
// };
// Console.WriteLine("products:");
// for(int i = 0; i < products.Count; i++)
// {
//     Console.WriteLine($"{i+1}:{products[i]}");
// }

// Console.WriteLine("Please enter a Product number: ");
// int response=int.Parse(Console.ReadLine().Trim());
// while(response>products.Count||response<1)
// {
//    Console.WriteLine("Choose a number between 1 and 5");
//     response=int.Parse(Console.ReadLine().Trim());
// }
// Console.WriteLine($"You choose:{products[response-1]}");
