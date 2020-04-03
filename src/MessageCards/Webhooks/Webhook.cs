using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MessageCards.Webhooks
{
    public class Webhook: IWebhook, IDisposable
    {
        private readonly string _url;
        private readonly HttpClient _client;

        public Webhook(string url) : this(url, null) { }

        public Webhook(string url, HttpMessageHandler handler = null, bool disposeHandler = true)
        {
            if (!Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uriResult) || (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("The provided URL is not valid", nameof(url));
            }
            _url = url;
            _client = handler == null ? new HttpClient() : new HttpClient(handler, disposeHandler);
        }

        public async Task PostAsync(MessageCard card)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _url)
            {
                Content = new StringContent(card.ToJson(), Encoding.UTF8, "application/json")
            };
            using (var response = await _client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && _client != null)
                {
                    _client.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}