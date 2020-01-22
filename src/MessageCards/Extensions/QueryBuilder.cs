using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace MessageCards.Extensions
{
    public static class QueryBuilder
    {
        public static string EncodeLogAnalyticsQuery(string query)
        {
            var compressedQuery = CompressLogAnalyticsQuery(query);
            return WebUtility.UrlEncode(compressedQuery);
        }

        public static string CompressLogAnalyticsQuery(string query)
        {
            byte[] compressedBytes;
            var bytes = Encoding.UTF8.GetBytes(query);
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(bytes, 0, bytes.Length);
                }
                compressedBytes = memoryStream.ToArray();
            }
            return Convert.ToBase64String(compressedBytes);
        }

        public static string BuildLogAnalyticsUrl(string tenantName, string resourceId, string query, string timespan = "P1D")
        {
            return $"https://portal.azure.com#@{tenantName}/blade/Microsoft_Azure_Monitoring_Logs/LogsBlade/resourceId/{WebUtility.UrlEncode(resourceId)}/source/LogsBlade.AnalyticsShareLinkToQuery/q/{WebUtility.UrlEncode(CompressLogAnalyticsQuery(query))}/timespan/{timespan}";
        }
    }
}
