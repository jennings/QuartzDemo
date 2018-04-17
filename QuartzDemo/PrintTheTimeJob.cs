using Quartz;
using System;
using System.Threading.Tasks;

namespace QuartzDemo
{
    class PrintTheTimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("PrintTheTimeJob: {0:T}", DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
