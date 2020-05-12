using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dynamic_array
{
    class Program
    {
        static DynArray testArray = new DynArray();

        static void Main(string[] args)
        {
            int result1 = Test1();

            Console.WriteLine();

            int[] result2 = Test2();

            Console.WriteLine();

            List<int> list = Test3(result1, result2, out int[] filledArray);

            Console.WriteLine();

            Test4(list, filledArray);

            Console.ReadLine();


        }

        private static void Test4(List<int> list, int[] filledArray)
        {
            Console.WriteLine("Test 4");

            if (CompareArrays(list.ToArray(), filledArray))
            {
                Console.WriteLine("Test 4 passed");
                Console.WriteLine("Expected result: " + GetArrayStrings(list.ToArray()) +
                                  "\nReceived result: " + GetArrayStrings(filledArray));
            }
            else
            {
                Console.WriteLine("Test 4 failed. Expected result: " + GetArrayStrings(list.ToArray()) +
                                  "\nReceived result: " + GetArrayStrings(filledArray));

                Debug.Assert(false);
            }
        }

        private static List<int> Test3(int result1, int[] result2, out int[] filledArray)
        {
            Console.WriteLine("Test 3");

            List<int> list = new List<int>();
            list.Add(result1);

            for (int i = 0; i < result2.Length; i++)
            {
                list.Add(result2[i]);
            }

            filledArray = testArray.GetFilledArray();
            int filledSize = testArray.GetFilledSize();

            if (filledArray.Length == filledSize && filledSize == list.Count)
            {
                Console.WriteLine("Test 3 passed");
            }
            else
            {
                Console.WriteLine("Test 3 failed. Unequivilency reached:\nLength of returned filled array: " +
                                  filledArray.Length + " Returned filled size: " + filledSize +
                                  " Size of trial list: " + list.Count);

                Debug.Assert(false);
            }

            return list;
        }

        
        private static int[] Test2()

        {
            int[] randomArray = new int[GetRandomInt() % 19 + 1];
            


            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = GetRandomInt() % 5;
            }

            int randomArraySize = randomArray.Length;
            Console.WriteLine("random array size :" + randomArraySize);
            int totalArraySize = randomArraySize + 1;

            for (int i = 0; i < randomArray.Length; i++)
            {
                testArray.AddInt(randomArray[i]);
            }


            Console.WriteLine("Test 2");

            Console.WriteLine(GetSmallestPower(totalArraySize));
            if (testArray.GetTotalSize() == GetSmallestPower(totalArraySize))
            {
                Console.WriteLine("Test 2 passed");
                Console.WriteLine(GetArrayStrings(testArray.GetArray()));

            }
            else
            {
                Console.WriteLine("Test 2 failed. Expected output: " + GetSmallestPower(totalArraySize) +
                                  "\nGathered output: " + testArray.GetTotalSize());

                Console.WriteLine(GetArrayStrings(testArray.GetArray()));

                Debug.Assert(false);
            }

            return randomArray;
        }
        

        private static int Test1()
        {
            int rand1 = GetRandomInt(0,5);
            testArray.AddInt(rand1);
            
            Console.WriteLine("Test 1");

            if (testArray.GetArray()[0] == rand1)
            {
                Console.WriteLine("Test 1 passed");
                

                
                
            }
            else
            {
                Console.WriteLine("Test 1 failed. Expected output: " + rand1 + "\nGathered output: " +
                                  testArray.GetArray()[0]);

                Debug.Assert(false);
            }

            return rand1;
        }


        private static int GetRandomInt()
        {
            Random rand = new Random();

            return rand.Next();
        }

        private static int GetRandomInt(int min, int max)
        {
            Random rand = new Random();

            return rand.Next(min, max);
        }

        private static int GetSmallestPower(int size)
        {
            int currentPower = 1;

            while (currentPower < size)
            {
                currentPower *= 2;


            }

            return currentPower;
        }

        private static string GetArrayStrings(int[] arrayToPrint)
        {
            string returnString = "{ ";

            for (int i = 0; i < arrayToPrint.Length; i++)
            {
                returnString += arrayToPrint[i] + ", ";
            }

            returnString = returnString.Remove(returnString.Length - 2, 2);
            returnString += " }";

            return returnString;
        }

        private static bool CompareArrays(int[] ar1, int[] ar2)
        {
            if (ar1.Length != ar2.Length)
            {
                Console.WriteLine("Arrays are not equal size");

                return false;
            }

            for (int i = 0; i < ar1.Length; i++)
            {
                if (ar1[i] != ar2[i])
                    return false;
            }

            return true;
        }
    }
}