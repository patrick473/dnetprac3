using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace dnetprac3
{
    class Program
    {
        static void Main(string[] args) {
             String path = @"d:\randomtext.txt";
            foreach (String i in GetWords(path, s => s.StartsWith("a"))) {
                Console.Write("{0}; ", i);
            }
            String[] wordlist = GetWords(path, s => s.StartsWith("a")).ToArray() ;
            Array.Sort(wordlist, (x, y) => x.Length.CompareTo(y.Length));
            //(x, y) => x.Length.CompareTo(y.Length)
            //StringComparer.InvariantCulture
            Console.WriteLine("\n \n Gesorteerd \n");
            foreach (String i in wordlist) {
                Console.Write("{0}; ", i);
            }
            Console.ReadLine();
        }
        public static IEnumerable<String> GetWords(String path, Predicate<String> LambdaExpression) {
            if (File.Exists(path)) {
                string input = File.ReadAllText(path);
                input = Regex.Replace(input, "[@,\\.\";'\\\\]", string.Empty);
                string[] wordList = input.Split();
               
                foreach (string i in wordList) {
                    if (LambdaExpression(i)) { yield return i; }
                }
            }
            else {
                Console.WriteLine("Path is not valid");
            }
        }
    }
}