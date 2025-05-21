using System.Threading.Tasks;

namespace OMDbConsoleApp
{
    internal class Program
    {
        private readonly HttpClient _httpClient = new HttpClient();
        static void Main(string[] args)
        {
            DisplayWelcomeMessage();
            DisplayMenu();
            int choice = GetUserChoice();
            ExecuteUserOption(choice);
            Console.ReadKey();
        }

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("---!!!Welcome to Open Movie Console App..!!!----");
            Console.WriteLine("=================================================");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("1. Add Movie");
            Console.WriteLine("2. Update Movie");
            Console.WriteLine("3. Delete Movie");
            Console.WriteLine("4. Search Movie by Title");
            Console.WriteLine("5. Search Movie by Year");
            Console.WriteLine("6. Search Movie by ID");
            Console.WriteLine("7. Exit");
        }

        public static int GetUserChoice()
        {
            Console.Write("Please enter your choice: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 7)
            {
                return choice;
            }
            else
            {
                DisplayErrorMessage("Invalid choice. Please try again.");
                return GetUserChoice();
            }
        }

        public static void DisplayErrorMessage(string message)
        {
            Console.WriteLine("=================================================");
            Console.WriteLine($"Error: {message}");
            Console.WriteLine("=================================================");
        }

        public static void DisplayGoodbyeMessage()
        {
            Console.WriteLine("=================================================");
            Console.WriteLine("---!!!Thank you for using Open Movie Console App..!!!----");
        }

        public static void ExecuteUserOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    // Add Movie logic here
                    break;
                case 2:
                    // Update Movie logic here
                    break;
                case 3:
                    // Delete Movie logic here
                    break;
                case 4:
                    // Search Movie by Title logic here
                    break;
                case 5:
                    // Search Movie by Year logic here
                    break;
                case 6:
                    // Search Movie by ID logic here
                    break;
                case 7:
                    DisplayGoodbyeMessage();
                    Environment.Exit(0);
                    break;
                default:
                    DisplayErrorMessage("Invalid choice. Please try again.");
                    break;
            }
        }

        public async Task AddMovie()
        {
            // Logic to add a movie
            Console.WriteLine("Adding a movie...");
            // Implement the logic here


            var response = await _httpClient.PostAsync("https://api.example.com/movies", null);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add movie.");
            }

        }
    }
}
