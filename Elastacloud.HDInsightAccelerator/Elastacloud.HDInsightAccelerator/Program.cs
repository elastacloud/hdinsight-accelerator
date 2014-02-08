using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastacloud.HDInsightAccelerator.Jobs;
using Microsoft.Hadoop.MapReduce;

namespace Elastacloud.HDInsightAccelerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("HADOOP_HOME", "THIS IS A BUG!!!");
            Environment.SetEnvironmentVariable("JAVA_HOME", "THIS IS A BUG!!!");
            var clusterConnection = Hadoop.Connect(new Uri("https://elastacloudne.azurehdinsight.net"), "elastacloud",
                "richard", "@azurecodeR1", "elastacloudne", "x8hhFGPKXs7Dht8Aq8tBTE0dCVpZ9tMC7UGTJ2Bws9pnmtyNi5DatRlRhYW6n12PN8mVkDuckvzitVkxW0sVZw==", "elastacloudne", false);
            var result = clusterConnection.MapReduceJob.ExecuteJob<LoveCleanStreetsJob>();
            Console.WriteLine(result.Info.StandardOut);
            Console.WriteLine("Press any key ....");
            Console.Read();
        }
    }
}
