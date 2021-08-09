﻿//Ver. 2.1.3
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SoutiesSandbox
{
    class CustomFunctions
    {
        //Creating a custom database connection
        public string CreateRemoteSQLConnection(string ServerAddress, string Port, string User, string Password, string DatabaseName)//Method to create dynamic external sql connection string
        {
            return "server=" + ServerAddress + ";port=" + Port + ";user id=" + User + ";Password=" + Password + ";database="
                + DatabaseName + "; pooling = false; convert zero datetime=True";
        }
        public (string[] StringArray, int ItemCount) ReadFromFile(string FileName)//Textfile method
        {
            string[] output = File.ReadAllLines(FileName);
            int count = File.ReadAllLines(FileName).Length;
            return (output, count);
        }
        public bool EmailVerification(string email)//Email address verification
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public void AppendToFile(string LineToAppend, string FileName)//Textfile method
        {
            System.IO.File.AppendAllText(FileName, LineToAppend);
        }
        public void WriteToFile(string[] ArrayToWrite, string FileName)//Textfile method
        {
            System.IO.File.WriteAllLines(FileName, ArrayToWrite);
        }
        public bool LuhnAlgorithm(string Number)//Method used to verify ID and Banking numbers
        {
            int j, iTemp = 0;
            char[] reverseArray = Number.ToCharArray();
            string reverseString = "";
            j = Number.Length - 1;
            if (!(int.TryParse(Number, out iTemp)))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < Number.Length; i++)
                {
                    reverseArray[i] = Number[j];
                    j--;
                }
                for (int i = 0; i < Number.Length; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        iTemp = Convert.ToInt32(reverseArray[i].ToString()) * 2;
                        if (iTemp >= 10)
                        {
                            reverseString += (iTemp - 9).ToString();
                        }
                        else
                        {
                            reverseString += iTemp.ToString();
                        }
                    }
                    else
                    {
                        reverseString += reverseArray[i];
                    }
                }
                foreach (char x in reverseString)
                {
                    iTemp += Convert.ToInt32(x.ToString());
                }
                if (iTemp % 10 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool StudentNumberVerification(string Number)//Method used to verify a nwu student number
        {
            int iTemp;
            int cSum = 0, c = 8;
            if (Number.Length != 8)
            {
                return false;
            }
            else
            {
                if (!(int.TryParse(Number, out iTemp)))
                {
                    return false;
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        cSum += (Convert.ToInt32(Number[i].ToString()) * c);
                        c--;
                    }
                    if (cSum % 11 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public int GetCountSQL(string Command, string DatabaseConnection)//Returns row count from and sql statement
        {
            int temp = 0;
            try
            {                
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(Command, conn);
                    temp = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }                
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return temp;

        }
        public string GetSingleStringSQL(string Command, string DatabaseConnection)//Returns an single value form an sql statement
        {
            string temp = "";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(Command, conn);
                    temp = sqlCommand.ExecuteScalar().ToString();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return temp;
        }
        public string[] GetStringArraySQL(string Command, string DatabaseConnection)//Returns an array of sql data
        {
            int count = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(Command, conn);
                    MySqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        count++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            string[] output = new string[count];
            try 
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection))
                {
                    count = 0;
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(Command, conn);
                    MySqlDataReader dataReader = sqlCommand.ExecuteReader();
                    while (dataReader.Read())
                    {
                        output[count] = dataReader.GetValue(0).ToString();
                        count++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return output;
        }
        public void NonQuerySQL(string Command, string DatabaseConnection)//Used for executing a non query sql statement
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DatabaseConnection))
                {
                    conn.Open();
                    MySqlCommand sqlCommand = new MySqlCommand(Command, conn);
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public string RandomPasswordGenerator(int PasswordLength)//In the name
        {
            string PasswordChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();
            char[] chars = new char[PasswordLength];
            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = PasswordChars[random.Next(0, PasswordChars.Length)];
            }
            return new string(chars);
        }
        public string UUIDGenerator()//Generates a unique 11 digit id
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }
        public string EncryptPlainTextToCipherText(string PlainText, string SecurityKey)//In the name
        {
            // Getting the bytes of Input String.
            byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            //De-allocatinng the memory after doing the Job.
            objMD5CryptoService.Clear();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;
            var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
            objTripleDESCryptoService.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public string DecryptCipherTextToPlainText(string CipherText, string SecurityKey)//In the name
        {
            byte[] toEncryptArray = Convert.FromBase64String(CipherText);
            MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();
            //Gettting the bytes from the Security Key and Passing it to compute the Corresponding Hash Value.
            byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            objMD5CryptoService.Clear();
            var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
            //Assigning the Security key to the TripleDES Service Provider.
            objTripleDESCryptoService.Key = securityKeyArray;
            //Mode of the Crypto service is Electronic Code Book.
            objTripleDESCryptoService.Mode = CipherMode.ECB;
            //Padding Mode is PKCS7 if there is any extra byte is added.
            objTripleDESCryptoService.Padding = PaddingMode.PKCS7;
            var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
            //Transform the bytes array to resultArray
            byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            objTripleDESCryptoService.Clear();
            //Convert and return the decrypted data/byte into string format.
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
}
