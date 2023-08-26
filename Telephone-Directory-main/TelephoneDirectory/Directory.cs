using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneDirectory
{
    class Directory
    {
        List<ListInformations> telephone_list = new List<ListInformations>();

        public void Questions()
        {
            int num;
            Console.WriteLine("Select the action you want to do");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Registering a New Number");
            Console.WriteLine("(2) Deleting Existing Number");
            Console.WriteLine("(3) Updating Existing Number");
            Console.WriteLine("(4) Listing the Directory");
            Console.WriteLine("(5) Searching in Telephone Directory");
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                Register();
            }
            else if (num == 2)
            {
                Delete();
            }
            else if (num == 3)
            {
                Update();
            }
            else if (num == 4)
            {
                listDirectory();
            }
            else if (num == 5)
            {
                Search();
            }
            else
            {
                throw new Exception("Only the numbers 1,2,3,4,5 are accepted.");
            }

        }
        public void Register()
        {
            ListInformations user = new ListInformations();
            Console.WriteLine("Name       :");
            string name = Console.ReadLine();
            Console.WriteLine("Surname       :");
            string surname = Console.ReadLine();
            Console.WriteLine("Tel Number       :");
            long tel = Convert.ToInt64(Console.ReadLine());

            user.Name = name;
            user.Surname = surname;
            user.Tel = tel;
            telephone_list.Add(user);
            Questions();
        }

        public void Delete()
        {
            Console.WriteLine("Enter the name or surname of the person whose number you want to delete:");
            string info = Console.ReadLine();
            int count = 0;
            foreach (var i in telephone_list)
            {
                if (info == i.Name || info.ToLower() == i.Name.ToLower() || info.ToUpper() == i.Name.ToUpper() || info == i.Surname || info.ToLower() == i.Surname.ToLower() || info.ToUpper() == i.Name.ToUpper())
                {
                    Console.WriteLine("{0} is about to be deleted from the directory, do you confirm?(y/n)", i.Name + " " + i.Surname);
                    string think = Console.ReadLine();
                    if (think == "y")
                    {
                        int ia = telephone_list.IndexOf(i);
                        telephone_list.RemoveAt(ia);
                        Questions();
                    }
                    if (think == "n")
                    {
                        Questions();
                    }
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("The data matching your search criteria could not be found in the directory. Please make a selection.");
                Console.WriteLine("  * To terminate the deletion: (1)");
                Console.WriteLine("  * To try again : (2)");
                int ans = Convert.ToInt32(Console.ReadLine());
                if (ans == 1)
                {
                    Questions();
                }
                else if (ans == 2)
                {
                    Delete();
                }
                else { throw new Exception("Enter 1 or 2"); }
            }
        }
        public void Update()
        {
            Console.WriteLine("Enter the name or surname of the person whose number you want to update:");
            string name_or_surname = Console.ReadLine();
            int count = 0;
            foreach (var i in telephone_list)
            {
                if (name_or_surname == i.Name || name_or_surname.ToLower() == i.Name.ToLower() || name_or_surname.ToUpper() == i.Name.ToUpper() || name_or_surname == i.Surname || name_or_surname.ToLower() == i.Surname.ToLower() ||
                    name_or_surname.ToUpper() == i.Name.ToUpper())
                {
                    Console.WriteLine("Telephone Number : " + i.Tel);
                    Console.WriteLine("Enter the new number for the phone number to be updated");
                    long tel = Convert.ToInt64(Console.ReadLine());
                    i.Tel = tel;
                    count++;
                    Questions();
                }
            }
            if (count == 0)
            {
                Console.WriteLine("The data matching your search criteria could not be found in the directory. Please make a selection.");
                Console.WriteLine("  * To terminate the update: (1)");
                Console.WriteLine("  * To try again : (2)");
                int ans = Convert.ToInt32(Console.ReadLine());
                if (ans == 1)
                {
                    Questions();
                }
                else if (ans == 2)
                {
                    Update();
                }
                else { throw new Exception("Enter 1 or 2"); }
            }
        }
        public void listDirectory()
        {
            Console.WriteLine("Telephone Directory");
            Console.WriteLine("**********************************************");
            foreach (var i in telephone_list)
            {
                Console.WriteLine("Name: {0}", i.Name);
                Console.WriteLine("Surname: {0}", i.Surname);
                Console.WriteLine("Telephone Number: {0}", i.Tel);
                Console.WriteLine("-");
            }
            Questions();
        }
        public void Search()
        {
            Console.WriteLine("Select the type you want to search.");
            Console.WriteLine("**********************************************");
            Console.WriteLine("To search by first or last name: (1)");
            Console.WriteLine("To search by phone number: (2)");
            int one_or_two = Convert.ToInt32(Console.ReadLine());
            int countLetter = 0;
            int countNum = 0;
            if (one_or_two == 1)
            {
                Console.WriteLine("Enter the name or surname of the person whose number you want to search:");
                string info = Console.ReadLine();
                foreach (var i in telephone_list)
                {
                    if (info == i.Name || info.ToLower() == i.Name.ToLower() || info.ToUpper() == i.Name.ToUpper() || info == i.Surname || info.ToLower() == i.Surname.ToLower() || info.ToUpper() == i.Name.ToUpper())
                    {
                        Console.WriteLine("Your Search Results:");
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("Name: {0}", i.Name);
                        Console.WriteLine("Surname: {0}", i.Surname);
                        Console.WriteLine("Telephone Number: {0}", i.Tel);
                        Console.WriteLine("-");
                        countLetter++;
                        Questions();
                    }
                    
                }
            }
            else if (one_or_two == 2)
            {
                Console.WriteLine("Enter the telephone number of the person whose number you want to search:");
                long num = Convert.ToInt64(Console.ReadLine());
                foreach (var i in telephone_list)
                {
                    if (num == i.Tel)
                    {
                        Console.WriteLine("Your Search Results:");
                        Console.WriteLine("**********************************************");
                        Console.WriteLine("Name: {0}", i.Name);
                        Console.WriteLine("Surname: {0}", i.Surname);
                        Console.WriteLine("Telephone Number: {0}", i.Tel);
                        Console.WriteLine("-");
                        Questions();
                    }
                }
                
            }

            if (countLetter == 0)
            {
                Console.WriteLine("The record you are looking for could not be found.");
            }
            if (countNum == 0)
            {
                Console.WriteLine("The record you are looking for could not be found.");
            }
        }
    }
}
