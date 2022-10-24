using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace learning
{
    internal class Program
    {
        static string input;
        static List<char> output = new List<char>() { };
        static int letter_index;
        static List<char> alphabet = new List<char>() {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static List<string> Morse_alphabet = new List<string>() { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.."};
        static List<char> atbash_alphabet = new List<char>() { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };

        public static void Morse()
        {
            string Morse_output = "";
            for (int i = 0; i < input.Count(); i++)
            {
                if (alphabet.Contains(input[i]))//checks if the letter exists in English alphabet
                {
                    letter_index = alphabet.IndexOf(input[i]);//gets the number of letter in English alphabet
                    Morse_output = string.Concat(Morse_output, Morse_alphabet[letter_index]);
                    
                }
                else { Morse_output = string.Concat(Morse_output, Convert.ToString(input[i])); }
            }
            Console.Clear();
            Console.WriteLine($"{input} -> {Morse_output}");
        }
        public static void Atbash()
        {
            for (int i = 0; i < input.Count(); i++)
            {
                if (alphabet.Contains(input[i]))//checks if the letter exists in English alphabet
                {
                    letter_index = alphabet.IndexOf(input[i]);
                    output.Add(atbash_alphabet[letter_index]);
                }
                else { output.Add(input[i]); }
            }
            Console.Clear();
            Console.WriteLine($"{input} -> {String.Concat(output)}");
        }
        public static void Caesar()
        {
            Console.WriteLine("Enter offset:");
            int offset = Convert.ToInt16(Console.ReadLine());
            for (int i = 0; i < input.Count(); i++)
            {
                if (alphabet.Contains(input[i]))//checks if the letter exists in English alphabet
                {
                    letter_index = alphabet.IndexOf(input[i]);
                    if (letter_index + offset > 25) { letter_index-=25; }
                    output.Add(alphabet[letter_index + offset]);
                }
                else { output.Add(input[i]); }
            }
            Console.Clear();
            Console.WriteLine($"{input} -> {String.Concat(output)}");
        }
        static void Main()
        {
            Console.WriteLine("Enter text: ");
            input = (Console.ReadLine().ToLower());
            Console.Write("Choose the cipher: \n1 = Morse\n2 = Atbash\n3 = Cesaurus\n");
            int cipher = Convert.ToInt16(Console.ReadLine());
            if (cipher == 1) { Morse(); Console.ReadKey(); }
            if (cipher == 2) { Atbash(); Console.ReadKey(); }
            if (cipher == 3) { Caesar(); Console.ReadKey(); }
        }
    }
}