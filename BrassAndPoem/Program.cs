//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 

List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType()
    {
        Id = 1,
        Title = "Brass"
    },
    new ProductType()
    {
        Id = 2,
        Title = "Poem"
    }
};

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.

List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Saxophone",
        Price = 80.95M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Bugle",
        Price = 900.00M,
        ProductTypeId = 1
    },new Product()
    {
        Name = "French Horn",
        Price = 25.75M,
        ProductTypeId = 1
    },new Product()
    {
        Name = "Ode to a Nightingale",
        Price = 100.99M,
        ProductTypeId = 2
    },new Product()
    {
        Name = "The Tyger",
        Price = 79.99M,
        ProductTypeId = 2
    },new Product()
    {
        Name = "The Raven",
        Price = 10.00M,
        ProductTypeId = 2
    }
};

//put your greeting here

Console.WriteLine("Welcome to Brass & Poem!");
Console.WriteLine("EST. 2078");

//implement your loop here

string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();

    if (choice == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("You are hereby banished unworthy mortal!");
    }
    else
    {
        Console.WriteLine("Please choose a valid option, you donkey!");
    }
}

void DisplayMenu()
{
    Console.WriteLine(@"1. Display all products
2. Delete a product
3. Add a new product
4. Update product properties
5. Exit
    ");     
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("All Products:");
    Console.WriteLine(string.Join("\n", products.Select((p, i) =>
    {
        ProductType type = productTypes.FirstOrDefault(pt => pt.Id == p.ProductTypeId);
        return $"{i + 1}. {p.Name} - ${p.Price} - ({type?.Title ?? "Unknown"})";
    })));   
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        Console.WriteLine("Enter the number of the product you would like to delete: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
            products.Remove(chosenProduct);
            Console.WriteLine($"{chosenProduct.Name} has been removed from the inventory!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing product!");
        }
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Enter name of the product you would like to add:");
    string name = Console.ReadLine().Trim();

    decimal price = 0;
    while (price == 0)
    {
        Console.WriteLine("Enter the product price:");
        try
        {
            price = decimal.Parse(Console.ReadLine().Trim());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid price!");
        }
    }

    Console.WriteLine("Product Types:");
    Console.WriteLine(string.Join("\n", productTypes.Select((pt, i) =>
        $"{i + 1}. {pt.Title}")));

    ProductType chosenType = null;
    while (chosenType == null)
    {
        Console.WriteLine("Please choose a product type: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenType = productTypes[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing product!");
        }
    }

    products.Add(new Product()
    {
        Name = name,
        Price = price,
        ProductTypeId = chosenType.Id
    });

    Console.WriteLine($"{name} has been added to the inventory!");
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);

    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        Console.WriteLine("Enter the number of the product you want to update: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing product!");
        }
    }
    Console.WriteLine($"Editing {chosenProduct.Name}");

    Console.WriteLine($"Enter a new name for {chosenProduct.Name} (press Enter to keep unchanged): ");
    string name = Console.ReadLine().Trim();
    if (name != "")
    {
        chosenProduct.Name = name;
    }
    
    Console.WriteLine("Enter a new price (press Enter to keep unchanged): "); 
    string priceInput = Console.ReadLine().Trim();
    if (priceInput != "")
    {
        bool validPrice = false;
        while (!validPrice)
        {
            try
            {
                chosenProduct.Price = decimal.Parse(priceInput);
                validPrice = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid price:");
                priceInput = Console.ReadLine().Trim();
            }
        }
    }

    Console.WriteLine("Choose a new product type id number (press Enter to keep unchanged): ");
    Console.WriteLine(string.Join("\n", productTypes.Select((pt, i) =>
        $"{i + 1}. {pt.Title}")));
    
    string productTypeInput = Console.ReadLine().Trim();
    if (productTypeInput != "")
    {
        bool validChoice = false;
        while (!validChoice)
        {
            try
            {
                int typeChoice = int.Parse(productTypeInput);
                ProductType chosenType = productTypes.FirstOrDefault(pt => pt.Id == typeChoice);
                if (chosenType == null)
                {
                    Console.WriteLine("Please choose an existing product type:");
                    productTypeInput = Console.ReadLine().Trim();
                }
                else
                {
                    chosenProduct.ProductTypeId = typeChoice;
                    validChoice = true;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid product type id number:");
                productTypeInput = Console.ReadLine().Trim();
            }
        }
    }
}

// don't move or change this!
public partial class Program { }