<<<<<<< HEAD
﻿            using System;
            using System.IO;

namespace Sign_in_and_sign_up_for_application
    {
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
            }

            static void CustomerMenu()
            {
                Console.WriteLine("\n--- CUSTOMER MENU ---");
            }

            static void SupplierMenu()
            {
                Console.WriteLine("\n--- SUPPLIER MENU ---");
            }
        }
    }

=======
﻿            using System;
            using System.IO;

namespace Sign_in_and_sign_up_for_application
    {
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
            }

            static void CustomerMenu()
            {
                Console.WriteLine("\n--- CUSTOMER MENU ---");
            }

            static void SupplierMenu()
            {
                Console.WriteLine("\n--- SUPPLIER MENU ---");
            }
        }
    }

>>>>>>> 27f7e03cc06a5c8966986384732c82708585c5ea
