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
  public class ProcessesApi {
    private readonly ApiClient apiClient = ApiClient.GetInstance();

    public ApiClient getClient() {
      return apiClient;
    }

    /// <summary>
    /// Read all Process 
    /// </summary>
    /// <param name="relations">If set to true, all relations of the Fact Sheet are fetched as well. Fetching all relations can be slower. Default: false.</param>
    /// <param name="filter">Full-text filter</param>
    /// <returns></returns>
    public List<Process> getProcesses (bool relations, string filter) {
      // create path and map variables
      var path = "/processes".Replace("{format}","json");

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
          return (List<Process>) ApiClient.deserialize(response, typeof(List<Process>));
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
    /// Create a new Process 
    /// </summary>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public Process createProcess (Process body) {
      // create path and map variables
      var path = "/processes".Replace("{format}","json");

      // query params
      var queryParams = new Dictionary<String, String>();
      var headerParams = new Dictionary<String, String>();

      string paramStr = null;
      try {
        var response = apiClient.invokeAPI(path, "POST", queryParams, body, headerParams);
        if(response != null){
          return (Process) ApiClient.deserialize(response, typeof(Process));
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
    /// Read a Process by a given ID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="relations">If set to true, all relations of the Fact Sheet are fetched as well. Fetching all relations can be slower. Default: false.</param>
    /// <returns></returns>
    public Process getProcess (string ID, bool relations) {
      // create path and map variables
      var path = "/processes/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
          return (Process) ApiClient.deserialize(response, typeof(Process));
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
    /// Update a Process by a given ID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <param name="body">Message-Body</param>
    /// <returns></returns>
    public Process updateProcess (string ID, Process body) {
      // create path and map variables
      var path = "/processes/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
          return (Process) ApiClient.deserialize(response, typeof(Process));
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
    /// Delete a Process by a given ID 
    /// </summary>
    /// <param name="ID">Unique ID</param>
    /// <returns></returns>
    public void deleteProcess (string ID) {
      // create path and map variables
      var path = "/processes/{ID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasParents".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasParents".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasParents/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasParents/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasParents/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasChildren".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasChildren".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasChildren/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasChildren/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasChildren/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasDocuments".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasDocuments".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasDocuments/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasDocuments/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasDocuments/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasLifecycles".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasLifecycles".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasLifecycles/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasLifecycles/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasLifecycles/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/userSubscriptions".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/userSubscriptions".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/userSubscriptions/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/userSubscriptions/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/userSubscriptions/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasPredecessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasPredecessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasPredecessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasPredecessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasPredecessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasSuccessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasSuccessors".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasSuccessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasSuccessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasSuccessors/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequires".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequires".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequires/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequires/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequires/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequiredby".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequiredby".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequiredby/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequiredby/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/factSheetHasRequiredby/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/serviceHasProcesses".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/serviceHasProcesses".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
      var path = "/processes/{ID}/serviceHasProcesses/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/serviceHasProcesses/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
      var path = "/processes/{ID}/serviceHasProcesses/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
    public List<ProcessHasBusinessCapability> getProcessHasBusinessCapabilities (string ID) {
      // create path and map variables
      var path = "/processes/{ID}/processHasBusinessCapabilities".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
          return (List<ProcessHasBusinessCapability>) ApiClient.deserialize(response, typeof(List<ProcessHasBusinessCapability>));
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
    public ProcessHasBusinessCapability createProcessHasBusinessCapability (string ID, ProcessHasBusinessCapability body) {
      // create path and map variables
      var path = "/processes/{ID}/processHasBusinessCapabilities".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString()));

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
          return (ProcessHasBusinessCapability) ApiClient.deserialize(response, typeof(ProcessHasBusinessCapability));
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
    public ProcessHasBusinessCapability getProcessHasBusinessCapability (string ID, string relationID) {
      // create path and map variables
      var path = "/processes/{ID}/processHasBusinessCapabilities/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
          return (ProcessHasBusinessCapability) ApiClient.deserialize(response, typeof(ProcessHasBusinessCapability));
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
    public ProcessHasBusinessCapability updateProcessHasBusinessCapability (string ID, string relationID, ProcessHasBusinessCapability body) {
      // create path and map variables
      var path = "/processes/{ID}/processHasBusinessCapabilities/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
          return (ProcessHasBusinessCapability) ApiClient.deserialize(response, typeof(ProcessHasBusinessCapability));
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
    public void deleteProcessHasBusinessCapability (string ID, string relationID) {
      // create path and map variables
      var path = "/processes/{ID}/processHasBusinessCapabilities/{relationID}".Replace("{format}","json").Replace("{" + "ID" + "}", apiClient.escapeString(ID.ToString())).Replace("{" + "relationID" + "}", apiClient.escapeString(relationID.ToString()));

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
