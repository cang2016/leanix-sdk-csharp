using System;
using Newtonsoft.Json;

namespace LeanIX.Api.Common
{
    public class AccessTokenResponse
    {
        // Lead time in seconds
        private static int LEAD_TIME = 60;
        private int _expiresIn;

        [JsonProperty(PropertyName="scope")]
        public string Scope { get; set; }

        [JsonProperty(PropertyName="expired")]
        public bool Expired { get; set; }

        [JsonProperty(PropertyName="access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName="token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName="expires_in")]
        public int ExpiresIn
        {
          get { return _expiresIn; }
          set
          {
            _expiresIn = value;
            this.Expires = DateTime.Now.AddSeconds(_expiresIn);
          }
        }

        public DateTime Expires { get; private set; }

        public bool IsExpired {
          get
          {
            return this.Expires.AddSeconds(-LEAD_TIME) < DateTime.Now;
          }
        }
    }
}