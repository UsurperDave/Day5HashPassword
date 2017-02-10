using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Day5_Hash_Password
{
    class Program
    {
        static void Main(string[] args)
        {
            //start with index of 0 and increment 1. MD5 each time and then convert to hex. If hex starts with 5 zero's, display. Repeat 8 times.

            string input = "reyedfim";
            string inputIncrement = input;
            bool found = false;
            uint count = 0;
            int rounds = 0;

            //convert input+index (ex. abc0) to MD5
            using (MD5 md5Hash = MD5.Create())
            {
                while(found == false & rounds < 8)
                {
                    
                    inputIncrement = input + count.ToString(); 
                    
                    string hash = GetMD5Hash(md5Hash, inputIncrement);
                    
                    count++;

                    if (hash.StartsWith("00000"))
                    {
                        if (rounds >= 8)
                            found = true;
                        else
                        {
                            Console.WriteLine("Round: " + rounds.ToString());
                            rounds++;
                        }
                        //Console.WriteLine("Completed " + rounds.ToString() + " rounds.");
                        //Console.WriteLine("The MD5 hash of " + input + " is: " + hash + ".");
                        Console.WriteLine(hash.Substring(5,1));
                    }
                }

            }            

        }

        static string GetMD5Hash(MD5 md5Hash, string input)
        {
            //byte[] data = md5Hash.ComputeHash(Encoding.UTF32.GetBytes(input));
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for(int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
