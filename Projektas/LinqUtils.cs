using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Projektas
{
    public static class LinqUtils
    {
        public static void Linq_DecryptFiles(string inputFilePath, string resultFilePath)
        {
            // Using PLINQ
            Stopwatch sq = Stopwatch.StartNew();
            string[] encryptedLines = File.ReadAllLines(inputFilePath).Select(line =>
            {
                return EncryptionUtils.Decrypt(line);
            }).ToArray();


            File.WriteAllLines(resultFilePath, encryptedLines);

            Console.WriteLine("Time taken to decrypt: " + sq.ElapsedMilliseconds + "ms");
        }

        public static void Linq_EncryptFiles(string inputFilePath, string resultFilePath)
        {
            // Using PLINQ
            Stopwatch sq = Stopwatch.StartNew();
            string[] encryptedLines = File.ReadAllLines(inputFilePath).Select(line =>
            {
                return EncryptionUtils.Crypt(line);
            }).ToArray();


            File.WriteAllLines(resultFilePath, encryptedLines);

            Console.WriteLine("Time taken to encrypt: " + sq.ElapsedMilliseconds + "ms");
        }

        public static bool CompareFiles(string dataFilePath, string decryptedFilePath)
        {
            string[] dataFileLines = File.ReadAllLines(dataFilePath);
            string[] decryptedFileLines = File.ReadAllLines(decryptedFilePath);

            bool areEqual = dataFileLines.SequenceEqual(decryptedFileLines);

            Console.WriteLine("Is original data file equal to the decrypted file?: " + areEqual);

            return areEqual;
        }

        public static void Parallel_DecryptFiles(int threadCount, string inputFilePath, string resultFilePath)
        {
            Stopwatch sq = Stopwatch.StartNew();
            string[] encryptedLines = File.ReadAllLines(inputFilePath).AsParallel().WithDegreeOfParallelism(threadCount).Select(line =>
            {
                return EncryptionUtils.Decrypt(line);
            }).ToArray();

            File.WriteAllLines(resultFilePath, encryptedLines);
            Console.WriteLine("Time taken to decrypt: " + sq.ElapsedMilliseconds + "ms");
        }

        public static void Parallel_EncryptFiles(int threadCount, string inputFilePath, string resultFilepath)
        {
            // Using PLINQ
            Stopwatch sq = Stopwatch.StartNew();
            string[] encryptedLines = File.ReadAllLines(inputFilePath).AsParallel().WithDegreeOfParallelism(threadCount).Select(line =>
            {
                return EncryptionUtils.Crypt(line);
            }).ToArray();


            File.WriteAllLines(resultFilepath, encryptedLines);

            Console.WriteLine("Time taken to encrypt: " + sq.ElapsedMilliseconds + "ms");
        }
    }
}