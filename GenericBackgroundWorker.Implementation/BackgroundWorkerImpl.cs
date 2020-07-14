using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericBackgroundWorker.Test
{
    public class BackgroundWorkerImpl : BackgroundWorkerBase<List<string>>
    {
        public BackgroundWorkerImpl(List<string> obj) : base(obj)
        {

        }

        protected override void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if(e.Argument is List<string> stringList)
            {

                Parallel.ForEach(stringList, item =>
                {
                    ReportProgressChanged(50, item);

                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    ReportProgressChanged(80, item);

                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    ReportProgressChanged(100, item);
                });
            }
        }

        protected override void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.UserState is string str)
            {
                Console.WriteLine($"{str} : {e.ProgressPercentage} %");
            }
        }

        protected override void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.UserState is string str)
            {
                if (e.Error is null)
                    Console.WriteLine($"Processing Successful.");
                else
                    Console.WriteLine($"Processing Failed.");
            }
        }
    }
}
