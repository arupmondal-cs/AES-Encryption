using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Aes_Example
{
    class AesExample
    {
        public static void Main()
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine("|        ADVANCED ENCRYPTION STANDARD (AES) ENCRYPTION SCHEME        |");
            Console.WriteLine("----------------------------------------------------------------------\n");

            // Create a new instance of the Aes
            // class.  This generates a new key and initialization 
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                string opt = "y";
                while (opt == "y")
                {
                    Console.WriteLine("\n------------------------------------");
                    Console.WriteLine("|         KEY and IV VALUE         |");
                    Console.WriteLine("------------------------------------\n");

                    Console.WriteLine("Generated 256-bit Key (Base-64): {0}", Encoding.UTF8.GetString(myAes.Key));
                    Console.WriteLine("\nGenerated 256-bit Key (Hex): {0}", BitConverter.ToString(myAes.Key));

                    Console.WriteLine("\nIV value (Hex): {0}", BitConverter.ToString(myAes.IV));


                    Console.WriteLine("\n---------------------------");
                    Console.WriteLine("|         MESSAGE         |");
                    Console.WriteLine("---------------------------\n");

                    // Create a string to encrypt.
                    Console.Write("Enter a message for encryption: ");
                    string message = Console.ReadLine();

                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes_Aes(message, myAes.Key, myAes.IV);


                    Console.WriteLine("\n-------------------------------------------");
                    Console.WriteLine("|     ENCRYPTED and DECRYPTED MESSAGE     |");
                    Console.WriteLine("-------------------------------------------\n");

                    Console.WriteLine("Encrypted Message (Base-64) \n{0}", Encoding.UTF8.GetString(encrypted));
                    Console.WriteLine("\nEncrypted Message (Hex) \n{0}", BitConverter.ToString(encrypted));


                    // Decrypt the bytes to a string.
                    string Final = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);


                    // Display the decrypted string to the console.
                    Console.WriteLine("\nDecrypted Message \n{0}", Final);


                    Console.WriteLine("\n===========================================================================\n");

                    Console.Write("Do you want to play more? (y/n): ");
                    opt = Console.ReadLine();
                }
            }
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            return plaintext;
        }
    }
}