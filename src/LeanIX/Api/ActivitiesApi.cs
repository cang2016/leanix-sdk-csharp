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
using LeanIX.Api.Common;
using LeanIX.Api.Models;
namespace LeanIX.Api {
	public class ActivitiesApi {
		private readonly ApiClient apiClient = ApiClient.GetInstance();

		public ApiClient getClient() {
			return apiClient;
		}

		/// <summary>
		/// Get the latest activities 
		/// </summary>
		/// <param name="scope">If set to 'my', only the activities related to subscribed Fact Sheet are listed for the authenticated user.</param>
		/// <param name="startDate">If set, only activities greater or equal the given date time are retrieved. If no start time is given, then the start time is calculated based on the last event.</param>
		/// <param name="endDate">If set, only activities less or equal the given date time are retrieved. If no end time is given, all activities until today are selected.</param>
		/// <param name="factSheetType">Type of Fact Sheet, e.g. services for Application</param>
		/// <param name="eventType">Event type, e.g. creation of a Fact Sheet: OBJECT_CREATE</param>
		/// <param name="countOnly">If set to 1, then only the count is transmitted and data is left empty</param>
		/// <returns></returns>
		public ActivityStream getActivities (string scope, string startDate, string endDate, string factSheetType, string eventType, integer countOnly) {
			// create path and map variables
			var path = "/activities".Replace("{format}","json");

			// query params
			var queryParams = new Dictionary<String, String>();
			var headerParams = new Dictionary<String, String>();

			string paramStr = null;
			if (scope != null){
				paramStr = (scope != null && scope is DateTime) ? ((DateTime)(object)scope).ToString("u") : Convert.ToString(scope);
				queryParams.Add("scope", paramStr);
			}
			if (startDate != null){
				paramStr = (startDate != null && startDate is DateTime) ? ((DateTime)(object)startDate).ToString("u") : Convert.ToString(startDate);
				queryParams.Add("startDate", paramStr);
			}
			if (endDate != null){
				paramStr = (endDate != null && endDate is DateTime) ? ((DateTime)(object)endDate).ToString("u") : Convert.ToString(endDate);
				queryParams.Add("endDate", paramStr);
			}
			if (factSheetType != null){
				paramStr = (factSheetType != null && factSheetType is DateTime) ? ((DateTime)(object)factSheetType).ToString("u") : Convert.ToString(factSheetType);
				queryParams.Add("factSheetType", paramStr);
			}
			if (eventType != null){
				paramStr = (eventType != null && eventType is DateTime) ? ((DateTime)(object)eventType).ToString("u") : Convert.ToString(eventType);
				queryParams.Add("eventType", paramStr);
			}
			if (countOnly != null){
				paramStr = (countOnly != null && countOnly is DateTime) ? ((DateTime)(object)countOnly).ToString("u") : Convert.ToString(countOnly);
				queryParams.Add("countOnly", paramStr);
			}
			try {
				var response = apiClient.invokeAPI(path, "GET", queryParams, null, headerParams);
				if(response != null){
					return (ActivityStream) ApiClient.deserialize(response, typeof(ActivityStream));
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
