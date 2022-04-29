using System;
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
        static void Main (string[] args) {
            string rawData = "Hello World!";
            for (int i = 1; i <= 10; i++) {
                string hash = CalculateHash (rawData);
                Console.WriteLine (hash);
            }
        }
    }
}