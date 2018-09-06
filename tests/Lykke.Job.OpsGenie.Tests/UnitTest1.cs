//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Lykke.Job.OpsGenie.Core.Services.OpsGenieApi;
//using Lykke.Job.OpsGenie.Services.OpsGenieApi;
//using Xunit;

//namespace Lykke.Job.OpsGenie.Tests
//{
//    public class UnitTest1
//    {
//        [Fact]
//        public async Task Test1()
//        {
//            var adapter = new OpsGenieApiAdapter(new OpsGenieApiAdapterSettings { ApiKey = "" });

//            try
//            {
//                var notif = await adapter.CreateAlert(new Alert
//                {
//                    Message = "message",
//                    Details = new Dictionary<string, object>() { { "key", "value" } },
//                    Actions = new List<string>() { "action1" },
//                    User = "user",
//                    Tags = new List<string>() { "tag" },
//                    Description = "desction",
//                    Alias = Guid.NewGuid().ToString(),
//                    Entity = "Entio",
//                    Source = "Source"
//                });

//                var t2 = notif;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//    }
//}
