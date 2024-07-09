using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        // Tạo danh sách các xâu kí tự
        List<string> albums = new List<string>() { "Red", "Midnight", "Reputation" };

        // Duyệt qua danh sách albums
        for (int i = 0; i < albums.Count; i++)
        {
            Console.WriteLine(albums[i]);
        }
    }
}