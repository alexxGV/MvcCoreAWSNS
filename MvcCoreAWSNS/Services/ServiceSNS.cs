using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSNS.Services
{
    public class ServiceSNS
    {
        IConfiguration Configuration;
        public ServiceSNS(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public String SeedMessage(String message, String subject)
        {
            string topicArn = this.Configuration["SNS:TopicArn"];

            var client = new AmazonSimpleNotificationServiceClient(region: Amazon.RegionEndpoint.USEast1);

            var request = new PublishRequest
            {
                Subject = subject,
                Message = message,
                TopicArn = topicArn
            };

            try
            {
                var response = client.PublishAsync(request);

                return ("Mensaje:  " + subject + ", enviado correctamente.");
            }
            catch (Exception ex)
            {
                return ("ERROR al publicar mensaje: "+ ex.Message);
            }

        }
    }
}
