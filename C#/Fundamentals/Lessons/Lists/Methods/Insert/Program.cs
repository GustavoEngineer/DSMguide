using System;
using System.Collections.Generic;

namespace Clear
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> playlistMusica = new List<string>
            {
                "Canción 1",
                "Canción 2",
                "Canción 4",
            };

            playlistMusica.Insert(3, "Canción 3");
            Console.WriteLine("Playlist Actualizada:");
            for (int i = 0; i < playlistMusica.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {playlistMusica[i]}");
            }
        }
    }
}