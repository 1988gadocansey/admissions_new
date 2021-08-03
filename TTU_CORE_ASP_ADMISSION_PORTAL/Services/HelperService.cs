//
//  Copyright 2021  2021
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Renci.SshNet;
using TTU_CORE_ASP_ADMISSION_PORTAL.Data;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Web;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace TTU_CORE_ASP_ADMISSION_PORTAL.Services
{
    public class HelperService : IHelper
    {
        private readonly ApplicationDbContext _dbContext;

        public HelperService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetProgrammeName(int id)
        {
            var programme = _dbContext.ProgrammeModel.Where(p => p.Id == id).First();

            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(programme.Name);
        }
        
        public string GetApplicantCodeFromId(int id)
        {
            var programme = _dbContext.ProgrammeModel.Where(p => p.Id == id).First();

            return programme.Code;
        }
        public double GetHallFee(int hall)
        {
            
            var hallData = _dbContext.HallModel.First(p => p.Id == hall);

            return hallData.Fees;
        }
        
        public string GetHallName(int hall)
        {
            
            var hallData = _dbContext.HallModel.First(p => p.Id == hall);

            return hallData.Name;
        }

        

        public int SendFileToServer(string host, int port, string username, string password,string uploadFile)
        {
            using (var client = new SftpClient(host, port, username, password))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    Debug.WriteLine("I'm connected to the client");
                    client.ChangeDirectory("/var/www/html/photos/public/albums/thumbnails");
                    using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                    {

                        client.BufferSize = 4 * 1024; // bypass Payload error large files
                        client.UploadFile(fileStream, Path.GetFileName(uploadFile));
                    }

                    return 1;
                }
                else
                {
                    Debug.WriteLine("I couldn't connect");
                    return 0;

                }
            }
        }

         

        void  IHelper.SendEmailNotification(string Email,string Message)
        {
           
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient("smtp.google.com");

            client.EnableSsl = true;

            NetworkCredential NetworkCred = new NetworkCredential("gadocansey@gmail.com","031988gadocansey");
            client.UseDefaultCredentials = true;
            client.Credentials = NetworkCred;
            client.Port = 587;
            // Specify the email sender.
            // Create a mailing address that includes a UTF8 character
            // in the display name.
            MailAddress from = new MailAddress("admissions@ttu.edu.gh",
               "Admissions " + (char)0xD8 + " TTU",
            System.Text.Encoding.UTF8);
           
            // Set destinations for the email message.
            MailAddress to = new MailAddress(Email);
            // Specify the message content.
            MailMessage message = new MailMessage(from, to);
            message.Body = Message;
            // Include some non-ASCII characters in body and subject.
            string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
            message.Body += Environment.NewLine + someArrows;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Subject = "From Admissions - Takoradi Technical University" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            string userState = "TTU Admissions";
            // Set the method that is called back when the send operation ends.
            client.SendAsync(message, userState);

            // Clean up.
            message.Dispose();

        }

        

        public string SendSMSNotification(string PhoneNumber, string Message)
        {

            string _URL = "https://smsc.hubtel.com/v1/messages/send?";

            string _senderid = "TTU";   // here assigning sender id 

            string _user = HttpUtility.UrlEncode("ifrzlixd"); // API user name to send SMS
            string _pass = "zrydysvw";     // API password to send SMS
            


            PhoneNumber = "+233"+PhoneNumber.Substring(1, 9);



            PhoneNumber = PhoneNumber.Replace(" ", "").Replace("-", "");


            string _recipient = PhoneNumber;  // who will receive message

            string _messageText = HttpUtility.UrlEncode(Message); // text message

            string result = "";
              
            // Creating URL to send sms
            string _createURL =_URL +
            "clientid="+_user+
               "&clientsecret="+_pass+
               "&from="+_senderid +
               "&to="+_recipient +
               "&content="+_messageText;

            Console.WriteLine("url" + _createURL);

            try
            {

                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
                result = http.GetAsync(_createURL).Result.Content.ReadAsStringAsync().Result;

                Console.WriteLine("result is " + result);
                // creating web request to send sms 
                 
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());//
            }
            return result;
        }

        bool IHelper. ContainsDuplicates(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == a[j]) return true;
                }
            }
            return false;
        }

        public string GetApplicantIdFromFormNo(string id)
        {
            var applicant = _dbContext.ApplicantModel.Where(p => p.ApplicationNumber.ToString() == id).First();

            return applicant.ID.ToString();
        }
    }
}
