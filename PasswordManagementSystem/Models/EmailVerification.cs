using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace PasswordManagementSystem.Models
{
    public class EmailVerification
    {
        private string RandomCode;

        public EmailVerification()
        {
            this.RandomCode = "";
			GenerateCode();
            return;
        }

        public string GetCode()
        {
            return this.RandomCode;
        }

        private string GenerateCode()
        { 
            Random randomNumber = new Random();

            for (int i = 0; i < 35; i++)
            {
                this.RandomCode += Convert.ToString((randomNumber.Next(9) + 1));
            }
            return RandomCode;
        }

        public void sendVerificationCode(string email, string name)
        {
			try
            {
				DataCryptography cypher = new DataCryptography();

				string filePath = @"E:\Code_Codes\C#\GUI\PasswordManagementSystem\PasswordManagementSystem\Models\Connection.txt";
				string[] fileLine = File.ReadAllLines(filePath);
				long key = Convert.ToInt64(fileLine[5]);

				SmtpClient client = new SmtpClient()
				{
					Host = "smtp.gmail.com",
					Port = 587,
					EnableSsl = true,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					Credentials = new NetworkCredential()
					{
						UserName = cypher.Decrypt(fileLine[6], key),
						Password = cypher.Decrypt(fileLine[7], key)
					}
				};

				MailAddress FromEmail = new MailAddress(
					cypher.Decrypt(fileLine[6], key),
					"XData Help Desk Assistant"
				);
				MailAddress ToEmail = new MailAddress(
					email,
					name
				);
				MailMessage message = new MailMessage()
				{
					From = FromEmail,
					Subject = "Verification Code",
					Body = $"Verification Code : {this.RandomCode}"
				};
				message.To.Add(ToEmail);
				client.Send(message);
			}
			catch (Exception err)
            {
				Console.WriteLine(err.Message);
            }
			

			return;
        }
    }
}
