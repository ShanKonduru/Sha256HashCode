using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Sha256HashCode {
    class Program {
        public static string CalculateHash (string rawData) {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create ()) {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash (Encoding.UTF8.GetBytes (rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder ();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append (bytes[i].ToString ("x2"));
                }
                return builder.ToString ();
            }
        }

        public static void GenerateHashcodeWithoutDataChange () {
            string rawData = "Hello World!";
            for (int i = 1; i <= 10; i++) {
                string hash = CalculateHash (rawData);
                Console.WriteLine (hash + " input Data " + rawData);
            }
        }

        public static void GenerateHashcodeWithDataChange () {
            for (int i = 1; i <= 10; i++) {
                string rawData = "Hello World!" + i.ToString ();
                string hash = CalculateHash (rawData);
                Console.WriteLine (hash + " input Data " + rawData);
            }
        }

        public static void GenerateHashcodeWithDifficultyLevel (int difficultyLevel) {
            string rawData = "Hello World!";
            int numberOfInterations = 0;
            string hashValidationTemplate = new String ('0', difficultyLevel);
            rawData = "Hello World!" + numberOfInterations.ToString ();
            string hash = CalculateHash (rawData);
            while (hash.Substring (0, difficultyLevel) != hashValidationTemplate) {
                //// Console.WriteLine (hash);
                rawData = "Hello World!" + numberOfInterations.ToString ();
                hash = CalculateHash (rawData);
                numberOfInterations++;
                //// Console.Write (numberOfInterations + ", ");
            }
            Console.WriteLine (hash + " input Data " + rawData);
        }

        public static void GenerateHashcodeWithDifficultyLevel () {
            int difficultyLevel = 1;
            int maxdifficultyLevel = 5;

            for (int i = difficultyLevel; i <= maxdifficultyLevel; i++) {
                Stopwatch stopwatch = new Stopwatch ();
                stopwatch.Start ();
                GenerateHashcodeWithDifficultyLevel (i);
                stopwatch.Stop ();
                Console.WriteLine ("Observe the Hash code when the Difficulty Level is " + i.ToString ());
                Console.WriteLine ("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            }
        }

        static void Main (string[] args) {
            /*
            Console.WriteLine ("Observe the Hash code DID NOT change as the input data is same");
            GenerateHashcodeWithoutDataChange ();
            Console.WriteLine ("Observe the Hash code changes as the input data changes");
            GenerateHashcodeWithDataChange ();
            */
            GenerateHashcodeWithDifficultyLevel ();
        }
    }
}