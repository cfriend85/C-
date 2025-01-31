﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
namespace Algos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("JavaScript Algos To C#!");
            Console.WriteLine(addChar(29));
            Console.WriteLine(adjacentProduct(new int[] {1,2,3,4,5}));
            Console.WriteLine(angryProfessor(3, new int[] {-1,-3,4,2}));
            Console.WriteLine(binarySearch(new int[] {1, 3, 8, 10, 12, 15, 17, 20, 22, 34, 38, 40, 50, 52, 78, 87, 90, 91, 92, 94, 200}, 52));
            Console.WriteLine(birthdayCakeCandles(new int[] {3,2,1,3}));
            Console.WriteLine(camelCase("saveChangesInTheEditor"));
            Console.WriteLine(catAndMouse(2,5,4));
            compareTriplets(new int[] {5,6,7}, new int[] {3,6,10});
            Console.WriteLine(peaksAndValleys(8, "UDDDUDUU"));
            Console.WriteLine(findDigits(1012));
            Console.WriteLine(interestingPolygon(3));
            Console.WriteLine(isPalindrome("aabaa"));
            Console.WriteLine(miniMaxSum(new int[] {1,2,3,4,5}));
            plusMinus(8, new int[] {1,2,3,-1,-2,-3,0,0});
            Console.WriteLine(secondLargest(new int[] {5,15,77,64,31,99,45,17,0,25,1,65,148}));
            Console.WriteLine(simpleArraySum(new int[] {1,2,3,4,5}));
            Console.WriteLine(sortMe(new int[] {5,7,3,8,1,9}));
            Console.WriteLine(century(1999));
            Console.WriteLine(gradingStudents(new int[] {23,80,96,18,73,78,60,60,15,45,15,10,5,46,87,33,60,14,71}));
            Console.WriteLine(greet("Anakin"));
            Console.WriteLine(greet("Count Dooku"));
            Console.WriteLine(greet("C3PO"));
            ModulusNumbers();
            Console.WriteLine(chocolateFeast(10,2,5));
            Console.WriteLine(marsExploration("OOSDSSOSOSWEWSOSOSOSOSOSOSSSSOSOSOSS"));
            breakingRecords(new int[] {17,45,41,60,17,41,76,43,51,40,89,92,34,6,64,7,37,81,32,50});
            Console.WriteLine(maximumToys(new int[] {33324560,77661073,31948330,21522343,97176507,5724692,24699815,12079402,6479353,28430129,42427721,57127004,26256001,29446837,65107604,9809008,65846182,8470661,13597655,360}, 100000));
            Console.WriteLine(findMedian(new int[] {1,2,3,4,5,6,77,254,79,258,111,15,798,1001,55,41,498,38,15,1,396,7,51,10000,10001,52}));
            bigSorting(new int[] {77,15,99,15,132579,45551,3,1,7,3,5,1597,65478,132458});
            threeLargest(new int[] {10,5,9,10,12});
            threeLargest(new int[] {141,1,17,-7,-17,-27,18,541,8,7,7});
        }

        public static int addChar(int n)
        {
            int sum = 0;
            string myNum = string.Join(", ", n);
            foreach(char s in myNum)
            {
                int num = (int)Char.GetNumericValue(s);
                sum += num;
            }
            return sum;
        }

        public static int adjacentProduct(int[] numbers)
        {
            int product = numbers[0] * numbers[1];
            for(int i = 1; i < numbers.Length-1; i++){
                if (numbers[i] * numbers[i+1] > product)
                {
                    product = numbers[i] * numbers[i+1];
                }
            }
            return product;
        }

        public static string angryProfessor(int k, int[] arrivalTimes)
        {
            int count = 0;
            foreach(int i in arrivalTimes)
            {
                if (i <= 0)
                {
                    count++;
                }
            }
            return count < k ? "YES" : "NO";
        }

        public static int binarySearch(int[] array, int num)
        {
            int left = array[0];
            int right = array.Length;
            while (left <= right)
            {
                int center = left + (right - left) / 2;
                if (num == array[center])
                {
                    return center;
                }
                if (num < array[center])
                {
                    right = center - 1;
                } else
                {
                    left = center + 1;
                }
            }
            return -1;
        }

        public static int birthdayCakeCandles(int[] candles)
        {
            Array.Sort(candles);
            int count = 0;
            int max = 0;
            foreach(int i in candles)
            {
                if (i > max)
                {
                    max = i;
                    count = 1;
                } else if (i == max)
                {
                    count++;
                }
            }
            return count;
        }

        public static int camelCase(string s)
        {
            int count = 1;
            Regex rx = new Regex("[A-Z]");
            foreach(char c in s)
            {
                MatchCollection matches = rx.Matches(char.ToString(c));
                foreach(Match match in matches)
                {
                    count++;
                }
            }
            return count;
        }

        public static string catAndMouse(int x, int y, int z)
        {
            int CatA = z-x;
            int CatB = z-y;
            if (CatA > CatB)
            {
                return "Cat B";
            } else if (CatB > CatA)
            {
                return "Cat A";
            } else
            {
                return "Mouse C";
            }
        }

        public static object[] compareTriplets(int[] a, int[] b)
        {
            int alice = 0;
            int bob = 0;
            for(int i = 0; i < b.Length; i++)
            {
                if (a[i] > b[i])
                {
                    alice += 1;
                } else if (b[i] > a[i])
                {
                    bob += 1;
                } else
                {
                    Console.WriteLine("Tie!");
                }
            }
            object[] result = new object[2] {alice, bob};
            Console.WriteLine(string.Join(", ", result));
            return result;
        }

        public static int peaksAndValleys(int steps, string path)
        {
            int valleys = 0;
            int count = 0;
            foreach(char c in path)
            {
                if (c.ToString() == "U" && count == 0)
                {
                    valleys++;
                }
                if (c.ToString() == "U")
                {
                    count++;
                } else
                {
                    count--;
                }
            }
            return valleys;
        }

        public static int findDigits(int n)
        {
            string myNum = string.Join(", ", n);
            int count = 0;
            foreach(char c in myNum)
            {
                if (n % Char.GetNumericValue(c) == 0)
                {
                    count++;
                }
            }
            return count;
        }

        public static int interestingPolygon(int n)
        {
            int test = ((n-1) * (n-1));
            int result = test + n * n;
            return result;
        }


        public static bool isPalindrome(string inputString)
        {
            for(int i = 0; i < inputString.Length; i++)
            {
                for(int j = inputString.Length-1; j > 0; j--)
                {
                    if (inputString[i] == inputString[j])
                    {
                        i += 1;
                    } else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static object[] miniMaxSum(int[] numbers)
        {
            Array.Sort(numbers);
            int sum = 0;
            foreach(int num in numbers)
            {
                sum += num;
            }
            object[] result = new object[] {sum - numbers[4], sum - numbers[0]};
            return result;
        }

        public static void plusMinus(int n, int[] numbers)
        {
            int x = numbers.Length;
            int pos = 0;
            int neg = 0;
            int zero = 0;
            foreach(int num in numbers)
            {
                if (num > 0)
                {
                    pos += 1;
                } else if (num < 0)
                {
                    neg += 1;
                } else
                {
                    zero += 1;
                }
            }
            double posRatio = (double)pos / n;
            double negRatio = (double)neg / n;
            double zeroRatio = (double)zero / n;
            Console.WriteLine(posRatio.ToString("N6"));
            Console.WriteLine(negRatio.ToString("N6"));
            Console.WriteLine(zeroRatio.ToString("N6"));
        }

        public static int secondLargest(int[] numbers)
        {
            int large = numbers[0];
            int secLarge = numbers[0];
            foreach(int num in numbers)
            {
                if (num > large)
                {
                    secLarge = large;
                    large = num;
                } else if (num > secLarge && num < large)
                {
                    secLarge = num;
                }
            }
            return secLarge;
        }

        public static int simpleArraySum(int[] numbers)
        {
            int sum = 0;
            foreach(int n in numbers)
            {
                sum += n;
            }
            return sum;
        }

        public static int[] sortMe(int[] numbers)
        {
            List<int> temp = new List<int> {};
            foreach(int num in numbers)
            {
                temp.Add(num * num);
            }
            int[] result = temp.ToArray();
            Array.Sort(result);
            return result;
        }

        public static int century(int year)
        {
            int myCentury = 0;
            for(int i = 0; i < year; i++)
            {
                if (i % 100 == 0)
                {
                    myCentury++;
                }
            }
            return myCentury;
        }

        public static int[] gradingStudents(int[] grades)
        {
            for(int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < 38)
                {
                    grades[i] = grades[i];
                } else if ((grades[i]/5)*5 - grades[i] < 3)
                {
                    double result = Math.Ceiling((double)grades[i]/5 * 5);
                    grades[i] = (int)result;
                }
            }
            return grades;
        }


        public static string greet(string myName)
        {
            DateTime now = DateTime.Now;
            if (myName == "Anakin")
            {
                return $"Good Day Anakin, the current date and time is {now}";
            } else if (myName == "Count Dooku")
            {
                return $"The time is {now.ToString("hh:mm tt")} on {now.ToString("d")} and your time is coming Dooku!!!";
            } else
            {
                return "This is not the droid we're looking for";
            }
        }

        public static void ModulusNumbers()
        {
            for(int i = 0; i < 101; i++)
            {
                if (i % 15 != 0)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }

        public static int chocolateFeast(int n, int c, int m)
        {
            int chocolates = n /c;
            int wrappers = chocolates;
            while (wrappers >= m)
            {
                wrappers -= m;
                chocolates++;
                wrappers++;
            }

            return chocolates;
        }


        public static int marsExploration(string s)
        {
            int sosCount = s.Length / 3;
            int count = 0;
            string expectedString = new StringBuilder("SOS".Length * sosCount).Insert(0, "SOS", sosCount).ToString();
            for(int i = 0; i < s.Length; i++)
            {
                if (expectedString[i] != s[i])
                {
                    count++;
                }
            }
            return count;
        }


        public static object[] breakingRecords(int[] scores)
        {
            int max = scores[0];
            int min = scores[0];
            int maxCount = 0;
            int minCount = 0;
            for(int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > max)
                {
                    max = scores[i];
                    maxCount++;
                } else if (scores[i] < min)
                {
                    min = scores[i];
                    minCount++;
                }
            }
            object[] result = new object[] {maxCount, minCount};
            return result;
        }


        public static int maximumToys(int[] prices, int k)
        {
            int count = 0;
            Array.Sort(prices);
            foreach(int price in prices)
            {
                if (k >= price)
                {
                    k -= price;
                    count++;
                }
            }
            return count;
        }

        public static int findMedian(int[] numbers)
        {
            Array.Sort(numbers);
            int index = numbers.Length / 2;
            if (numbers.Length % 2 == 0)
            {
                int indexValue = (numbers[index] + numbers[index-1]) / 2;
                return indexValue;
            }
            return numbers[index];
        }


        public static int[] bigSorting(int[] unsorted)
        {
            Array.Sort(unsorted);
            foreach(int num in unsorted){
                Console.WriteLine(num);
            }
            return unsorted;
        }

        public static int[] threeLargest(int[] numbers)
        {
            int[] newArr = numbers;
            Array.Sort(newArr);
            int[] result = new int[] {newArr[newArr.Length-3], newArr[newArr.Length-2], newArr[newArr.Length-1]};
            foreach(int num in result)
            {
                Console.WriteLine(num);
            }
            return result;
        }
    }
}
