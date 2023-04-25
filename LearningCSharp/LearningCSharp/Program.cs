using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine is used to write out information into the console
            //Console.WriteLine("This is my first documented line of code in C#");
            //Console.WriteLine("   /|");
            //Console.WriteLine("  / |");
            //Console.WriteLine(" /  |");
            //Console.WriteLine("/___|");
            //Essentialy keeps the Console up until a key is registered
            //Console.ReadLine();

            //--------------------------------------------------------------

            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.BackgroundColor = ConsoleColor.Yellow;

            //Console.Clear();

            //Console.WriteLine("There once was a man named John");
            //Console.WriteLine("He was 70 years old");
            //Console.WriteLine("He really liked the name John");
            //Console.WriteLine("But didn't like being 35");

            //Console.ReadKey();

            //--------------------------------------------------------------

            //Console.Write("What is your name? ");
            //string name = Console.ReadLine();
            //Console.WriteLine($"Hello {name}");
            //Console.ReadKey();

            //--------------------------------------------------------------

            //bool canIVote = true;

            //Console.WriteLine("Biggest Integer: {0}", int.MaxValue);
            //Console.WriteLine("Smallest Integer: {0}", int.MinValue);

            //Console.WriteLine("Biggest Long: {0}", long.MaxValue);
            //Console.WriteLine("Smalles Long: {0}", long.MinValue);

            //decimal decPiVal = 3.1415926535897932384626433832M;
            //decimal decBigNum = 3.00000000000000000000000000011M;
            //Console.WriteLine("Dec: PI + bigNum = {0}", decPiVal + decBigNum);

            //Console.WriteLine("Biggest Decimal: {0}", Decimal.MaxValue);
            //Console.WriteLine("Smalles Decimal: {0}", Decimal.MinValue);

            //Console.WriteLine("Biggest Double: {0}", Double.MaxValue);
            //Console.WriteLine("Smalles Double: {0}", Double.MinValue);

            //double dblPiVal = 3.14159265358979;
            //double dblBigNum = 3.00000000000002;
            //Console.WriteLine("DBL: pi + bigNum = {0}", dblPiVal + dblBigNum);

            //Console.WriteLine("Biggest Float: {0}", float.MaxValue);
            //Console.WriteLine("Smalles Float: {0}", float.MinValue);

            //float fltPiVal = 3.141592F;
            //float fltBigNum = 3.000002F;
            //Console.WriteLine("FLT: pi + bigNum = {0}", fltPiVal + fltBigNum);



            //Console.ReadKey();

            //--------------------------------------------------------------

            //bool boolFromStr = bool.Parse("true");
            //int intFromStr = int.Parse("1000");
            //double dblFromStr = double.Parse("1.2345");
            //float fltFromStr = float.Parse("1.234");

            //string strVal = dblFromStr.ToString();
            //Console.WriteLine($"Data type: {strVal.GetType()}");
            //double dblNum = 12.345;
            //Console.WriteLine($"Integer : {(int)dblNum}"); //Explicit conversion, loses information
            //int intNum = 10;
            //long longNum = intNum; //Implicit conversion, doesnt lose any data

            //Console.ReadKey();

            //--------------------------------------------------------------

            //Console.WriteLine("Currency : {0:c}", 23.455);//Formats as if it is currency
            //Console.WriteLine("Pad with 0s : {0:d4}", 23);//fills with 0s until getting the n of digits
            //Console.WriteLine("3 decimals : {0:f3}", 23.455555); //Rounds it to 3 decimals
            //Console.WriteLine("Commas: {0:n3}", 2300); //Sets a comma and adds n 0s after point
            //Console.ReadKey();

            //--------------------------------------------------------------

            string randString = "This is a string";
            Console.WriteLine("String lenght: {0}", randString.Length);

            Console.WriteLine("String Contains is: {0}", randString.Contains("is"));

            Console.WriteLine("Index of is: {0}", randString.IndexOf("is"));

            Console.WriteLine("Remove String: {0}",
                randString.Remove(10, 6));//Removes from index 10 to 6

            Console.WriteLine("Insert String: {0}", randString.Insert(10, "short "));

            Console.WriteLine("Replace String: {0}",
                randString.Replace("string", "sentence"));

            Console.WriteLine("Compare A to B: {0}",
                String.Compare("A", "B", StringComparison.OrdinalIgnoreCase));

            // Compare strings and ignore case
            // < 0 : str1 preceeds str2
            // = : Zero
            // > 0 : str2 preceeds str1
            
            Console.WriteLine("-------------------------");
            Console.WriteLine("A = a: {0}", 
                String.Compare("A", "a", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Pad Left : {0}", 
                String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Pad Left: {0}", randString.PadLeft(20, '.'));

            Console.WriteLine("Pad Right: {0}", randString.PadRight(20, '.'));

            Console.WriteLine("Trim: {0}", randString.Trim());

            Console.WriteLine("Uppercase: {0}", randString.ToUpper());

            Console.WriteLine("Lower: {0}", randString.ToLower());

            string newString = String.Format("{0} saw a {1} {2} in the {3}",
                "Paul", "rabbit", "eating", "field");
            Console.Write(newString + "\n");




            Console.ReadKey();


            //--------------------------------------------------------------

            Console.ReadKey();

            //--------------------------------------------------------------

            Console.ReadKey();

            //--------------------------------------------------------------

            Console.ReadKey();

            //--------------------------------------------------------------


        }
    }
}
