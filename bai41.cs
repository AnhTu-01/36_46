using System;
using System.Collections.Generic;

namespace ListOfListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Khởi tạo List<List<string>>
            List<List<string>> myList = new List<List<string>>(); 
            myList.Add(new List<string> { "a", "b" }); 
            myList.Add(new List<string> { "c", "d", "e" }); 
            myList.Add(new List<string> { "qwerty", "asdf", "zxcv" }); 
            myList.Add(new List<string> { "a", "b" }); 
            
            // Duyệt qua List<List<string>> sử dụng foreach
            Console.WriteLine("Duyệt qua List<List<string>> sử dụng foreach:");
            foreach (List<string> subList in myList) 
            { 
                foreach (string item in subList) 
                { 
                    Console.WriteLine(item); 
                } 
            }

            // Duyệt qua List<List<string>> sử dụng for theo chỉ số
            Console.WriteLine("\nDuyệt qua List<List<string>> sử dụng for theo chỉ số:");
            for (int i = 0; i < myList.Count; i++)
            {
                List<string> subList = myList[i];
                for (int j = 0; j < subList.Count; j++)
                {
                    Console.WriteLine(subList[j]);
                }
            }
        }
    }
}