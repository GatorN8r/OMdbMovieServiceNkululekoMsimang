using OMDbConsoleApp.Model;
using System.Text;
using System.Text.Json;

namespace OMDbConsoleApp
{
    public class Program
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string BaseUrl = "http://localhost:5100/";

        static async Task Main(string[] args)
        {
            var program = new Program();
            var movie = new Movie();

            DisplayWelcomeMessage();
            DisplayMenu();
            int choice = GetUserChoice();
            await program.ExecuteUserOption(choice, movie);
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
            Console.WriteLine("5. Search Movie by ID");
            Console.WriteLine("6. Exit");
        }

        public static int GetUserChoice()
        {
            Console.Write("Please enter your choice: ");
            string? input = Console.ReadLine(); // Allow input to be nullable
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int choice) && choice >= 1 && choice <= 7)
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

        public async Task ExecuteUserOption(int choice, Movie movie)
        {
            switch (choice)
            {
                case 1:
                    // Add Movie logic here
                    await AddMovie();
                    break;
                case 2:
                    // Update Movie logic here
                    await UpdateMovie();
                    break;
                case 3:
                    // Delete Movie logic here
                    await RemoveMovieById(movie.imdbID);
                    break;
                case 4:
                    // Search Movie by Title logic here
                    await GetMovieByTitle(movie.Title); 
                    break;
                case 5:
                    // Search Movie by ID logic here
                    Console.Write("Enter Movie ID: ");
                    string id = Console.ReadLine();
                    if (string.IsNullOrEmpty(id))
                    {
                        DisplayErrorMessage("Movie ID cannot be null or empty.");
                        return;
                    }
                    await GetMovieById(id);
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
            Console.WriteLine("\nPlease enter movie details:");
            Console.WriteLine("\n===============================");
            var movie = await PopulateMovie();

            var json = JsonSerializer.Serialize(movie);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BaseUrl}movie/addmovie", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add movie.");
            }
        }

        public async Task UpdateMovie()
        {
            Console.WriteLine("\nPlease enter movie details:");
            Console.WriteLine("\n===============================");
            var movie = await PopulateMovie();
            var json = JsonSerializer.Serialize(movie);
            var content = new StringContent(json,Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}movie/updatemovie", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update movie.");
            }
        }

        public async Task<Movie> PopulateMovie()
        {
            var movie = new Movie();
            Console.Write("Title: ");
            movie.Title = Console.ReadLine();
            Console.Write("Year: ");
            movie.Year = Console.ReadLine();
            Console.Write("Rated: ");
            movie.Rated = Console.ReadLine();
            Console.Write("Released: ");
            movie.Released = Console.ReadLine();
            Console.Write("Runtime: ");
            movie.Runtime = Console.ReadLine();
            Console.Write("Genre: ");
            movie.Genre = Console.ReadLine();
            Console.Write("Director: ");
            movie.Director = Console.ReadLine();
            Console.Write("Writer: ");
            movie.Writer = Console.ReadLine();
            Console.Write("Actors: ");
            movie.Actors = Console.ReadLine();
            Console.Write("Plot: ");
            movie.Plot = Console.ReadLine();
            Console.Write("Language: ");
            movie.Language = Console.ReadLine();
            Console.Write("Country: ");
            movie.Country = Console.ReadLine();
            Console.Write("Awards: ");
            movie.Awards = Console.ReadLine();
            Console.Write("Poster: ");
            movie.Poster = Console.ReadLine();
            movie.Ratings = new List<Rating>();
            Console.Write("Metascore: ");
            movie.Metascore = Console.ReadLine();
            Console.Write("imdbRating: ");
            movie.imdbRating = Console.ReadLine();
            Console.Write("imdbVotes: ");
            movie.imdbVotes = Console.ReadLine();
            Console.Write("imdbID: ");
            movie.imdbID = Console.ReadLine();
            Console.Write("Type: ");
            movie.Type = Console.ReadLine();
            Console.Write("DVD: ");
            movie.DVD = Console.ReadLine();
            Console.Write("BoxOffice: ");
            movie.BoxOffice = Console.ReadLine();
            Console.Write("Production: ");
            movie.Production = Console.ReadLine();
            Console.Write("Website: ");
            movie.Website = Console.ReadLine();
            Console.Write("Response: ");
            movie.Response = Console.ReadLine();
            return movie;
        }

        public async Task<Movie?> GetMovieById(string? Id)
        {
            string url = $"{BaseUrl}api/OpenMovieDb/Id/{Id}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Retrieved successfully.");

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var json = await response.Content.ReadAsStringAsync();
                var movie = JsonSerializer.Deserialize<Movie>(json,options);
                if (movie == null)
                {
                    Console.WriteLine("Movie not found.");
                    return null;
                }
                Console.WriteLine($"Movie found:\n{movie.ToString()}");

                return movie;
            }
            else
            {
                Console.WriteLine("Failed to retrieve movie.");
                return null; 
            }
        }

        public async Task<Movie> GetMovieByTitle(string Title) { 

            string url = $"{BaseUrl}api/OpenMovieDb/Title/{Title}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Retrieved successfully.");
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var json = await response.Content.ReadAsStringAsync();
                var movie = JsonSerializer.Deserialize<Movie>(json, options);
                if (movie == null)
                {
                    Console.WriteLine("Movie not found.");
                    return null;
                }
                Console.WriteLine($"Movie found:\n{movie.ToString()}");
                return movie;
            }
            else
            {
                Console.WriteLine("Failed to retrieve movie.");
                return null;
            }

        }

        public async Task<string> RemoveMovieById(string Id) { 
        
            var url = $"{BaseUrl}api/OpenMovieDb/Id/{Id}";
            var response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Movie deleted successfully.");
                return "Movie deleted successfully.";
            }
            else
            {
                Console.WriteLine("Failed to delete movie.");
                return "Failed to delete movie.";
            }

        }

    }
}
