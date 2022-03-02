using System;
using System.Collections.Generic;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create

            #region Arrays
            // Create an integer Array of size 50-done
            var numbers = new int[50];
            //Create a method to populate the number array with 50 random numbers that are between 0 and 50-done
            Populater(numbers);

            //Print the first number of the array-done
            Console.WriteLine($"{numbers[0]}");
            //Print the last number of the array-done     
            Console.WriteLine($"{numbers[numbers.Length - 1]}");
            Console.WriteLine("All Numbers Original");
            //Use this method to print out your numbers from arrays or lists-done
            NumberPrinter(numbers);
            Console.WriteLine("-------------------");

            //Reverse the contents of the array and then print the array out to the console.-done
            //Try for 2 different ways -done and done
            /*     Hint: Array._____(); Create a custom method     */

            Console.WriteLine("All Numbers Reversed:");
            ReverseArray(numbers);
            Console.WriteLine("---------REVERSE CUSTOM------------");
            CustomReverseArray(numbers);

            Console.WriteLine("-------------------");

            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers -done
            Console.WriteLine("Multiple of three = 0: ");
            ThreeKiller(numbers);

            Console.WriteLine("-------------------");

            //Sort the array in order now -done
            /*      Hint: Array.____()      */
            Console.WriteLine("Sorted numbers:");
            Array.Sort(numbers);
            NumberPrinter(numbers);

            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //Create an integer List - done
            var numList = new List<int>();

            //Print the capacity of the list to the console - done
            Console.WriteLine($"The capacity of our number list is: {numList.Count}");

            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this  -done 
            Populater(numList);
            //Print the new capacity -done
            Console.WriteLine($"The new capacity of our number list is: {numList.Count}");

            Console.WriteLine("---------------------");

            //Create a method that prints if a user number is present in the list -done
            //Remember: What if the user types "abc" accident your app should handle that! -done
            Console.WriteLine("What number will you search for in the number list?");
            var isParseable = int.TryParse(Console.ReadLine(), out int userNumber);
            while (isParseable == false || userNumber > 50 || userNumber <0)
            {
                Console.WriteLine($"Please enter a valid integer between 0 and 50:");
                isParseable = int.TryParse(Console.ReadLine(), out userNumber);
            }
            NumberChecker(numList, userNumber);

            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //Print all numbers in the list -done
            NumberPrinter(numList);
            Console.WriteLine("-------------------");

            //Create a method that will remove all odd numbers from the list then print results -done
            Console.WriteLine("Evens Only!!");
            OddKiller(numList);
            Console.WriteLine("------------------");

            //Sort the list then print results -done
            numList.Sort();
            Console.WriteLine("Sorted Evens!!");
            NumberPrinter(numList);
            Console.WriteLine("------------------");

            //Convert the list to an array and store that into a variable -done
            var numListArray = numList.ToArray();

            //Clear the list -done
            numList.Clear();

            #endregion
        }
        private static void ThreeKiller(int[] numbers)
        {
            //Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            for (int i = 0; i<numbers.Length; i++)
            {
                if (numbers[i] % 3 == 0)
                {
                    numbers[i] = 0;
                }
            }
            NumberPrinter(numbers);
        }

        private static void OddKiller(List<int> numberList)
        {
            //Create a method that will remove all odd numbers from the list then print results
            //foreach (var number in numberList)
            for (int i = 0; i < numberList.Count; i++)
            {
                if (numberList[i] % 2 != 0)
                {
                    numberList.RemoveAt(i);
                    if(i == 0)
                    {
                        i = 0;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            NumberPrinter(numberList);
        }

        private static void NumberChecker(List<int> numberList, int searchNumber)
        {
            if (numberList.Contains(searchNumber))
            {
                Console.WriteLine($"Yes, the number list contains your value of {searchNumber}!");
            }
            else
            {
                Console.WriteLine($"Sorry, but the number list does not contain your value of {searchNumber}!");
            }
        }

        private static void Populater(List<int> numberList)
        {
            //Populate the List with 50 random numbers between 0 and 50 you will need a method for this    
            
            for (var i = 0; i < 50; i++)
            {
                Random rng = new Random();
                numberList.Add(rng.Next(0, 50));
            }
            //NumberPrinter(numberList);

        }

        private static void Populater(int[] numbers)
        {
            //Create a method to populate the number array with 50 random numbers that are between 0 and 50
            
            for (int i=0; i<numbers.Length; i++)
            {
                Random rng = new Random();
                numbers[i] = rng.Next(0, 50);
            }

        }        

        private static void ReverseArray(int[] array)
        {
            Array.Reverse(array);
            NumberPrinter(array);
            Array.Reverse(array); //needed to un-reverse array
        }
        public static void CustomReverseArray(int[] array)
        { //apples = array
            var arrayReversed = new int[array.Length];
            var a = array.Length - 1;
            for (int i = 0;  i < array.Length; i++)
            {
                arrayReversed[i] = array[a--];
            }
            NumberPrinter(arrayReversed);
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
