using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastacloud.HDInsightAccelerator.Mappers;
using Elastacloud.HDInsightAccelerator.Reducers;
using Microsoft.Hadoop.MapReduce;
using Xunit;

namespace Elastacloud.HDInsightAccelerator.Tests
{
    public class LoveCleanStreetsReducerTest
    {
        [Fact]
        public void ReducerCountsInputPaths()
        {
            var expected = "London\t2";
            var inputLine1 = "753c846c-e255-4c74-8e6a-6f01f3990678,0891623a-ef61-45a1-ae76-23c84beac1c1,52.67547767,-1.162027678,14/11/2013 13:24,There is a lot of litter in the garden to the side of the off licence on Astill Lodge Road on the corner of Kingsbridge Road. This is a constant nuisance. It then blows along the road into private gardens.,14/11/2013 13:24,Cleared,,814,Rubbish - Dumped,There is a lot of litter in the garden to the side of the off licence on Astill Lodge Road on the corner of Kingsbridge Road. This is a constant nuisance. It then blows along the road into private gardens.,\"Astill Lodge Road, Leicester, LE4 1 Leicester\",London,Leys Ward,http://api.mediaklik.com/images/0891623a-ef61-45a1-ae76-23c84beac1c1";
            var inputLine2 = "753c846c-e255-4c74-8e6a-6f01f3990678,0891623a-ef61-45a1-ae76-23c84beac1c1,52.67547767,-1.162027678,14/11/2013 13:24,There is a lot of litter in the garden to the side of the off licence on Astill Lodge Road on the corner of Kingsbridge Road. This is a constant nuisance. It then blows along the road into private gardens.,14/11/2013 13:24,Cleared,,814,Rubbish - Dumped,There is a lot of litter in the garden to the side of the off licence on Astill Lodge Road on the corner of Kingsbridge Road. This is a constant nuisance. It then blows along the road into private gardens.,\"Astill Lodge Road, Leicester, LE4 1 Leicester\",London,Leys Ward,http://api.mediaklik.com/images/0891623a-ef61-45a1-ae76-23c84beac1c1";
            var arrayInputLines = new[] { inputLine1, inputLine2 };

            var results = StreamingUnit.Execute<LoveCleanStreetsMapper, LoveCleanStreetsReducer>(arrayInputLines);

            Assert.Equal(expected, results.ReducerResult.First());
        }
    }
}
