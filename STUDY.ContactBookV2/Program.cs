using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STUDY.ContactBookV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] name = new string[200];
            String[] email = new string[200];

            int tl = 0;

            int op = 0;

            string emailContact = "";
            // dados temporarios

            name[0] = "Eduardo";
            email[0] = "Eduardo@live";
            tl++;
            name[tl] = "Edu";
            email[tl] = "Edu@live";
            tl++;
            name[tl] = "Duds";
            email[tl] = "Duds@live";
            tl++;

            // acabou aqui

            while (op != 6)
            {
                op = Menu();

                switch (op)
                {
                    case 1:
                        Console.Clear();

                        ShowContacts(name,email,tl);
                        break;

                    case 2:
                        Console.Clear();
                        AddContact(ref name,ref email,ref tl);
                        break;

                    case 3:
                        Modify(ref name,ref email,ref tl);
                        break;
                    case 4:

                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Localize a contact by E-mail.");
                        Console.Write("Write the E-Mail: ");
                        emailContact = Console.ReadLine();

                        int pos = Localize(email, tl, emailContact);

                        if (pos == -1)
                        {
                            Console.WriteLine("Nome: {0} - E-Mail: {1}.", name[pos], email[pos]);
                        }
                        else
                        {
                            Console.WriteLine("Cannot find any contact.");
                        }
                        Console.WriteLine("\nPress any key to continue.");

                        Console.ReadKey();
                        break;
                    case 6:
                        op = 6;
                        break;
                }
            }
        }

        static int Menu()
        {
            Console.Clear();

            int op = 0;

            Console.WriteLine("Contact Book Console mode \n");

            Console.WriteLine("1 - Show Contacts.");
            Console.WriteLine("2 - Add a Contact.");
            Console.WriteLine("3 - Modify a Contact.");
            Console.WriteLine("4 - Remove a Contact.");
            Console.WriteLine("5 - Find a Contact.");
            Console.WriteLine("6 - Exit. \n");

            Console.Write("Option: ");
            op = Convert.ToInt32(Console.ReadLine());

            return op;
        }

        static void ShowContacts(String[] name, String[] email, int tl )
        {
            Console.WriteLine("Contact List: \n");
            for (int i = 0; i < tl; i++) 
            {
                Console.WriteLine("{0} - Name: {1} - Email: {2}.",i, name[i], email[i]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadLine();
        }

        static void AddContact(ref String[] name,ref String[] email, ref int tl)
        {
            try
            {
                Console.WriteLine("Add a Contact. \n");

                Console.Write("Name: ");
                name[tl] = Console.ReadLine();
                Console.WriteLine("E-mail: ");
                email[tl] = Console.ReadLine();
                int pos = Localize(email, tl, email[tl]);
                    
                if (pos == -1) 
                {
                    tl++;
                } else 
                { 
                    Console.WriteLine("Contact alredy exist");
                    Console.ReadKey();
                }

                 
                
            }catch (Exception e)
            {
                Console.WriteLine("ERROR: Cannot add more contacts. Contact list if FULL!");
                Console.ReadKey();
            }
           
           

        }

        static void Modify(ref String[] name, ref String[] email, ref int tl)
        {
            Console.Clear();

            Console.WriteLine("Contact List: \n");
            for (int i = 0; i < tl; i++)
            {
                Console.WriteLine("{0} - Name: {1} - Email: {2}.", i, name[i], email[i]);
            }

            Console.WriteLine("\nSelect the contact that you wish to modify.");
            Console.Write("Number: ");

            int modifyContact = Convert.ToInt32(Console.ReadLine());

            Console.Clear() ;

            Console.WriteLine("Contact selected: \n");
            Console.WriteLine("Name: {0}",name[modifyContact]);
            Console.WriteLine("E-Mail: {0} \n", email[modifyContact] );

            Console.WriteLine("Do you like to change the Name? (S/N)");
            Console.Write("Answer: ");

            string change = Console.ReadLine();
            change = change.ToLower();

            switch (change)
            {
                case "s":
                    Console.Clear();

                    Console.WriteLine("The current name is: {0} \n", name[modifyContact]);
                    Console.WriteLine("Write the new name:");
                    name[modifyContact] = Console.ReadLine();
                    break;         
            }

            Console.WriteLine("Do you like to change the E-Mail? (S/N)");
            Console.Write("Answer: ");

            change = Console.ReadLine();
            change = change.ToLower();

            switch (change)
            {
                case "s":
                    Console.Clear();

                    Console.WriteLine("The current E-Mail is: {0} \n", email[modifyContact]);
                    Console.WriteLine("Write the new E-Mail:");
                    email[modifyContact] = Console.ReadLine();

                    break;
            }

        }

        static void RemoveContact(ref String name)
        {
            
        }

        static int Localize(String[] email, int tl, String emailContact)
        {
            int pos = -1;
            int i = 0;

            while (i < tl && email[i] != emailContact)
            {
                i++;
            }

            if (i < tl) pos = i;
            

            return pos;
        }
    }
}
