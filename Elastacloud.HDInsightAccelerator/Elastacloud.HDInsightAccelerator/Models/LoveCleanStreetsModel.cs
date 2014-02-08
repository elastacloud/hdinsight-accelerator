using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Elastacloud.HDInsightAccelerator.Models
{
    public class LoveCleanStreetsModel
    {
        public string ReportId { get; set; }
        public string ReportItemId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ReportItemDateTime { get; set; }
        public string ItemNotes { get; set; }
        public string ReportDateTime { get; set; }
        public string Completed { get; set; }
        public string CompletedDate { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ReportNotes { get; set; }
        public string FormattedAddress { get; set; }
        public string LA { get; set; }
        public string Ward { get; set; }
        public string ImageUrl { get; set; }

        public static List<string> SplitCsv(string input)
        {
            var csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);

            return (from Match match in csvSplit.Matches(input) select match.Value.TrimStart(',')).ToList();
        }

        public static LoveCleanStreetsModel Parse(string inputLine)
        {
            var splits = SplitCsv(inputLine);
            //var splits = inputLine.Split(',');

            if (splits.Count() > 16)
                return null;

            var parsed = new LoveCleanStreetsModel()
            {
                ReportId = splits[0],
                ReportItemId = splits[1],
                Latitude = splits[2],
                Longitude = splits[3],
                ReportItemDateTime = splits[4],
                ItemNotes = splits[5],
                ReportDateTime = splits[6],
                Completed = splits[7],
                CompletedDate = splits[8],
                CategoryId = splits[9],
                CategoryName = splits[10],
                ReportNotes = splits[11],
                FormattedAddress = splits[12].Trim('\"'),
                LA = splits[13],
                Ward = splits[14],
                ImageUrl = splits[15]
            };

            return parsed;
        }
    }
}
