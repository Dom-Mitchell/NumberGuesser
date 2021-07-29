using System;
using System.Collections.Generic;

namespace NumberGuesser
{
    class Program
    {
        static Tuple<string, string> Greeting()
        {
            // Ask for users name & greet them
            Console.WriteLine("What is your name?");
            var userName = Console.ReadLine();
            Console.WriteLine($"\nIts a pleasure to meet you, {userName}!\n");

            // Users Favorite Number & Declaration
            Console.WriteLine($"{userName}, what is your favorite number?");
            var usersFaveNum = Console.ReadLine();
            Console.WriteLine($"\n{userName}'s favorite number is {usersFaveNum}.\n");

            var userAnswer = Tuple.Create(userName, usersFaveNum);
            return userAnswer;
        }

        static void Rules()
        {
            Console.WriteLine("############################### Rules ###############################");
            Console.WriteLine("# 1) I will try to guess what number you are thinking of, between 1 #");
            Console.WriteLine("# and whatever # you pick or your favorite # if you chose to use it #");
            Console.WriteLine("#                                                                   #");
            Console.WriteLine("# 2) Think of a # within your chosen range so I can guess your #    #");
            Console.WriteLine("#                                                                   #");
            Console.WriteLine("# 3) You have to type 'Higher' if your # is larger than my guess    #");
            Console.WriteLine("# or 'Lower' if your # is smaller than my guess.                    #");
            Console.WriteLine("#                                                                   #");
            Console.WriteLine("# 4) When I guess your # you must type 'Correct' so I know to end   #");
            Console.WriteLine("# the game.                                                         #");
            Console.WriteLine("#####################################################################");
        }

        static void ExitMessage()
        {
            // Thank user for playing
            Console.WriteLine("\nThanks for playing our game!");
            Console.WriteLine("Have a great day!");
        }

        static void PlayGame(Tuple<string, string> user)
        {
            // Variables
            var lowestNum = 1.0;
            var highestNum = 0.0;

            var guessesNeeded = 0.0;

            var numGuesses = 0;
            var guesses = new List<int>();
            var averageGuesses = 0;

            var correct = true;
            var stopGame = false;

            // Ask user if they want to play a game
            Console.WriteLine($"Do you want to play a game, {user.Item1}? (Yes/No)");
            var playGame = Console.ReadLine();

            // Logic to determine whether or not user wanted to play a game
            if (playGame == "yes" || playGame == "Yes" || playGame == "y" || playGame == "Y")
            {
                // Ask user if they want to use there favorite number
                Console.WriteLine($"\nDo you want to use your favorite number, {user.Item2}? (Yes/No)");
                var useFaveNum = Console.ReadLine();

                // Logic to determine whether or not user wants to use there favorite number
                if (useFaveNum == "yes" || useFaveNum == "Yes" || useFaveNum == "y" || useFaveNum == "Y")
                {
                    // Display rules with spacing for readability
                    Console.WriteLine();
                    Rules();

                    // Ask user if they are ready to start game
                    Console.WriteLine($"\n{user.Item1}, are you ready to start the game, using {user.Item2} as your number? (Yes/No)");
                    var startGame = Console.ReadLine();

                    // Display guesses needed to get users #
                    guessesNeeded = Math.Log2(double.Parse(user.Item2)) + 1;
                    Console.WriteLine($"\nIt will take {Convert.ToInt32(guessesNeeded)} guesses to get the # you selected! ");

                    // // Calculate Guess
                    // highestNum = double.Parse(user.Item2);
                    // Console.WriteLine($"Is your # {Math.Floor((lowestNum + double.Parse(user.Item2)) / 2)}? (Higher/Lower/Correct)");
                    // // var answer = Console.ReadLine();


                    while (!stopGame)
                    {
                        // Display guesses needed to get users #
                        guessesNeeded = Math.Log2(double.Parse(user.Item2)) + 1;
                        Console.WriteLine($"\nIt will take {Convert.ToInt32(guessesNeeded)} guesses to get the # you selected! ");
                        while (!correct)
                        {
                            // Calculate Guess
                            var currentGuess = Math.Floor((lowestNum + double.Parse(user.Item2)) / 2);
                            Console.WriteLine($"Is your # {Math.Floor((lowestNum + double.Parse(user.Item2)) / 2)}? (Higher/Lower/Correct)");
                            numGuesses++;
                            var answer = Console.ReadLine();

                            if (answer == "Correct")
                            {
                                correct = true;
                                Console.WriteLine("I got your # and I win! Game over.");
                                guesses.Add(numGuesses);

                                Console.WriteLine("Would you like to play again? (Yes/No))");
                                var playAgain = Console.ReadLine();
                                if (playAgain == "No" || playAgain == "no" || playAgain == "n" | playAgain == "N")
                                {
                                    stopGame = true;
                                }
                            }
                            else if (answer == "Lower")
                            {
                                highestNum = currentGuess - 1;
                            }
                            else if (answer == "Higher")
                            {
                                lowestNum = currentGuess + 1;
                            }
                        }


                    }
                }

                else if (useFaveNum == "no" || useFaveNum == "No" || useFaveNum == "n" || useFaveNum == "N")
                {
                    // Determine which number the user would like to use
                    Console.WriteLine("\nWhat # would you like to use? ");
                    var usersNum = Console.ReadLine();

                    // Display rules with spacing for readability
                    Console.WriteLine();
                    Rules();

                    // Ask user if they are ready to start game
                    Console.WriteLine($"\n{user.Item1}, are you ready to start the game, using {usersNum} as your number? (Yes/No)");
                    var startGame = Console.ReadLine();

                    // Display guesses needed to get users #
                    guessesNeeded = Math.Log2(double.Parse(usersNum)) + 1;
                    Console.WriteLine($"\nIt will take {Convert.ToInt32(guessesNeeded)} guesses to get the # you selected! ");
                }
                else
                {
                    ExitMessage();
                }

            }
            else
            {
                ExitMessage();
            }

        }

        static void Main(string[] args)
        {
            // Method used to display game
            var userAnswer = Greeting();
            PlayGame(userAnswer);


            //Rules();
        }
    }
}
