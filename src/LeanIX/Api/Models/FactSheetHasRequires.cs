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
	public class FactSheetHasRequires {
		/*  */
		public string ID { get; set; }

		/*  */
		public string factSheetID { get; set; }

		/*  */
		public string factSheetRefID { get; set; }

		/*  */
		public string description { get; set; }

		/*  */
		public string dependencyTypeID { get; set; }

		public override string ToString()  {
			var sb = new StringBuilder();
			sb.Append("class FactSheetHasRequires {\n");
			sb.Append("  ID: ").Append(ID).Append("\n");
			sb.Append("  factSheetID: ").Append(factSheetID).Append("\n");
			sb.Append("  factSheetRefID: ").Append(factSheetRefID).Append("\n");
			sb.Append("  description: ").Append(description).Append("\n");
			sb.Append("  dependencyTypeID: ").Append(dependencyTypeID).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}
	}
	}
