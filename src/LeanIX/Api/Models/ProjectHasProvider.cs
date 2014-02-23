/*
* The MIT License (MIT)	 
*
* Copyright (c) 2014 LeanIX GmbH
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
	public class ProjectHasProvider {
		/*  */
		public string ID { get; set; }

		/*  */
		public string providerID { get; set; }

		/*  */
		public string projectID { get; set; }

		/*  */
		public string orderNo { get; set; }

		/*  */
		public double orderedOpex { get; set; }

		/*  */
		public double orderedCapex { get; set; }

		/*  */
		public string comment { get; set; }

		/*  */
		public double actualsOpex { get; set; }

		/*  */
		public double actualsCapex { get; set; }

		/*  */
		public double etcOpex { get; set; }

		/*  */
		public double etcCapex { get; set; }

		/*  */
		public double deltaOpex { get; set; }

		/*  */
		public double deltaCapex { get; set; }

		public override string ToString()  {
			var sb = new StringBuilder();
			sb.Append("class ProjectHasProvider {\n");
			sb.Append("  ID: ").Append(ID).Append("\n");
			sb.Append("  providerID: ").Append(providerID).Append("\n");
			sb.Append("  projectID: ").Append(projectID).Append("\n");
			sb.Append("  orderNo: ").Append(orderNo).Append("\n");
			sb.Append("  orderedOpex: ").Append(orderedOpex).Append("\n");
			sb.Append("  orderedCapex: ").Append(orderedCapex).Append("\n");
			sb.Append("  comment: ").Append(comment).Append("\n");
			sb.Append("  actualsOpex: ").Append(actualsOpex).Append("\n");
			sb.Append("  actualsCapex: ").Append(actualsCapex).Append("\n");
			sb.Append("  etcOpex: ").Append(etcOpex).Append("\n");
			sb.Append("  etcCapex: ").Append(etcCapex).Append("\n");
			sb.Append("  deltaOpex: ").Append(deltaOpex).Append("\n");
			sb.Append("  deltaCapex: ").Append(deltaCapex).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}
	}
	}
