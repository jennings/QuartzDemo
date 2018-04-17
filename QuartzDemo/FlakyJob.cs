using Quartz;
using System;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class FlakyJob : IJob
    {
        Random _random = new Random();

        public async Task Execute(IJobExecutionContext context)
        {
            // Display if we're retrying

            if (context.RefireCount == 0)
            {
                WriteLine("NEW SEQUENCE");
            }
            else
            {
                WriteLine("Retry #{0}", context.RefireCount);
            }

            // Roll a die, succeed if we get 5 or 6

            var roll = _random.Next(6) + 1;
            if (roll >= 5)
            {
                WriteLine("Rolled {0}, completing successfully", roll);
            }
            else
            {
                WriteLine("Rolled {0}, throwing a JobExecutionException", roll);
                throw new JobExecutionException(refireImmediately: true);
            }

            await Task.CompletedTask;
        }

        void WriteLine(string s, params object[] args)
        {
            Console.WriteLine($"FlakeyJob ({DateTime.Now.ToString("T")}): " + s, args);
        }
    }
}
