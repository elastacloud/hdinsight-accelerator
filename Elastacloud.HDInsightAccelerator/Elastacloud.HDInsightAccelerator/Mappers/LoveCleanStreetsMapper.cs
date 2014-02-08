using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastacloud.HDInsightAccelerator.Models;
using Microsoft.Hadoop.MapReduce;

namespace Elastacloud.HDInsightAccelerator.Mappers
{
    public class LoveCleanStreetsMapper : MapperBase
    {
        public override void Map(string inputLine, MapperContext context)
        {
            try
            {
                //select interesting data
                var model = LoveCleanStreetsModel.Parse(inputLine);
                if (model == null)
                    return;

                context.EmitKeyValue(model.LA, "1");
            }
            catch (Exception)
            {
               
            }
            
        }
    }
}
