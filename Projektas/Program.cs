using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

//References:

//PLINQ WithDegreeOfParallelism sets the strict amount of threads, not like Parallel MaxDegreeOfParallelism
//https://devblogs.microsoft.com/pfxteam/paralleloptions-maxdegreeofparallelism-vs-plinqs-withdegreeofparallelism/

//Create encryptor
//https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.symmetricalgorithm.createencryptor?view=net-6.0

//Create decryptor
//https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.symmetricalgorithm.createdecryptor?view=net-6.0

//Initialization vector (otherwise known as "IV" - property used when encrypting decrypting text)
//https://en.wikipedia.org/wiki/Initialization_vector

namespace Projektas
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputFileNames = Directory.GetFiles(Directory.GetCurrentDirectory() + "/Data", "*.txt");
            foreach (string filePath in inputFileNames)
            {
                string fileName = Path.GetFileName(filePath);
                FileInfo fileInfo = new FileInfo(filePath);
                long fileSizeInBytes = fileInfo.Length;

                Console.WriteLine(new string('=', 50));
                Console.WriteLine("Testing with file: " + fileName + " File size: " + fileSizeInBytes + " Bytes");

                EncryptAndDecryptFile_UsingLinq(filePath, fileName);
                EncryptAndDecryptFile_UsingPLinq(2, filePath, fileName);
                EncryptAndDecryptFile_UsingPLinq(4, filePath, fileName);
                EncryptAndDecryptFile_UsingPLinq(6, filePath, fileName);
                EncryptAndDecryptFile_UsingPLinq(8, filePath, fileName);
                EncryptAndDecryptFile_UsingPLinq(12, filePath, fileName);
                EncryptAndDecryptFile_UsingPLinq(16, filePath, fileName);

                Console.WriteLine();
            }
        }

        private static void EncryptAndDecryptFile_UsingPLinq(int threadCount, string filePath, string fileName)
        {
            string ResultFilePath = Directory.GetCurrentDirectory() + "/Results/";
            string encryptedFileName = ResultFilePath + fileName + "_ResultsParallel_Encrypted.txt";
            string decryptedFileName = ResultFilePath + fileName + "_ResultsParallel_Decrypted.txt";
           
            Console.WriteLine();
            Console.WriteLine("Results using Parallel Linq. Used Threads: " + threadCount);

            LinqUtils.Parallel_EncryptFiles(threadCount, filePath, encryptedFileName);
            LinqUtils.Parallel_DecryptFiles(threadCount, encryptedFileName, decryptedFileName);
            LinqUtils.CompareFiles(filePath, decryptedFileName);
        }

        private static void EncryptAndDecryptFile_UsingLinq(string filePath, string fileName)
        {
            string ResultFilePath = Directory.GetCurrentDirectory() + "/Results/";
            string encryptedFileName = ResultFilePath + fileName + "_ResultsParallel_Encrypted.txt";
            string decryptedFileName = ResultFilePath + fileName + "_ResultsParallel_Decrypted.txt";

            Console.WriteLine();
            Console.WriteLine("Results using standard Linq");
            LinqUtils.Linq_EncryptFiles(filePath, encryptedFileName);
            LinqUtils.Linq_DecryptFiles(encryptedFileName, decryptedFileName);
            LinqUtils.CompareFiles(filePath, decryptedFileName);

        }
    }
}