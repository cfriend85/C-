﻿using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Basic 13!");
            PrintNumbers();
            PrintOdds();
            PrintSum();
            LoopArray(new int[5] {1,2,3,4,5});
            Console.WriteLine(FindMax(new int[10] {5,15,-1,25,88,-3,15,-2,157,0}));
            GetAverage(new int[] {1,2,3,4,5});
            Console.WriteLine(OddArray());
            Console.WriteLine(GreaterThanY(new int[] {15,33,1,25,152,89,99,12,0,18,22,37}, 15));
            SquareArrayValues(new int[] {1,5,10,-10});
            EliminateNegatives(new int[] {1,5,10,-2});
            MinMaxAverage(new int[] {1,2,3,4,5});
        }
        public static void PrintNumbers()
        {
            for(int i = 0; i < 256; i++){
                Console.WriteLine(i);
            }
        }
        public static void PrintOdds()
        {
            for(int i = 0; i < 256; i++){
                if(i % 3 == 0){
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintSum()
        {
            int sum = 0;
            for(int i = 0; i < 256; i++){
                sum += i;
                Console.WriteLine($"New number: {i} Sum: {sum}");
            }
        }
        public static void LoopArray(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++){
                Console.WriteLine(numbers[i]);
            }
        }
        public static int FindMax(int[] numbers)
        {
            int max = numbers[0];
            for(int i = 1; i < numbers.Length; i++){
                if(numbers[i] > max){
                    max = numbers[i];
                }
            }
            return max;
        }
        public static void GetAverage(int[] numbers)
        {
            int sum = numbers[0];
            for(int i = 1; i < numbers.Length; i++){
                sum += numbers[i];
            }
            Console.WriteLine(sum / numbers.Length);
        }
        public static int[] OddArray()
        {
            int[] odds = new int[86];
            int count = 0;
            for(int i = 0; i < 256; i++){
                if(i % 3 == 0){
                    odds[count] = i;
                    count += 1;
                }
            }
            Console.WriteLine(string.Join(", ", odds));
            return odds;   
        }
        public static int GreaterThanY(int[] numbers, int y)
        {
            int count = 0;
            for(int i = 0; i < numbers.Length; i++){
                if(numbers[i] > y){
                    count += 1;
                }
            }
            return count;
        }
        public static void SquareArrayValues(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++){
                numbers[i] = numbers[i] * numbers[i];
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
        public static void EliminateNegatives(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++){
                if(numbers[i] < 0){
                    numbers[i] = 0;
                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
        public static void MinMaxAverage(int[] numbers)
        {
            int min = numbers[0];
            int max = numbers[0];
            int sum = numbers[0];
            for(int i = 1; i < numbers.Length; i++){
                if(numbers[i] < min){
                    min = numbers[i];
                    sum += numbers[i];
                }
                else if(numbers[i] > max){
                    max = numbers[i];
                    sum += numbers[i];
                }
                else{
                    sum += numbers[i];
                }
            }
            Console.WriteLine($"min: {min}");
            Console.WriteLine($"max: {max}");
            Console.WriteLine($"avg: {sum / numbers.Length}");
        }
    }
}
