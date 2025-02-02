﻿using System;

namespace HW1Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string encryptedResult = "";
            while (true)
            {
                Console.Write("Do you wish to Encode(E) or Decode(D) an input?: ");
                string encDecDecision = Console.ReadLine();
                
                if (encDecDecision.Equals("E") || encDecDecision.Equals("e"))                   // Encode option
                {
                    Console.Write("Input the plaintext you want to encode: ");
                    userInput = Console.ReadLine();
                    Console.Write("What is your key: ");
                    string userShift = Console.ReadLine();
                    encryptedResult = EncDec(userInput, 1, Convert.ToInt32(userShift));
                    Console.WriteLine("Ciphertext Message: " + encryptedResult);
                    
                }
                if (encDecDecision.Equals("D") || encDecDecision.Equals("d"))
                {
                    string useEncryptedMessage;
                    string decryptedResult;
                    if (encryptedResult.Length != 0)
                    {
                        Console.Write("You have a previously saved ciphertext message, would you like to decryt it (y yes, n no): ");
                        useEncryptedMessage = Console.ReadLine();
                        
                        if (useEncryptedMessage.Equals("y") || useEncryptedMessage.Equals("Y"))
                        {
                            userInput = encryptedResult;
                            Console.WriteLine("Using previously encryped message for decrypting: " + userInput);
                            Console.Write("What is your key: ");
                            string userShift = Console.ReadLine();
                            decryptedResult = EncDec(userInput, 2, Convert.ToInt32(userShift));
                            Console.WriteLine("Decrpyted Message: " + decryptedResult);
                            userInput = "";
                        }
                        else
                        {
                            Console.Write("Input the ciphertext you want to decrypt: ");
                            userInput = Console.ReadLine();
                            Console.Write("What is your key: ");
                            string userShift = Console.ReadLine();
                            decryptedResult = EncDec(userInput, 2, Convert.ToInt32(userShift));
                            Console.WriteLine("Plaintext Message: " + decryptedResult);
                        }
                    }
                    else
                    {
                        Console.Write("Input the ciphertext you want to decrypt: ");
                        userInput = Console.ReadLine();
                        Console.Write("What is your key: ");
                        string userShift = Console.ReadLine();
                        decryptedResult = EncDec(userInput, 2, Convert.ToInt32(userShift));
                        Console.WriteLine("Plaintext Message: " + decryptedResult);
                    }
                }
            }
        }


        static String EncDec(String input, int decision, int amount)
        {
            string result = "";
            int modifiedAmount = amount;
            if(decision == 2)
            {
                modifiedAmount *= -1;
            }
            for (int i = 0; i < input.Length; i++)
            {
                string temp = input.Substring(i, 1);
                char tempChar = temp.ToCharArray()[0];
                char printOrigChar = tempChar;
                
                if (!Char.IsWhiteSpace(tempChar))
                {
                    int tempCharNumber = (byte)tempChar + modifiedAmount;
                    if(printOrigChar >= 65 && printOrigChar <= 90)              // if our number is between upper case chars
                    {
                        if (tempCharNumber > 90 || tempCharNumber < 65)
                        {
                            int difference = 90 - 65;
                            if (modifiedAmount > 0)                                  // D
                            {
                                tempChar = (char)((byte)(tempCharNumber - difference));
                            }
                            else
                            {
                                tempChar = (char)((byte)(tempCharNumber + difference));
                            }
                        }
                        else
                        {
                            tempChar = (char)tempCharNumber;
                        }
                    }
                    else
                    {
                        int difference = 97 - 122;
                        if(tempCharNumber > 122 || tempCharNumber < 97)
                        {
                            if (modifiedAmount > 0)                                  // D
                            {
                                tempChar = (char)((byte)(tempCharNumber + difference));
                            }
                            else
                            {
                                tempChar = (char)((byte)(tempCharNumber - difference));
                            }
                        }
                        else
                        {
                            tempChar = (char)tempCharNumber;
                        }
                    }
                    
                }
                result = result + tempChar;
                Console.WriteLine("Current char ascii: " + (byte)printOrigChar + " End Char Ascii: " + (byte)tempChar);
                Console.WriteLine("Current char: " + temp + " End Char: " + tempChar);
            }

            return result;
        }
    }
}
