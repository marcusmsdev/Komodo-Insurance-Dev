using Developer_Team_Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    class ProgramUI
    {
        private DeveloperRepo _devInfo = new DeveloperRepo();
        
        //Method that runs/starts the application
        public void Run()
        {
            Seed();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                //Display the options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View Developers By ID number\n" +
                    "4. Update Existing Developer\n" +
                    "5. Delete Existing Developer\n" +
                    "6. Exit");


                //Get the user's input
                string input = Console.ReadLine();


                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create New Developer
                        CreateNewDeveloper();
                        break;
                    case "2":
                        //View All Developers
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        //View Developer By ID number
                        DisplayDeveloperById();
                        break;
                    case "4":
                        //Update Existing Developer
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        //Delete Existing Developer
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number 1 through 6");
                        break;

                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        //Create new Developer
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDev = new Developer();

            //FirstName
            Console.WriteLine("Enter the Developers first Name:");
            newDev.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter the Developers last Name:");
            newDev.LastName = Console.ReadLine();

            //
            Console.WriteLine("Team Name:");

            //PhoneNumber
            Console.WriteLine("Enter the Developers Phone Number:");
            
            
            string starPhone = Console.ReadLine();           
            newDev.PhoneNumber = starPhone;


            //UniqueId
            Console.WriteLine("Enter the Developers Unique ID:");
            int starId = Convert.ToInt32(Console.ReadLine());
            newDev.UniqueId = starId;

            //TypeOfDev
            Console.WriteLine("Enter the Developer's Position:\n" +
                "1. FrontEnd Software Developer\n" +
                "2. BackEnd Software Developer\n" +
                "3. FullStack Software Developer");

            string starTypeOfDev = Console.ReadLine();
            int typeOfDevInt = int.Parse(starTypeOfDev);
            newDev.TypeOfDev = (DevType)typeOfDevInt;

            _devInfo.AddContentToList(newDev);


            //IsPluralSight
            Console.WriteLine("Does the Developer have access to PluralSight? (y/n)");
            string starPluralSight = Console.ReadLine().ToLower();

            if(starPluralSight == "y")
            {
                newDev.IsPluralSight = true;
            }
            else
            {
                newDev.IsPluralSight = false;
            }
            



        }
        //View Current Developers that are saved
        private void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Developer> listofdevelopers = _devInfo.GetDevContent();

            foreach(Developer content in listofdevelopers)
            {
                Console.WriteLine($"FirstName: {content.FirstName}\n" +
                    $"LastName: {content.LastName}\n" +
                    $"Unique ID: {content.UniqueId}\n" +
                    $"PhoneNumber: {content.PhoneNumber}\n" +
                    $"Type of Developer: {content.TypeOfDev}\n" +
                    $"Access to PluralSight: {content.IsPluralSight}\n") ;
            }

        }
        //View existing Content by title
        private void DisplayDeveloperById()
        {
            Console.Clear();
            //Prompt the user to give me a ID
            Console.WriteLine("Enter the Developers ID number you would like to see:");
                       
            //Get the users input
            int Id = Convert.ToInt32(Console.ReadLine());

            //Find the content by that title
            Developer content = _devInfo.GetContentById(Id);

            //Display said content if it isnt null
            if(content != null)
            {
                Console.WriteLine($"FirstName: {content.FirstName}\n" +
                   $"LastName: {content.LastName}\n" +
                   $"Unique ID: {content.UniqueId}\n" +
                   $"PhoneNumber: {content.PhoneNumber}\n" +
                   $"Type of Developer: {content.TypeOfDev}\n" +
                   $"Access to PluralSight: {content.IsPluralSight}\n");
            }
            else
            {
                Console.WriteLine("No Developer ID found under that number.");
            }

        }
        //Update Existing Developer
        private void UpdateExistingDeveloper()
        {
            //Display all content
            DisplayAllDevelopers();


            //Ask for the uniqueID of the Developer to update
            Console.WriteLine("Enter the ID of the Developer you would like to update:");

            //Get the uniqueID
            int oldId = Convert.ToInt32(Console.ReadLine());



            //Build a new object
            Developer newDev = new Developer();

            //FirstName
            Console.WriteLine("Enter the Developers first Name:");
            newDev.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("Enter the Developers last Name:");
            newDev.LastName = Console.ReadLine();

            //PhoneNumber
            Console.WriteLine("Enter the Developers Phone Number:");


            string starPhone = Console.ReadLine();
            newDev.PhoneNumber = starPhone;


            //UniqueId
            Console.WriteLine("Enter the Developers Unique ID:");
            int starId = Convert.ToInt32(Console.ReadLine());
            newDev.UniqueId = starId;

            //TypeOfDev
            Console.WriteLine("Enter the Developer's Position:\n" +
                "1. FrontEnd Software Developer\n" +
                "2. BackEnd Software Developer\n" +
                "3. FullStack Software Developer");

            string starTypeOfDev = Console.ReadLine();
            int typeOfDevInt = int.Parse(starTypeOfDev);
            newDev.TypeOfDev = (DevType)typeOfDevInt;
            
            // verify the update worked
            bool wasUpdated = _devInfo.updateExistingContent(oldId, newDev);

            if (wasUpdated)
            {
                Console.WriteLine("Info successfully updated");
            }
            else
            {
                Console.WriteLine("Could not update info.");
            }

        }
        //Delete Existing Developer
        private void DeleteExistingDeveloper()
        {

            DisplayAllDevelopers();

            // get the developer id they want to remove
            Console.WriteLine("Enter the Developers unique ID you would like to remove:");

            int input = Convert.ToInt32(Console.ReadLine());

            //call the delete method
             bool wasDeleted = _devInfo.RemoveDevContent(input);

            //if the content was deleted, say so
            if (wasDeleted)
            {
                Console.WriteLine("The Developers info was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Developers info could not be deleted.");
            }

            //Otherwise state it could not be deleted

        }
        private void Seed()
        {
            //this is where the dummy developer accounts are held
            Developer developerA = new Developer("Leonard", "King", "317-364-4578", 201, DevType.FrontEnd, true);
            Developer developerB = new Developer("Ryan", "Jones", "317-694-2348", 207, DevType.FullStack, false);
            Developer developerC = new Developer("Allen", "Brown", "317-578-5389", 203, DevType.BackEnd, true);
            Developer developerD = new Developer("Morris", "White", "317-347-0798", 202, DevType.BackEnd, false);

            //Adding to the list
            _devInfo.AddContentToList(developerA);
            _devInfo.AddContentToList(developerB);
            _devInfo.AddContentToList(developerC);
            _devInfo.AddContentToList(developerD);

        }
       
    }
}
