using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LogService
{
    public static class Function1
    {
        private static List<LogEntry> logEntries = new List<LogEntry>();

        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Receiving a log entry.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            LogEntry newEntry = JsonConvert.DeserializeObject<LogEntry>(requestBody);

            if (newEntry == null || string.IsNullOrEmpty(newEntry.Message) || string.IsNullOrEmpty(newEntry.Severity))
            {
                return new BadRequestObjectResult("Invalid log entry format.");
            }

            // Assign an ID to the log
            newEntry.ID = Guid.NewGuid();

            //Assigns Time to the Log
            newEntry.DateTime = DateTime.UtcNow;

            // Save the log entry to list (you can extend this to save to a database)
            logEntries.Add(newEntry);

            return new OkObjectResult("Log entry saved.");
        }


        [FunctionName("GetLogs")]
        public static IActionResult GetLogs(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
        ILogger log)
        {
            log.LogInformation("Fetching the 100 most recent log entries.");

            // Sort the logs by DateTime in descending order and take the most recent 100 entries
            var recentLogs = logEntries.OrderByDescending(e => e.DateTime).Take(100);

            return new OkObjectResult(recentLogs);
        }




    }

    
}
