using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Hadoop.MapReduce;

namespace Elastacloud.HDInsightAccelerator.Reducers
{
    public class LoveCleanStreetsReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            //do something like aggregate
            int count = values.Count();

            context.EmitKeyValue(key, count.ToString());
        }
    }
}
