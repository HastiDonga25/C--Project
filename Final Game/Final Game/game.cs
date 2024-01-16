using System;
using System.Collections.Generic;

namespace FinalProject
{
    class Game
    {
        public void StartGame()
        {
            Gametitle(); // Start the game by calling Gametitle function
        }
        public static void Gametitle()
        {
            Console.WriteLine("Welcome to the Spin-to-Play Game!");
            Console.WriteLine("This game may be played by an unlimited number of players.");
            Console.WriteLine("Press 'Enter' to begin...");
            Console.ReadLine();
            Console.Clear();
            First(); // Move to the next step in the game
        }
        public static void First()
        {
            while (true)
            { // Keep the game running until the user chooses to exit
                Console.Write("Enter the number of players: ");
                int numberOfPlayers = int.Parse(Console.ReadLine());

                List<string> playerNames = new List<string>();

                // Collect names of all players
                for (int i = 0; i < numberOfPlayers; i++)
                {
                    Console.Write($"Enter the name of player {i + 1}: ");
                    playerNames.Add(Console.ReadLine());
                }

                Console.Clear(); // Clear the console screen to start a new game.
                Console.WriteLine("Game Start!"); // Display a message indicating the start of the game.

                string[] categories = { "World", "Animal", "History", "Situation" }; // Define the available categories.
                Random random = new Random(); // Create a new instance of the Random class for generating random values.

                int currentPlayerIndex = random.Next(numberOfPlayers); // Choose a random player for the current turn.
                string currentPlayer = playerNames[currentPlayerIndex]; // Get the name of the selected player.

                Console.WriteLine($"It's {currentPlayer}'s turn!"); // Display a message indicating whose turn it is.

                // Select a random category.
                string randomCategory = categories[random.Next(categories.Length)];
                Console.WriteLine($"Category: {randomCategory}");

                // Get a random question from the selected category.
                string question = GetRandomQuestion(randomCategory);
                Console.WriteLine(question);

                string answer = Console.ReadLine(); // Read the player's answer from the console.

                if (CheckAnswer(randomCategory, answer)) // Check if the player's answer is correct.
                {
                    Console.WriteLine("You Win!");  // Display a message if the answer is correct.
                }
                else
                {
                    Console.WriteLine("You Lose."); // Display a message if the answer is incorrect.
                }

                // Ask if the player wants to play again.
                Console.WriteLine("Do you want to play again? (yes or no)");
                string playAgain = Console.ReadLine().ToLower(); // This will convert input to lowercase.

                if (playAgain != "yes")
                    break;
            }
            Console.WriteLine("Thank you for playing the game!");
        }
        // Get a random question based on the chosen category
        static string GetRandomQuestion(string category)
        {
            Dictionary<string, List<string>> questions = new Dictionary<string, List<string>>
        {
                // Define questions for each category.
            { "World", new List<string> { "What is the capital city of Canada?", " What is the national winter sport of Canada?", " Canada is divided into how many provinces and territories?" } },
            { "Animal", new List<string> { "What is the largest land mammal in Canada?", "What is the national animal of Canada?", "In Canada, the lynx species with tufted ears and a ruffed face is known as the:" } },
            { "History", new List<string> { "Who was the first Prime Minister of Canada?", " What year did Canada officially become a country?", " Which country originally colonized Canada?" } },
            { "Situation", new List<string> { "What is the official currency of Canada?", " What is the largest city in Canada by population?", "What important international organization has its headquarters in Montreal, Canada?" } }
        };
            // Retrieve the list of questions for the chosen category.
            List<string> categoryQuestions = questions[category];
            Random random = new Random();
            // Return a random question from the list of questions for the chosen category.
            int questionIndex = random.Next(categoryQuestions.Count);
            return categoryQuestions[questionIndex];
        }
        // Check if the provided answer is correct for the chosen category
        static bool CheckAnswer(string category, string answer)
        {
            Dictionary<string, List<string>> correctAnswers = new Dictionary<string, List<string>>
        {
                // Define correct answers for each category.
            { "World", new List<string> { "Ottawa", "Ice Hockey", "10 provinces, 3 territories" } },
            { "Animal", new List<string> { " Moose", "Beaver", "Canadian Lynx" } },
            { "History", new List<string> { "John A. Macdonald", "1867", " France" } },
            { "Situation", new List<string> { "Dollar", "Toronto", "International Civil Aviation Organization (ICAO)" } }
        };
            // Retrieve the list of correct answers for the chosen category.
            List<string> categoryAnswers = correctAnswers[category];
            // Check if the provided answer is in the list of correct answers for the category.
            return categoryAnswers.Contains(answer);
        }
    }
}

