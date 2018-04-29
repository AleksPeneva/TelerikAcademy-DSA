using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<Product>> productsByType = new Dictionary<string, SortedSet<Product>>();
            Dictionary<string, Product> productsByName = new Dictionary<string, Product>();
            SortedSet<Product> productsOrderedByPrice = new SortedSet<Product>();
            StringBuilder output = new StringBuilder();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandParams = command.Split();
                if (command.StartsWith("add"))
                {
                    double price = double.Parse(commandParams[2]);
                    string name = commandParams[1];
                    string type = commandParams[3];
                    Product product = new Product(price, name, type);
                    AddProduct(product, productsByName, productsByType, productsOrderedByPrice, output);
                }
                else if (command.StartsWith("filter by type"))
                {
                    string type = commandParams[3];
                    FilterByType(type, productsByType, output);
                }
                else if (command.StartsWith("filter by price"))
                {
                    if (commandParams[3] == "from")
                    {
                        double from = double.Parse(commandParams[4]);
                        if (commandParams.Count() == 7) // from min to max
                        {
                            double to = double.Parse(commandParams[6]);
                            FromMinToMaxPrice(from, to, productsOrderedByPrice, output);
                        }
                        else if (commandParams.Count() == 5)// from min
                        {
                            FromMinPrice(from, productsOrderedByPrice, output);
                        }
                    }
                    if (commandParams[3] == "to") // to max
                    {
                        double to = double.Parse(commandParams[4]);
                        ToMaxPrice(to, productsOrderedByPrice, output);
                    }
                }
            }
            Console.Write(output.ToString());
        }

        public static void FromMinToMaxPrice(double from, double to, SortedSet<Product> productsOrderedByPrice, StringBuilder output)
        {
            output.AppendLine(string.Format("Ok: {0}", string.Join(", ", productsOrderedByPrice.Where(x => (x.Price >= from && x.Price <= to)).Take(10))));
        }

        public static void FromMinPrice(double from, SortedSet<Product> productsOrderedByPrice, StringBuilder output)
        {
            output.AppendLine(string.Format("Ok: {0}", string.Join(", ", productsOrderedByPrice.Where(x => x.Price > from).Take(10))));
        }

        public static void ToMaxPrice(double to, SortedSet<Product> productsOrderedByPrice, StringBuilder output)
        {
            output.AppendLine(string.Format("Ok: {0}", string.Join(", ", productsOrderedByPrice.Where(x => x.Price < to).Take(10))));
        }

        private static void AddProduct(Product product, Dictionary<string, Product> productsByName,
            Dictionary<string, SortedSet<Product>> productsByType, SortedSet<Product> productsOrderedByPrice, StringBuilder output)
        {
            if (productsByName.ContainsKey(product.Name))
            {
                output.AppendLine(string.Format($"Error: Product {product.Name} already exists"));
            }
            else
            {
                productsByName.Add(product.Name, product);
                productsOrderedByPrice.Add(product);
                if (!productsByType.ContainsKey(product.Type))
                {
                    productsByType.Add(product.Type, new SortedSet<Product>());
                }

                productsByType[product.Type].Add(product);
                output.AppendLine(string.Format($"Ok: Product {product.Name} added successfully"));
            }
        }

        private static void FilterByType(string type, Dictionary<string, SortedSet<Product>> productsByType, StringBuilder output)
        {
            if (productsByType.ContainsKey(type))
            {
                output.AppendLine(string.Format("Ok: {0}", string.Join(", ", productsByType[type].Take(10))));
            }
            else
            {
                output.AppendLine($"Error: Type {type} does not exists");
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Product(double price, string name, string type)
        {
            this.Price = price;
            this.Name = name;
            this.Type = type;
        }

        public override string ToString()
        {
            return string.Format($"{this.Name}({this.Price})");
        }

        public int CompareTo(Product other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Type.CompareTo(other.Type);
                }
            }

            return result;
        }
    }
}