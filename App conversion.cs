using System;
using System.IO;

namespace Sign_in_and_sign_up_for_application
{
    // ===================== AUTH PROGRAM =====================
    internal class Program
    {
        static string filePath = "users.txt";

        static void Main(string[] args)
        {
            InitializeFile();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== MAIN MENU =====");
                Console.WriteLine("1. Sign Up");
                Console.WriteLine("2. Sign In");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    SignUp();
                else if (choice == 2)
                    SignIn();
                else
                    break;

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        // ---------------- FILE INIT ----------------
        static void InitializeFile()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Close();
        }

        // ---------------- SIGN UP ----------------
        static void SignUp()
        {
            Console.Clear();
            Console.WriteLine("===== SIGN UP =====");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            if (UserExists(username))
            {
                Console.WriteLine("\nUser already exists!");
                return;
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Role (owner/customer/supplier): ");
            string role = Console.ReadLine();

            File.AppendAllText(filePath, $"{username} {password} {role}\n");
            Console.WriteLine("\nAccount created successfully!");
        }

        // ---------------- SIGN IN ----------------
        static void SignIn()
        {
            Console.Clear();
            Console.WriteLine("===== SIGN IN =====");

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Role: ");
            string role = Console.ReadLine();

            if (Authenticate(username, password, role))
            {
                Console.WriteLine("\nLogin successful!");

                if (role == "owner")
                    OwnerMenu();
                else if (role == "customer")
                    CustomerMenu();
                else
                    SupplierMenu();
            }
            else
            {
                Console.WriteLine("\nInvalid login details!");
            }
        }

        // ---------------- CHECK USER ----------------
        static bool UserExists(string username)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] data = line.Split(' ');
                if (data[0] == username)
                    return true;
            }
            return false;
        }

        // ---------------- AUTH ----------------
        static bool Authenticate(string u, string p, string r)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] data = line.Split(' ');
                if (data[0] == u && data[1] == p && data[2] == r)
                    return true;
            }
            return false;
        }

        // ---------------- MENUS ----------------
        static void OwnerMenu()
        {
            Console.WriteLine("\n--- OWNER MENU ---");
            DairyShop shop = new DairyShop();
            shop.Run();
        }

        static void CustomerMenu()
        {
            Console.WriteLine("\n--- CUSTOMER MENU ---");
            DairyShop shop = new DairyShop();
            shop.Run();
        }

        static void SupplierMenu()
        {
            Console.WriteLine("\n--- SUPPLIER MENU ---");
        }
    }

    // ===================== DAIRY SHOP =====================
    class DairyShop
    {
        const int SIZE = 7;

        // Product Data
        string[] names = { "Dairy Milk", "Curd", "Lassi", "Butter", "Ghee", "Khoya", "Cheese" };
        float[] prices = { 50, 40, 30, 200, 900, 350, 250 };
        int[] stock = { 100, 80, 60, 40, 20, 30, 25 };
        float[] sales = { 0, 0, 0, 0, 0, 0, 0 };

        float totalSalesAll = 0;

        void Header()
        {
            Console.WriteLine("\n====================================================");
            Console.WriteLine("               DAIRY DELIGHTS SHOP SYSTEM  ");
            Console.WriteLine("====================================================");
        }

        // Main Menu
        void Menu()
        {
            Header();
            Console.WriteLine("1. Buy Products");
            Console.WriteLine("2. Check Stock");
            Console.WriteLine("3. Check Total Sales");
            Console.WriteLine("4. Exit");
            Console.Write("\nEnter choice: ");
        }

        // Product List
        void ListProducts()
        {
            Console.WriteLine("\n-------------------- PRODUCT LIST ---------------------");
            Console.WriteLine("ID   Product Name        Price (Rs)       Stock");
            Console.WriteLine("--------------------------------------------------------");

            for (int i = 0; i < SIZE; i++)
            {
                Console.WriteLine((i + 1) + "    " + names[i] + "              Rs " + prices[i] + "           " + stock[i]);
            }

            Console.WriteLine("--------------------------------------------------------");
        }

        // Buy Multiple Items
        void BuyMultiple()
        {
            ListProducts();

            float totalBill = 0;
            int id, qty;
            int totalItems = 0;

            Console.WriteLine("\nStart Shopping! (Enter 0 to finish)");

            while (true)
            {
                Console.Write("\nEnter Product ID (0 to finish buying): ");
                id = int.Parse(Console.ReadLine());

                if (id == 0) break;

                if (id < 1 || id > SIZE)
                {
                    Console.WriteLine(" Invalid Product ID!");
                    continue;
                }

                int index = id - 1;

                Console.Write("Enter Quantity: ");
                qty = int.Parse(Console.ReadLine());

                if (qty <= 0)
                {
                    Console.WriteLine(" Invalid Quantity!");
                    continue;
                }

                if (qty > stock[index])
                {
                    Console.WriteLine("Only " + stock[index] + " available!");
                    continue;
                }

                float bill = qty * prices[index];
                totalBill += bill;
                totalItems += qty;

                stock[index] -= qty;
                sales[index] += bill;
                totalSalesAll += bill;

                Console.WriteLine(" Added to cart (" + names[index] + ") — Rs " + bill);
            }

            // FINAL RECEIPT
            Console.WriteLine("\n====================================================");
            Console.WriteLine("                   PURCHASE RECEIPT");
            Console.WriteLine("====================================================");
            Console.WriteLine("Total Items Bought : " + totalItems);
            Console.WriteLine("Total Bill         : Rs " + totalBill);
            Console.WriteLine("====================================================");
        }

        // Check Stock
        void CheckStock()
        {
            Header();
            ListProducts();
        }

        // Check Total Sales
        void CheckSales()
        {
            Header();
            Console.WriteLine("\n---------------- TOTAL SALES REPORT ----------------");

            for (int i = 0; i < SIZE; i++)
            {
                Console.WriteLine(names[i] + " : Rs " + sales[i]);
            }

            Console.WriteLine("\nTotal Sales (All Products): Rs " + totalSalesAll);
            Console.WriteLine("------------------------------------------------------");
        }

        // RUN SHOP
        public void Run()
        {
            int choice;
            bool running = true;

            while (running)
            {
                Menu();
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    BuyMultiple();
                else if (choice == 2)
                    CheckStock();
                else if (choice == 3)
                    CheckSales();
                else if (choice == 4)
                {
                    Console.WriteLine("\nThank you for using Dairy Delights! ");
                    running = false;
                }
                else
                    Console.WriteLine("\n Invalid Choice!");

                Console.WriteLine("\n(Going back to menu...)");
            }
        }
    }
}