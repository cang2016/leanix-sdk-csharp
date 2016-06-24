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
using LeanIX.Api.Common;
using LeanIX.Api.Models;
namespace LeanIX.Api {
  public class UsersApi {
    private readonly ApiClient apiClient = ApiClient.GetInstance();

    public ApiClient getClient() {
      return apiClient;
    }

    /// <summary>
    /// Read all Users 
    /// </summary>
    /// <param name="relations">If set to true, all relations of the Fact Sheet are fetched as well. Fetching all relations can be slower. Default: false.</param>
    /// <returns></returns>
    public List<User> getUsers (bool relations) {
      // create path and map variables
      var path = "/users".Replace("{format}","json");

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      string paramStr = null;
      if (relations != null){
        paramStr = (relations != null && relations is DateTime) ? ((DateTime)(object)relations).ToString("u") : Convert.ToString(relations);
        queryParams.Add("relations", paramStr);
      }
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<User>) ApiClient.deserialize(response, typeof(List<User>));
        }
        else {
          return null;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return null;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read a User by a given ID 
    /// </summary>
    /// <param name="ID">ID or uuid of the user, e.g. 110000002 or fa9b83f0-c015-4ede-ae22-3723f58314a9</param>
    /// <param name="relations">If set to true, all relations of the User are fetched as well. Fetching all relations can be slower. Default: false.</param>
    /// <returns></returns>
    public User getUser (string ID, bool relations) {
      // create path and map variables
      var path = "/users/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      if (relations != null){
        paramStr = (relations != null && relations is DateTime) ? ((DateTime)(object)relations).ToString("u") : Convert.ToString(relations);
        queryParams.Add("relations", paramStr);
      }
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (User) ApiClient.deserialize(response, typeof(User));
        }
        else {
          return null;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return null;
        }
        else {
          throw ex;
        }
      }
    }
    }
  }
