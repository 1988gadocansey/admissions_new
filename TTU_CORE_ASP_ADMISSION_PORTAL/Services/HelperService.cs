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

         

        void IHelper.SendEmailNotification(string Email)
        {
           
        }

        

        public void SendSMSNotification(string PhoneNumber)
        {
            //string accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
            string accountSid = "AC7d8c5201cdd11fe5b8938105e75f77b0";
            string authToken = "96930eca3e7063020e6a29831276a718";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "TTU Admisison Testing. Thanks for testing.",
                from: new Twilio.Types.PhoneNumber("+13476823203"),
                to: new Twilio.Types.PhoneNumber(PhoneNumber)
            );

            Console.WriteLine(message.Sid);
        }
    
    }
}
