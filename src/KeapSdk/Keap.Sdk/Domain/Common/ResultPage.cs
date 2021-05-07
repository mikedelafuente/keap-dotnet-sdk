using System.Collections.Generic;

namespace Keap.Sdk.Domain.Common
{
    public class ResultPage<T>
    {
        public ResultPage()
        {
        }

        public List<T> Items { get; set; } = new List<T>();
        public string NextPageToken { get; set; }
    }
}