using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastacloud.HDInsightAccelerator.Mappers;
using Elastacloud.HDInsightAccelerator.Reducers;
using Microsoft.Hadoop.MapReduce;

namespace Elastacloud.HDInsightAccelerator.Jobs
{
    public class LoveCleanStreetsJob : HadoopJob<LoveCleanStreetsMapper, LoveCleanStreetsReducer>
    {
        public override HadoopJobConfiguration Configure(ExecutorContext context)
        {
            return new HadoopJobConfiguration()
            {
                InputPath = "/input/LoveCleanStreets.csv",
                OutputFolder = "/output/one"
            };
        }
    }
}
