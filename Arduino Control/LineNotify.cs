using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Arduino_Control
{
    class LineNotify
    {
        string url { get; set; }
        public LineNotify(string init)
        {
            this.url = init;
        }

        public async Task<bool> CheckStatus()
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new Dictionary<string, string>{
                    { "value1", "測試連線狀況" }
                };
                var content = new FormUrlEncodedContent(values);
                var response = await client.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                if (responseString.IndexOf("Congratulations") < 0)
                {
                    return false;
                }
                else return true;
            }
        }

        public async Task<bool> SendMessageAsync(string Text)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var values = new Dictionary<string, string>{
                    { "value1", Text }
                };
                    var content = new FormUrlEncodedContent(values);
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (responseString.IndexOf("Congratulations") < 0)
                    {
                        return false;
                    }
                    else return true;
                }
            }
            catch (TimeoutException)
            {
                return false;
            }
            catch (TaskCanceledException)
            {
                return false;
            }
        }
    }
}
