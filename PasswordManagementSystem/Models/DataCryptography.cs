using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Models
{
    public class Hash
    {

        private char[] UpperCase;

        public Hash()
        {
            this.UpperCase = new char[26];

            for (int i = 0; i < 26; i++)
            {
                this.UpperCase[i] = (char)(65 + i);
            }
            return;
        }

        public string Encrypt(string code)
        {
            string newCodeHash = "LD8x";
            string newCodeHashNum = "";

            int codeLength = code.Length;
            int codeHashNum = 0;

            for (int i = 0; i < codeLength; i++)
            {
                codeHashNum += code[i] + (codeLength * 2);
            }

            codeHashNum += ((codeHashNum * codeHashNum) / 2);
            codeHashNum += (codeLength * codeHashNum);
            newCodeHashNum = Convert.ToString(codeHashNum);

            for (int i = 0; i < newCodeHashNum.Length; i++)
            {
                int index = codeHashNum % 10;
                newCodeHash += newCodeHashNum[i];
                newCodeHash += this.UpperCase[index];
                codeHashNum /= 10;
            }

            return newCodeHash;
        }
    }

    public class DataCryptography
    {
        private long PrivateKey;
        
        public long GetPrivateKey(){
            return this.PrivateKey;
        }

        public DataCryptography(int KeyLength)
        {
            this.PrivateKey = 0;
            GenerateKey(KeyLength);
            return;
        }

        public DataCryptography()
        {
            this.PrivateKey = 0;
            GenerateKey((new Random().Next(4, 8) + 1));
            return;
        }

        private void GenerateKey(int KeyLength)
        {
            Random randomNumber = new Random();
            for (int j = 0; j < KeyLength; j++)
            {
                this.PrivateKey = (
                    this.PrivateKey * 10
                ) + (randomNumber.Next(9) + 1);
            }
            return;
        }

        public string Encrypt(string code, long? key = null)
        {
            if (key != null)
            {
                this.PrivateKey = (long)key;
            }
            string newCode = "";
            int ascii = 0;
            long copyKey = this.PrivateKey;

            for (int i = 0; i < code.Length; i++)
            {
                ascii = (int)code[i];

                if (copyKey == 0)
                {
                    copyKey = this.PrivateKey;
                }
                ascii += Convert.ToInt32((copyKey % 10));
                copyKey /= 10;

                if (ascii >= 127)
                {
                    ascii -= 95;
                }
                newCode += (char)ascii;
            }

            return newCode;
        }

        public string Decrypt(string code, long? key = null)
        {
            if (key != null)
            {
                this.PrivateKey = (long)key;
            }
            string newCode = "";
            int ascii = 0;
            long copyKey = 0;

            for (int i = 0; i < code.Length; i++)
            {
                ascii = (int)code[i];

                if (copyKey == 0)
                {
                    copyKey = this.PrivateKey;
                }
                ascii -= Convert.ToInt32((copyKey % 10));
                copyKey /= 10;

                if (ascii <= 31)
                {
                    ascii += 95;
                }

                newCode += (char)ascii;
            }
            return newCode;
        }
    }
}
