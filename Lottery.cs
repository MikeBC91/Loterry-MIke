using System;
using System.Collections.Generic;

class Lottery
{
    static int high = 20;  ////control the limits of my lottery 
    static int low = 1;
    static void Main(string[] arg)
    {
                
        
        int limit = 4;


        //// print the User Number 
        int[] UserNumbers = UserNumber(limit);
        if (UserNumbers == null) return;
        Console.WriteLine("Your numbers are: ");
        Array.Sort(UserNumbers);
        Console.WriteLine("                  " + string.Join(", ", UserNumbers));


        //////checking for duplicates inside the user number 
        if (LinearSearch(UserNumbers))
        {
            Console.WriteLine(" what is wrong with you?? you can not type duplicate numbers");
            Console.WriteLine("                                                               ");
            Main(arg);
            return;

        }

        ////print the random number 
        int[] Rnumbers = RandomNumber(limit);
        Console.WriteLine("Winning numbers: ");
        Array.Sort(Rnumbers);
        Console.WriteLine("                  " + string.Join(", ", Rnumbers));


        //// checking for duplicates inside the winning numbers
        if (LinearSearch(Rnumbers))
        {

            return;

        }

        //// Compared to the user again the random number using binarySearch
        List<int> WinningNumbers = new List<int>();
        foreach (int num in UserNumbers)
        {
            int index = BinarySearch(Rnumbers, num);
            if (index != -1)
            {
                WinningNumbers.Add(num);
            }
        }

        if (WinningNumbers.Count > 0)
        {
            Console.WriteLine("You got the next winning numbers: ");
            Console.WriteLine(string.Join(", ", WinningNumbers));
        }
        else
        {
            Console.WriteLine("   ");
        }

        if (WinningNumbers.Count == limit)
        {
            Console.WriteLine("Wow! You won 5 cents!!!!!");
        }
        else
        {
            Console.WriteLine("Sorry, mate, you are a loser!");
        }
        Console.WriteLine("                                     ");
        Console.WriteLine("Would you like to play again ??(yes/no)");
        string PlayAgain = Console.ReadLine().ToLower();
        if (PlayAgain != "yes")
            return;
        else
            Main(arg);



        static int[] UserNumber(int limit)  ////
        {
            Console.WriteLine("----------- Welcome to Mike's Lottery ---------------");
            Console.WriteLine("----- You wanna win 5 cents? This is the moment -----");
            Console.WriteLine("--------- Type 4 numbers between 1 and 20 ------------");
            Console.WriteLine("--------------- separated by spaces ------------------");

            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            if (numbers.Length != limit)
            {
                Console.WriteLine("Bro !! I told you, you need to type just numbers .");
                Console.WriteLine("                                     ");
                return UserNumber(limit);
            }

            int[] UserNumbers = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                if (!int.TryParse(numbers[i], out UserNumbers[i]) || UserNumbers[i] < low || UserNumbers[i] > high)
                {
                    Console.WriteLine("Bro !! I told you, just 4 numbers between" + low + " to " + high);
                    Console.WriteLine("                                                ");
                    return UserNumber(limit);
                }
            }

            return UserNumbers;
        }

        static int[] RandomNumber(int limit)
        {
            Random random = new Random();
            int[] randomNumber = new int[limit];

            for (int i = 0; i < limit; i++)
            {
                randomNumber[i] = random.Next(low, high);
            }

            return randomNumber;
        }

        static int BinarySearch(int[] arr, int x)
        {
            int low = 0, high = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == x)
                    return mid;

                if (arr[mid] < x)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
        static bool LinearSearch(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                        return true;
                }
            }
            return false;
        }
    }
}