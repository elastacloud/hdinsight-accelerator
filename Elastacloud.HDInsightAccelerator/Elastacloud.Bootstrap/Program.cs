using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastacloud.HDInsightAccelerator.Jobs;
using Microsoft.Hadoop.MapReduce;

namespace Elastacloud.Bootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            // leave these alone!!
            Environment.SetEnvironmentVariable("HADOOP_HOME", "THIS IS A BUG!!!");
            Environment.SetEnvironmentVariable("JAVA_HOME", "THIS IS A BUG!!!");

            // change the below placeholders [[like this]]
            var clusterConnection = Hadoop.Connect(new Uri("https://[[cluster name]].azurehdinsight.net"), "[[cluster username]]",
                "[[hadoop username]]", "[[clusterpassword]]", "[[your storage account name]]", "[[your account key]]", "[[storage account]]", false);
            var result = clusterConnection.MapReduceJob.ExecuteJob<LoveCleanStreetsJob>();
            Console.WriteLine(result.Info.StandardOut);
            Console.WriteLine("Press any key ....");
            Console.Read();
        
        }
    }
}
