using System;
using Xunit;
using Projektas;
using System.IO;

namespace XUnitTestProject
{
    public class LinqUtilsTests
    {
        [Fact]
        public void Parallel_DecryptedFileIsEqualToDataFile_TestWithRandomDataFiles()
        {
            int threadCount = 4;
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileResultPath = Directory.GetCurrentDirectory() + "/ResultFiles/";
            string encryptedFileName = testFileResultPath + "TestFile_ResultsParallel_Encrypted.txt";
            string decryptedFileName = testFileResultPath + "TestFile_ResultsParallel_Decrypted.txt";

            string initialData = "awdawdgwaefwf\r\n\r\nuu\r\nadawdawf\r\n";
            File.WriteAllText(testFileDataPath, initialData);

            LinqUtils.Parallel_EncryptFiles(4, testFileDataPath, encryptedFileName);
            LinqUtils.Parallel_DecryptFiles(4, encryptedFileName, decryptedFileName);

            Assert.Equal(File.ReadAllText(testFileDataPath), File.ReadAllText(decryptedFileName));
        }
        [Fact]
        public void Parallel_DecryptedFileIsEqualToDataFile_TestWithEmptyDataFiles()
        {
            int threadCount = 4;
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileResultPath = Directory.GetCurrentDirectory() + "/ResultFiles/";
            string encryptedFileName = testFileResultPath + "TestFile_ResultsParallel_Encrypted.txt";
            string decryptedFileName = testFileResultPath + "TestFile_ResultsParallel_Decrypted.txt";

            string initialData = "";
            File.WriteAllText(testFileDataPath, initialData);

            LinqUtils.Parallel_EncryptFiles(4, testFileDataPath, encryptedFileName);
            LinqUtils.Parallel_DecryptFiles(4, encryptedFileName, decryptedFileName);

            Assert.Equal(File.ReadAllText(testFileDataPath), File.ReadAllText(decryptedFileName));
        }
        [Fact]
        public void Parallel_DecryptedFileIsEqualToDataFile_TestWithOneCharDataFiles()
        {
            int threadCount = 4;
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileResultPath = Directory.GetCurrentDirectory() + "/ResultFiles/";
            string encryptedFileName = testFileResultPath + "TestFile_ResultsParallel_Encrypted.txt";
            string decryptedFileName = testFileResultPath + "TestFile_ResultsParallel_Decrypted.txt";

            string initialData = "c\r\n";
            File.WriteAllText(testFileDataPath, initialData);

            LinqUtils.Parallel_EncryptFiles(4, testFileDataPath, encryptedFileName);
            LinqUtils.Parallel_DecryptFiles(4, encryptedFileName, decryptedFileName);

            Assert.Equal(File.ReadAllText(testFileDataPath), File.ReadAllText(decryptedFileName));
        }

        [Fact]
        public void NonParallel_DecryptedFileIsEqualToDataFile_TestWithRandomDataFiles()
        {
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileResultPath = Directory.GetCurrentDirectory() + "/ResultFiles/";
            string encryptedFileName = testFileResultPath + "TestFile_ResultsNonParallel_Encrypted.txt";
            string decryptedFileName = testFileResultPath + "TestFile_ResultsNonParallel_Decrypted.txt";

            string initialData = "awdawdgwaefwf\r\n\r\nuu\r\nadawdawf\r\n";
            File.WriteAllText(testFileDataPath, initialData);

            LinqUtils.Linq_EncryptFiles(testFileDataPath, encryptedFileName);
            LinqUtils.Linq_DecryptFiles(encryptedFileName, decryptedFileName);

            Assert.Equal(File.ReadAllText(testFileDataPath), File.ReadAllText(decryptedFileName));
        }

        [Fact]
        public void NonParallel_DecryptedFileIsEqualToDataFile_TestWithEmptyDataFiles()
        {
            int threadCount = 4;
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileResultPath = Directory.GetCurrentDirectory() + "/ResultFiles/";
            string encryptedFileName = testFileResultPath + "TestFile_ResultsNonParallel_Encrypted.txt";
            string decryptedFileName = testFileResultPath + "TestFile_ResultsNonParallel_Decrypted.txt";

            string initialData = "";
            File.WriteAllText(testFileDataPath, initialData);

            LinqUtils.Linq_EncryptFiles(testFileDataPath, encryptedFileName);
            LinqUtils.Linq_DecryptFiles(encryptedFileName, decryptedFileName);

            Assert.Equal(File.ReadAllText(testFileDataPath), File.ReadAllText(decryptedFileName));
        }
        [Fact]
        public void NonParallel_DecryptedFileIsEqualToDataFile_TestWithOneCharDataFiles()
        {
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileResultPath = Directory.GetCurrentDirectory() + "/ResultFiles/";
            string encryptedFileName = testFileResultPath + "TestFile_ResultsNonParallel_Encrypted.txt";
            string decryptedFileName = testFileResultPath + "TestFile_ResultsNonParallel_Decrypted.txt";

            string initialData = "c\r\n";
            File.WriteAllText(testFileDataPath, initialData);

            LinqUtils.Linq_EncryptFiles(testFileDataPath, encryptedFileName);
            LinqUtils.Linq_DecryptFiles(encryptedFileName, decryptedFileName);

            Assert.Equal(File.ReadAllText(testFileDataPath), File.ReadAllText(decryptedFileName));
        }

        [Fact]
        public void CompareFilesReturnsTrue_WhenTwoFilesAreEqual_TestWithEmptyFiles()
        {
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileDataPath2 = Directory.GetCurrentDirectory() + "/DataFiles/DataFile2.txt";
            string data = "";
            string data2 = "";
            File.WriteAllText(testFileDataPath, data);
            File.WriteAllText(testFileDataPath2, data2);


            bool result = LinqUtils.CompareFiles(testFileDataPath, testFileDataPath2);
            Assert.True(result);
        }

        [Fact]
        public void CompareFilesReturnsTrue_WhenTwoFilesAreEqual_TestWithRandomDataFiles()
        {
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileDataPath2 = Directory.GetCurrentDirectory() + "/DataFiles/DataFile2.txt";
            string data = "awdfeaw\r\n";
            string data2 = "awdfeaw\r\n";
            File.WriteAllText(testFileDataPath, data);
            File.WriteAllText(testFileDataPath2, data2);


            bool result = LinqUtils.CompareFiles(testFileDataPath, testFileDataPath2);
            Assert.True(result);
        }

        [Fact]
        public void CompareFilesReturnsFalse_WhenTwoFilesAreNotEqual_TestWithRandomDataFiles()
        {
            string testFileDataPath = Directory.GetCurrentDirectory() + "/DataFiles/DataFile.txt";
            string testFileDataPath2 = Directory.GetCurrentDirectory() + "/DataFiles/DataFile2.txt";
            string data = "";
            string data2 = "awdfeaw\r\n";
            File.WriteAllText(testFileDataPath, data);
            File.WriteAllText(testFileDataPath2, data2);

            bool result = LinqUtils.CompareFiles(testFileDataPath, testFileDataPath2);
            Assert.False(result);
        }
    }
}
