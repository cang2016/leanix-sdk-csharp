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
  public class ServicesApi {
    private readonly ApiClient apiClient = ApiClient.GetInstance();

    public ApiClient getClient() {
      return apiClient;
    }

    /// <summary>
    /// Read all Application 
    /// </summary>
    /// <param name="relations">If set to true, all relations of the Fact Sheet are fetched as well. Fetching all relations can be slower. Default: false.</param>
    /// <param name="filter">Full-text filter</param>
    /// <returns></returns>
    public List<Service> getServices (bool relations, string filter) {
      // create path and map variables
      var path = "/services".Replace("{format}","json");

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      string paramStr = null;
      if (relations != null){
        paramStr = (relations != null && relations is DateTime) ? ((DateTime)(object)relations).ToString("u") : Convert.ToString(relations);
        queryParams.Add("relations", paramStr);
      }
      if (filter != null){
        paramStr = (filter != null && filter is DateTime) ? ((DateTime)(object)filter).ToString("u") : Convert.ToString(filter);
        queryParams.Add("filter", paramStr);
      }
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<Service>) ApiClient.deserialize(response, typeof(List<Service>));
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
    /// Create a new Application 
    /// </summary>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public Service createService (Service body) {
      // create path and map variables
      var path = "/services".Replace("{format}","json");

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (Service) ApiClient.deserialize(response, typeof(Service));
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
    /// Read a Application by a given ID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relations">If set to true, all relations of the Fact Sheet are fetched as well. Fetching all relations can be slower. Default: false.</param>
    /// <returns></returns>
    public Service getService (string ID, bool relations) {
      // create path and map variables
      var path = "/services/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
          return (Service) ApiClient.deserialize(response, typeof(Service));
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
    /// Update a Application by a given ID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public Service updateService (string ID, Service body) {
      // create path and map variables
      var path = "/services/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (Service) ApiClient.deserialize(response, typeof(Service));
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
    /// Delete a Application by a given ID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public void deleteService (string ID) {
      // create path and map variables
      var path = "/services/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasParent> getFactSheetHasParents (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasParents".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasParent>) ApiClient.deserialize(response, typeof(List<FactSheetHasParent>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasParent createFactSheetHasParent (string ID, FactSheetHasParent body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasParents".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasParent) ApiClient.deserialize(response, typeof(FactSheetHasParent));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasParent getFactSheetHasParent (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasParents/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasParent) ApiClient.deserialize(response, typeof(FactSheetHasParent));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasParent updateFactSheetHasParent (string ID, string relationID, FactSheetHasParent body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasParents/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasParent) ApiClient.deserialize(response, typeof(FactSheetHasParent));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasParent (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasParents/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasChild> getFactSheetHasChildren (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasChildren".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasChild>) ApiClient.deserialize(response, typeof(List<FactSheetHasChild>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasChild createFactSheetHasChild (string ID, FactSheetHasChild body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasChildren".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasChild) ApiClient.deserialize(response, typeof(FactSheetHasChild));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasChild getFactSheetHasChild (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasChildren/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasChild) ApiClient.deserialize(response, typeof(FactSheetHasChild));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasChild updateFactSheetHasChild (string ID, string relationID, FactSheetHasChild body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasChildren/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasChild) ApiClient.deserialize(response, typeof(FactSheetHasChild));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasChild (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasChildren/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasDocument> getFactSheetHasDocuments (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasDocuments".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasDocument>) ApiClient.deserialize(response, typeof(List<FactSheetHasDocument>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasDocument createFactSheetHasDocument (string ID, FactSheetHasDocument body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasDocuments".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasDocument) ApiClient.deserialize(response, typeof(FactSheetHasDocument));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasDocument getFactSheetHasDocument (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasDocuments/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasDocument) ApiClient.deserialize(response, typeof(FactSheetHasDocument));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasDocument updateFactSheetHasDocument (string ID, string relationID, FactSheetHasDocument body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasDocuments/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasDocument) ApiClient.deserialize(response, typeof(FactSheetHasDocument));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasDocument (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasDocuments/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasLifecycle> getFactSheetHasLifecycles (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasLifecycles".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasLifecycle>) ApiClient.deserialize(response, typeof(List<FactSheetHasLifecycle>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasLifecycle createFactSheetHasLifecycle (string ID, FactSheetHasLifecycle body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasLifecycles".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasLifecycle) ApiClient.deserialize(response, typeof(FactSheetHasLifecycle));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasLifecycle getFactSheetHasLifecycle (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasLifecycles/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasLifecycle) ApiClient.deserialize(response, typeof(FactSheetHasLifecycle));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasLifecycle updateFactSheetHasLifecycle (string ID, string relationID, FactSheetHasLifecycle body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasLifecycles/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasLifecycle) ApiClient.deserialize(response, typeof(FactSheetHasLifecycle));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasLifecycle (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasLifecycles/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<UserSubscription> getUserSubscriptions (string ID) {
      // create path and map variables
      var path = "/services/{ID}/userSubscriptions".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<UserSubscription>) ApiClient.deserialize(response, typeof(List<UserSubscription>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public UserSubscription createUserSubscription (string ID, UserSubscription body) {
      // create path and map variables
      var path = "/services/{ID}/userSubscriptions".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (UserSubscription) ApiClient.deserialize(response, typeof(UserSubscription));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public UserSubscription getUserSubscription (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/userSubscriptions/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (UserSubscription) ApiClient.deserialize(response, typeof(UserSubscription));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public UserSubscription updateUserSubscription (string ID, string relationID, UserSubscription body) {
      // create path and map variables
      var path = "/services/{ID}/userSubscriptions/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (UserSubscription) ApiClient.deserialize(response, typeof(UserSubscription));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteUserSubscription (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/userSubscriptions/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasPredecessor> getFactSheetHasPredecessors (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasPredecessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasPredecessor>) ApiClient.deserialize(response, typeof(List<FactSheetHasPredecessor>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasPredecessor createFactSheetHasPredecessor (string ID, FactSheetHasPredecessor body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasPredecessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasPredecessor) ApiClient.deserialize(response, typeof(FactSheetHasPredecessor));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasPredecessor getFactSheetHasPredecessor (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasPredecessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasPredecessor) ApiClient.deserialize(response, typeof(FactSheetHasPredecessor));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasPredecessor updateFactSheetHasPredecessor (string ID, string relationID, FactSheetHasPredecessor body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasPredecessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasPredecessor) ApiClient.deserialize(response, typeof(FactSheetHasPredecessor));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasPredecessor (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasPredecessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasSuccessor> getFactSheetHasSuccessors (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasSuccessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasSuccessor>) ApiClient.deserialize(response, typeof(List<FactSheetHasSuccessor>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasSuccessor createFactSheetHasSuccessor (string ID, FactSheetHasSuccessor body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasSuccessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasSuccessor) ApiClient.deserialize(response, typeof(FactSheetHasSuccessor));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasSuccessor getFactSheetHasSuccessor (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasSuccessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasSuccessor) ApiClient.deserialize(response, typeof(FactSheetHasSuccessor));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasSuccessor updateFactSheetHasSuccessor (string ID, string relationID, FactSheetHasSuccessor body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasSuccessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasSuccessor) ApiClient.deserialize(response, typeof(FactSheetHasSuccessor));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasSuccessor (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasSuccessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasRequires> getFactSheetHasRequiresAll (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequires".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasRequires>) ApiClient.deserialize(response, typeof(List<FactSheetHasRequires>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasRequires createFactSheetHasRequires (string ID, FactSheetHasRequires body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequires".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasRequires) ApiClient.deserialize(response, typeof(FactSheetHasRequires));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasRequires getFactSheetHasRequires (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequires/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasRequires) ApiClient.deserialize(response, typeof(FactSheetHasRequires));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasRequires updateFactSheetHasRequires (string ID, string relationID, FactSheetHasRequires body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequires/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasRequires) ApiClient.deserialize(response, typeof(FactSheetHasRequires));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasRequires (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequires/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasRequiredby> getFactSheetHasRequiredByAll (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequiredby".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasRequiredby>) ApiClient.deserialize(response, typeof(List<FactSheetHasRequiredby>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasRequiredby createFactSheetHasRequiredby (string ID, FactSheetHasRequiredby body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequiredby".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasRequiredby) ApiClient.deserialize(response, typeof(FactSheetHasRequiredby));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasRequiredby getFactSheetHasRequiredby (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequiredby/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasRequiredby) ApiClient.deserialize(response, typeof(FactSheetHasRequiredby));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasRequiredby updateFactSheetHasRequiredby (string ID, string relationID, FactSheetHasRequiredby body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequiredby/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasRequiredby) ApiClient.deserialize(response, typeof(FactSheetHasRequiredby));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasRequiredby (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasRequiredby/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasBusinessCapability> getServiceHasBusinessCapabilities (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessCapabilities".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasBusinessCapability>) ApiClient.deserialize(response, typeof(List<ServiceHasBusinessCapability>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasBusinessCapability createServiceHasBusinessCapability (string ID, ServiceHasBusinessCapability body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessCapabilities".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasBusinessCapability) ApiClient.deserialize(response, typeof(ServiceHasBusinessCapability));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasBusinessCapability getServiceHasBusinessCapability (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessCapabilities/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasBusinessCapability) ApiClient.deserialize(response, typeof(ServiceHasBusinessCapability));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasBusinessCapability updateServiceHasBusinessCapability (string ID, string relationID, ServiceHasBusinessCapability body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessCapabilities/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasBusinessCapability) ApiClient.deserialize(response, typeof(ServiceHasBusinessCapability));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasBusinessCapability (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessCapabilities/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasProcess> getServiceHasProcesses (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProcesses".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasProcess>) ApiClient.deserialize(response, typeof(List<ServiceHasProcess>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasProcess createServiceHasProcess (string ID, ServiceHasProcess body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProcesses".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasProcess) ApiClient.deserialize(response, typeof(ServiceHasProcess));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasProcess getServiceHasProcess (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProcesses/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasProcess) ApiClient.deserialize(response, typeof(ServiceHasProcess));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasProcess updateServiceHasProcess (string ID, string relationID, ServiceHasProcess body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProcesses/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasProcess) ApiClient.deserialize(response, typeof(ServiceHasProcess));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasProcess (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProcesses/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasConsumer> getServiceHasConsumers (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasConsumers".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasConsumer>) ApiClient.deserialize(response, typeof(List<ServiceHasConsumer>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasConsumer createServiceHasConsumer (string ID, ServiceHasConsumer body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasConsumers".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasConsumer) ApiClient.deserialize(response, typeof(ServiceHasConsumer));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasConsumer getServiceHasConsumer (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasConsumers/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasConsumer) ApiClient.deserialize(response, typeof(ServiceHasConsumer));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasConsumer updateServiceHasConsumer (string ID, string relationID, ServiceHasConsumer body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasConsumers/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasConsumer) ApiClient.deserialize(response, typeof(ServiceHasConsumer));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasConsumer (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasConsumers/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasBusinessObject> getServiceHasBusinessObjects (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessObjects".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasBusinessObject>) ApiClient.deserialize(response, typeof(List<ServiceHasBusinessObject>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasBusinessObject createServiceHasBusinessObject (string ID, ServiceHasBusinessObject body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessObjects".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasBusinessObject) ApiClient.deserialize(response, typeof(ServiceHasBusinessObject));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasBusinessObject getServiceHasBusinessObject (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessObjects/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasBusinessObject) ApiClient.deserialize(response, typeof(ServiceHasBusinessObject));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasBusinessObject updateServiceHasBusinessObject (string ID, string relationID, ServiceHasBusinessObject body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessObjects/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasBusinessObject) ApiClient.deserialize(response, typeof(ServiceHasBusinessObject));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasBusinessObject (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasBusinessObjects/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasInterface> getServiceHasInterfaces (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasInterfaces".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasInterface>) ApiClient.deserialize(response, typeof(List<ServiceHasInterface>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasInterface createServiceHasInterface (string ID, ServiceHasInterface body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasInterfaces".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasInterface) ApiClient.deserialize(response, typeof(ServiceHasInterface));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasInterface getServiceHasInterface (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasInterfaces/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasInterface) ApiClient.deserialize(response, typeof(ServiceHasInterface));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasInterface updateServiceHasInterface (string ID, string relationID, ServiceHasInterface body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasInterfaces/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasInterface) ApiClient.deserialize(response, typeof(ServiceHasInterface));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasInterface (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasInterfaces/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasProject> getServiceHasProjects (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProjects".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasProject>) ApiClient.deserialize(response, typeof(List<ServiceHasProject>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasProject createServiceHasProject (string ID, ServiceHasProject body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProjects".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasProject) ApiClient.deserialize(response, typeof(ServiceHasProject));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasProject getServiceHasProject (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProjects/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasProject) ApiClient.deserialize(response, typeof(ServiceHasProject));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasProject updateServiceHasProject (string ID, string relationID, ServiceHasProject body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProjects/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasProject) ApiClient.deserialize(response, typeof(ServiceHasProject));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasProject (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasProjects/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<ServiceHasResource> getServiceHasResources (string ID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasResources".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<ServiceHasResource>) ApiClient.deserialize(response, typeof(List<ServiceHasResource>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasResource createServiceHasResource (string ID, ServiceHasResource body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasResources".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasResource) ApiClient.deserialize(response, typeof(ServiceHasResource));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public ServiceHasResource getServiceHasResource (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasResources/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (ServiceHasResource) ApiClient.deserialize(response, typeof(ServiceHasResource));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public ServiceHasResource updateServiceHasResource (string ID, string relationID, ServiceHasResource body) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasResources/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (ServiceHasResource) ApiClient.deserialize(response, typeof(ServiceHasResource));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteServiceHasResource (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/serviceHasResources/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasIfaceProvider> getFactSheetHasIfaceProviders (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceProviders".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasIfaceProvider>) ApiClient.deserialize(response, typeof(List<FactSheetHasIfaceProvider>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasIfaceProvider createFactSheetHasIfaceProvider (string ID, FactSheetHasIfaceProvider body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceProviders".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasIfaceProvider) ApiClient.deserialize(response, typeof(FactSheetHasIfaceProvider));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasIfaceProvider getFactSheetHasIfaceProvider (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceProviders/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasIfaceProvider) ApiClient.deserialize(response, typeof(FactSheetHasIfaceProvider));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasIfaceProvider updateFactSheetHasIfaceProvider (string ID, string relationID, FactSheetHasIfaceProvider body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceProviders/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasIfaceProvider) ApiClient.deserialize(response, typeof(FactSheetHasIfaceProvider));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasIfaceProvider (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceProviders/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    /// <summary>
    /// Read all of relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public List<FactSheetHasIfaceConsumer> getFactSheetHasIfaceConsumers (string ID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceConsumers".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (List<FactSheetHasIfaceConsumer>) ApiClient.deserialize(response, typeof(List<FactSheetHasIfaceConsumer>));
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
    /// Create a new relation 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasIfaceConsumer createFactSheetHasIfaceConsumer (string ID, FactSheetHasIfaceConsumer body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceConsumers".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasIfaceConsumer) ApiClient.deserialize(response, typeof(FactSheetHasIfaceConsumer));
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
    /// Read by relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public FactSheetHasIfaceConsumer getFactSheetHasIfaceConsumer (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceConsumers/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
        if(response != null){
          return (FactSheetHasIfaceConsumer) ApiClient.deserialize(response, typeof(FactSheetHasIfaceConsumer));
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
    /// Update relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public FactSheetHasIfaceConsumer updateFactSheetHasIfaceConsumer (string ID, string relationID, FactSheetHasIfaceConsumer body) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceConsumers/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "PUT", queryParams, body, headerParams);
        if(response != null){
          return (FactSheetHasIfaceConsumer) ApiClient.deserialize(response, typeof(FactSheetHasIfaceConsumer));
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
    /// Delete relation by a given relationID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relationID">Unique ID of the Relation</param>
    /// <returns></returns>
    public void deleteFactSheetHasIfaceConsumer (string ID, string relationID) {
      // create path and map variables
      var path = "/services/{ID}/factSheetHasIfaceConsumers/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      // verify required params are set
      if (ID == null || relationID == null ) {
        throw new ApiException(400, "missing required params");
      }
      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "DELETE", queryParams, null, headerParams);
        if(response != null){
          return ;
        }
        else {
          return ;
        }
      } catch (ApiException ex) {
        if(ex.ErrorCode == 404) {
          return ;
        }
        else {
          throw ex;
        }
      }
    }
    }
  }
