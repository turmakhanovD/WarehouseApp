using System;
using System.Linq;

namespace WarehouseApp
{
    public class Menu
    {
        public void StartMenu()
        {

            Console.WriteLine("\t\t\tWarehouse\nChoose action\n1.Add item\n2.Remove item\n3.View all items");
            int choose = 0;
            while(!int.TryParse(Console.ReadLine(), out choose))
            {
                Console.Clear();
                Console.WriteLine("Try again!");
            }

            switch (choose)
            {
                case 1:
                    WarehouseContext context = new WarehouseContext();
                    Item newItem = new Item();
                    int price = 0;

                    Console.WriteLine("Enter item name: ");
                    newItem.Name = Console.ReadLine();

                    Console.WriteLine("Enter item price: ");
                    while (!int.TryParse(Console.ReadLine(), out price))
                    {
                        Console.Clear();
                        Console.WriteLine("Try again!");
                    }
                    newItem.Price = price;

                    context.Items.Add(newItem);
                    context.SaveChanges();
                    Console.WriteLine("Item added succesfully!");
                    context.Dispose();
                    break;
                case 2:
                    WarehouseContext contextRemove = new WarehouseContext();

                    Console.WriteLine("Write name of item to remove: ");

                    foreach(var item in contextRemove.Items.ToList())
                    {
                        Console.WriteLine($"Item name: {item.Name}\nItem price: {item.Price}\n");
                    }

                    string itemToDelete = Console.ReadLine();
                    Item itemDelete = contextRemove.Items.Where(x => x.Name == itemToDelete).FirstOrDefault();
                    contextRemove.Items.Remove(itemDelete);
                    contextRemove.SaveChanges();

                    Console.WriteLine("Item removed succesfully!");
                    contextRemove.Dispose();
                    break;
                case 3:
                    WarehouseContext contextView = new WarehouseContext();
                   
                    foreach (var item in contextView.Items.ToList())
                    {
                        Console.WriteLine($"Item name: {item.Name}\nItem price: {item.Price}\n");
                    }
                    contextView.Dispose();
                    break;

                default:
                    Console.WriteLine("Error#!");
                    break;
            }


        }
    }
}
