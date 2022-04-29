using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Sha256HashCode {
    class Program {
        /// <summary>
        /// Calculate 256 Hash code
        /// </summary>
        /// <param name="rawData">Hash would be generated for given input string (raw data string)</param>
        /// <returns>returns hash code</returns>
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

                // returns byte string
                return builder.ToString ();
            }
        }

        /// <summary>
        /// Generate Hashcode with minor Data Change
        /// </summary>
        public static void GenerateHashcodeWithMinorDataChange () {
            string rawData = "Hello World!";
            string hash = CalculateHash (rawData);
            Console.WriteLine (hash + " input Data " + rawData);

            rawData = "Hello World;";
            hash = CalculateHash (rawData);
            Console.WriteLine (hash + " input Data " + rawData);

        }

        /// <summary>
        /// Generate Hashcode Without Data Change
        /// </summary>
        public static void GenerateHashcodeWithoutDataChange () {
            string rawData = "Hello World!";
            for (int i = 1; i <= 10; i++) {
                string hash = CalculateHash (rawData);
                Console.WriteLine (hash + " input Data " + rawData);
            }
        }
        /// <summary>
        ///  Generate Hashcode With Data Change
        /// </summary>
        public static void GenerateHashcodeWithDataChange () {
            for (int i = 1; i <= 10; i++) {
                string rawData = "Hello World!" + i.ToString ();
                string hash = CalculateHash (rawData);
                Console.WriteLine (hash + " input Data " + rawData);
            }
        }

        /// <summary>
        /// Generate Hashcode With Difficulty Level
        /// </summary>
        /// <param name="difficultyLevel">Difficulty Level</param>

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
            }
            Console.WriteLine (hash + " input Data " + rawData);
        }

        /// <summary>
        /// Generate Hashcode With Difficulty Level
        /// </summary>

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

        public static void Main (string[] args) {
            Console.WriteLine ("Observe the Hash code DID NOT change as the input data is same");
            GenerateHashcodeWithoutDataChange ();

            Console.WriteLine ("Observe the Hash code changes as the input data changes");
            GenerateHashcodeWithMinorDataChange ();

            // Console.WriteLine ("Observe the Hash code changes as the input data changes");
            // GenerateHashcodeWithDataChange ();

            // GenerateHashcodeWithDifficultyLevel ();
        }

        private static Decimal ParseHexString (string hexNumber) {
            hexNumber = hexNumber.Replace ("x", string.Empty);
            long result = 0;
            long.TryParse (hexNumber, System.Globalization.NumberStyles.HexNumber, null, out result);
            return result;
        }

        private static void ConvertHexNumberToDecimalNumber () {
            string hex1 = "7f83b1657ff1fc53b92dc18148a1d65dfc2d4b1fa3d677284addd200126d9069";
            Console.WriteLine (ParseHexString (hex1));

            string hex2 = "cbd2ca479c9549ab5f19aebf4126eef2f516dd24d35a5a7f4bf05e7920cc5a7b";
            Console.WriteLine (ParseHexString (hex2));
        }
    }
}