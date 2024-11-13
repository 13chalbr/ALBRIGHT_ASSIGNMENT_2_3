using System.Text;

namespace ALBRIGHT_ASSIGNMENT_2_3
{
    internal class Program
    {

        /* MSSA CCAD16 - 13NOV2024
         * CHRISTOPHER ALBRIGHT
         * ASSIGNMENT 2-3
         */

        static double MyCalc(double a, double b, double c)
        {
            return Math.Round(a + ((b / 100) * a) + ((c / 100) * a),2);
        }

        static void Main(string[] args)
        {
            /* ASSIGNMENT 2.3.1:
         * Write a console application to create a text file and save your basic details like 
         * name, age, address ( use dummy data). Read the details from same file and print on console.
         */
            string filePath = "C:\\Users\\13cha\\source\\repos\\ALBRIGHT_ASSIGNMENT_2_3\\TextFile1.txt";

            // user input

            string userFirst;
            string userLast;
            string userAddress;
            string hold;
            int i = 0;

            List<Person> people = new List<Person>();

            do
            {
                Console.WriteLine($"\nEnter person {i + 1}'s first name:");
                userFirst = Console.ReadLine();
                Console.WriteLine($"Enter person {i + 1}'s last name:");
                userLast = Console.ReadLine();
                Console.WriteLine($"Enter person {i + 1}'s mailing address:");
                userAddress = Console.ReadLine();

                people.Add(new Person { FirstName = userFirst, LastName = userLast, Address = userAddress });
                i++;
                Console.WriteLine("\nWould you like to add another person?");
                Console.WriteLine("Type 'y' or 'Y' to add another to the list or anyother key to continue.");
                hold = Console.ReadLine();
            }
            while (hold == "y" || hold == "Y");

            // Store step ...

            List<string> output = new List<string>();

            foreach (var person in people)
            {
                output.Add($"{ person.FirstName},{person.LastName},{person.Address}");
            }

            File.WriteAllLines(filePath, output);
            Console.WriteLine("\nAll entries written:");
            Console.WriteLine("\n\nHere is your completed list read from your text file:\n");

            // Read step...

            List<string> lines = File.ReadAllLines(filePath).ToList();


            //Use this bit if you want to create new objects in your class "Persons" from already existing .txt data
            //i.e. you need to Console print people that you didnt manually add above but existed on a text file. 
            //foreach (var line in lines)
            {
                //string[] entries = line.Split(',');

                //Person newPerson = new Person();

                //newPerson.FirstName = entries[0];
                //newPerson.LastName = entries[1];
                //newPerson.Address = entries[2];

                //people.Add(newPerson);
            }
            foreach (var person in people)
            {
                Console.WriteLine($"{person.FirstName}, {person.LastName}, {person.Address}");
            }

            Console.WriteLine("\nThis ends assignment 2.3.1.");

            // ==========================================================================================================

            /* ASSIGNMENT 2.3.2:
         * Write a console application to create a text file and save your basic details like 
         * name, age, address ( use dummy data). Read the details from same file and print on console.
         */

            // Variables:
            double totBill;
            double taxRate;
            double myTip;
            double tenTip = 10;
            double fifteenTip = 15;
            double twentyTip = 20;
            double withCustom;

            Console.WriteLine("======================================================================================");
            Console.WriteLine("\n\n\nWelcome to TipCalculator V1.0!");

            Console.WriteLine("\n\nEnter the total bill value:");
            totBill = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEnter sales taxation rate (i.e. type 7 for 7%, etc.):");
            taxRate = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nSales tax == $"+Math.Round(totBill*(taxRate/100), 2).ToString("F2"));

            //10% - 15% - 20% suggested tip rates
            Console.WriteLine("\n\nSuggested Tip Rates:");
            Console.WriteLine("\n10% tip == $" +Math.Round(0.1*totBill, 2).ToString("F2") + "\nTotal plus tax @ 10% Tip == $" + MyCalc(totBill, taxRate, tenTip).ToString("F2"));
            Console.WriteLine("\n15% tip == $" + Math.Round(0.15 * totBill, 2).ToString("F2") + "\nTotal plus tax @ 15% Tip == $" + MyCalc(totBill, taxRate, fifteenTip).ToString("F2"));
            Console.WriteLine("\n20% tip == $" + Math.Round(0.2 * totBill, 2).ToString("F2") + "\nTotal plus tax @ 20% Tip == $" + MyCalc(totBill, taxRate, twentyTip).ToString("F2"));

            Console.WriteLine("\n\nEnter above suggested tip % or custom tip % rate (i.e. type 15 for 15%):");
            myTip = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(String.Format("\nYou've entered a " + myTip + "% tip == $" + Math.Round((myTip / 100) * totBill, 2).ToString("F2")));
            Console.WriteLine(String.Format("\nTotal plus tax @ " + myTip + "% Tip == $" + Math.Round(MyCalc(totBill, taxRate, myTip), 2).ToString("F2")));

        }
    }
}
           
