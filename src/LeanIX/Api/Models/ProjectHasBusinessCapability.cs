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
	public class ProjectHasBusinessCapability {
		/*  */
		public string ID { get; set; }

		/*  */
		public string projectID { get; set; }

		/*  */
		public string businessCapabilityID { get; set; }

		/*  */
		public string comment { get; set; }

		/*  */
		public string supportTypeID { get; set; }

		/*  */
		public string constraints { get; set; }

		public override string ToString()  {
			var sb = new StringBuilder();
			sb.Append("class ProjectHasBusinessCapability {\n");
			sb.Append("  ID: ").Append(ID).Append("\n");
			sb.Append("  projectID: ").Append(projectID).Append("\n");
			sb.Append("  businessCapabilityID: ").Append(businessCapabilityID).Append("\n");
			sb.Append("  comment: ").Append(comment).Append("\n");
			sb.Append("  supportTypeID: ").Append(supportTypeID).Append("\n");
			sb.Append("  constraints: ").Append(constraints).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}
	}
	}
