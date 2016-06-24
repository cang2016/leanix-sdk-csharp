/*
* The MIT License (MIT)
*
* Copyright (c) 2015 LeanIX GmbH
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace LeanIX.Api.Common {
  public class ApiClientBuilder {

    private string basePath;
    private string apiToken;
    private string oauth2TokenUri;

    /// <summary>
    /// Builds the ApiClient.
    /// </summary>
    public ApiClient Build() {
      ApiClient apiClient = ApiClient.GetInstance();
      apiClient.setBasePath(this.basePath);
      apiClient.setApiToken(this.apiToken, this.oauth2TokenUri);
      return apiClient;
    }

    /// <summary>
    /// Sets the endpoint base url for the services being accessed.
    /// </summary>
    public ApiClientBuilder WithBasePath(string basePath) {
      this.basePath = basePath;
      return this;
    }

    /// <summary>
    /// Specifies all urls needed to get an access token based on given host name and common url naming convention.
    /// </summary>
    public ApiClientBuilder WithTokenProviderHost(string host) {
      this.oauth2TokenUri = string.Format("https://{0}/services/mtm/v1/oauth2/token", host);
      return this;
    }

    /// <summary>
    /// Sets the API Token to be used to access the API.
    /// </summary>
    public ApiClientBuilder WithApiToken(string token) {
      this.apiToken = token;
      return this;
    }
  }
}

