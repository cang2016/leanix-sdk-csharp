/*
* The MIT License (MIT)
*
* Copyright (c) 2016 LeanIX GmbH
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
  public class ApiClient {
    private string basePath = "";

    private string clientId = "";
    private string clientSecret = "";
    private string tokenUrl = "";

    private AccessTokenResponse tokenResponse = null;

    private static readonly ApiClient _instance = new ApiClient();
    private Dictionary<String, String> defaultHeaderMap = new Dictionary<String, String>();

    public static ApiClient GetInstance() {
      return _instance;
    }

    // Sets the endpoint base url for the services being accessed
    public void setBasePath(string basePath) {
      this.basePath = basePath;
    }

    // Gets the endpoint base url for the services being accessed
    public String getBasePath() {
      return basePath;
    }

    public void setApiToken(string apiToken, string tokenUrl)
    {
        this.clientId = "apitoken";
        this.clientSecret = apiToken;
        this.tokenUrl = tokenUrl;
    }

    public void addDefaultHeader(string key, string value) {
      defaultHeaderMap.Add(key, value);
    }

    public void setApiKey(string apiKey) {
      this.addDefaultHeader("Api-Key", apiKey);
    }

    public string escapeString(string str) {
      return str;
    }

    public static object deserialize(string json, Type type) {
      try
      {
        return JsonConvert.DeserializeObject(json, type);
      }
      catch (IOException e) {
        throw new ApiException(500, e.Message);
      }
    }

    public static string serialize(object obj) {
      try
      {
        return obj != null ? JsonConvert.SerializeObject(obj) : null;
      }
      catch (Exception e) {
        throw new ApiException(500, e.Message);
      }
    }

    public string invokeAPI(string path, string method, Dictionary<String, String> queryParams, object body, Dictionary<String, String> headerParams) {

      this.updateParamsForAuth(queryParams, headerParams);

      string host = basePath;
      var b = new StringBuilder();

      foreach (var queryParamItem in queryParams)
      {
        var value = queryParamItem.Value;
        if (value == null) continue;
        b.Append(b.ToString().Length == 0 ? "?" : "&");
        b.Append(escapeString(queryParamItem.Key)).Append("=").Append(escapeString(value));
      }

      var querystring = b.ToString();

        host = host.EndsWith("/") ? host.Substring(0, host.Length - 1) : host;

        var client = WebRequest.Create(host + path + querystring);
        client.ContentType = "application/json";

        foreach (var headerParamsItem in headerParams)
        {
          client.Headers.Add(headerParamsItem.Key, headerParamsItem.Value);
        }
        foreach (var defaultHeaderMapItem in defaultHeaderMap.Where(defaultHeaderMapItem => !headerParams.ContainsKey(defaultHeaderMapItem.Key)))
        {
          client.Headers.Add(defaultHeaderMapItem.Key, defaultHeaderMapItem.Value);
        }

        switch (method)
        {
          case "GET":
            break;
          case "POST":
          case "PUT":
          case "DELETE":
            client.Method = method;
            var swRequestWriter = new StreamWriter(client.GetRequestStream());
            swRequestWriter.Write(serialize(body));
            swRequestWriter.Close();
            break;
          default:
            throw new ApiException(500, "unknown method type " + method);
        }

        var webResponse = (HttpWebResponse) client.GetResponse();
        if (webResponse.StatusCode != HttpStatusCode.OK) throw new ApiException((int) webResponse.StatusCode, webResponse.StatusDescription);

        var responseReader = new StreamReader(webResponse.GetResponseStream());
        var responseData = responseReader.ReadToEnd();
        responseReader.Close();
        return responseData;
    }

    private void updateParamsForAuth(Dictionary<String, String> queryParams, Dictionary<String, String> headerParams)
    {
        if (this.tokenResponse == null || this.tokenResponse.IsExpired)
        {
          this.fetchToken();
        }
        headerParams.Add("Authorization", "Bearer " + this.tokenResponse.AccessToken);
    }

    private void fetchToken()
    {
        var client = (HttpWebRequest)WebRequest.Create(this.getTokenUrl());
        client.ContentType = "application/x-www-form-urlencoded";
        client.Accept = "application/json";
        client.Method = "POST";

        client.Headers.Add("Authorization", this.buildBasicAuthorizationHeader());

        var webResponse = (HttpWebResponse) client.GetResponse();
        if (webResponse.StatusCode != HttpStatusCode.OK) throw new ApiException((int) webResponse.StatusCode, webResponse.StatusDescription);

        var responseReader = new StreamReader(webResponse.GetResponseStream());
        try
        {
            var responseData = responseReader.ReadToEnd();
            this.tokenResponse = (AccessTokenResponse)deserialize(responseData, typeof(AccessTokenResponse));
        }
        finally
        {
            responseReader.Close();
        }
    }

    private string getTokenUrl()
    {
      return this.tokenUrl + "?grant_type=client_credentials";
    }

    private string buildBasicAuthorizationHeader()
    {
      var sb = new StringBuilder();
      sb.Append(this.clientId).Append(":").Append(this.clientSecret);

      byte[] bytesToEncode = Encoding.UTF8.GetBytes (sb.ToString());
      return "Basic " + Convert.ToBase64String (bytesToEncode);
    }
  }
}

