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
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace LeanIX.Api.Models {
	public class ServiceHasResource {
		/*  */
		public string ID { get; set; }

		/*  */
		public string resourceID { get; set; }

		/*  */
		public string serviceID { get; set; }

		/*  */
		public string comment { get; set; }

		/*  */
		public string technicalSuitabilityID { get; set; }

		/*  */
		public double costTotalAnnual { get; set; }

		/*  */
		public string serviceLevelID { get; set; }

		public override string ToString()  {
			var sb = new StringBuilder();
			sb.Append("class ServiceHasResource {\n");
			sb.Append("  ID: ").Append(ID).Append("\n");
			sb.Append("  resourceID: ").Append(resourceID).Append("\n");
			sb.Append("  serviceID: ").Append(serviceID).Append("\n");
			sb.Append("  comment: ").Append(comment).Append("\n");
			sb.Append("  technicalSuitabilityID: ").Append(technicalSuitabilityID).Append("\n");
			sb.Append("  costTotalAnnual: ").Append(costTotalAnnual).Append("\n");
			sb.Append("  serviceLevelID: ").Append(serviceLevelID).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}
	}
	}
