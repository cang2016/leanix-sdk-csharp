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
	public class DataObject {
		/*  */
		public string ID { get; set; }

		/*  */
		public string dataObjectClass { get; set; }

		/*  */
		public string name { get; set; }

		/*  */
		public string data { get; set; }

		/*  */
		public string metaData { get; set; }

		/*  */
		public string identifier { get; set; }

		/*  */
		public string userID { get; set; }

		/*  */
		public string createTime { get; set; }

		/*  */
		public string updateTime { get; set; }

		/*  */
		public string createUserID { get; set; }

		/*  */
		public string updateUserID { get; set; }

		/*  */
		public string fileType { get; set; }

		/*  */
		public long size { get; set; }

		/*  */
		public string dataAccessRightID { get; set; }

		public override string ToString()  {
			var sb = new StringBuilder();
			sb.Append("class DataObject {\n");
			sb.Append("  ID: ").Append(ID).Append("\n");
			sb.Append("  dataObjectClass: ").Append(dataObjectClass).Append("\n");
			sb.Append("  name: ").Append(name).Append("\n");
			sb.Append("  data: ").Append(data).Append("\n");
			sb.Append("  metaData: ").Append(metaData).Append("\n");
			sb.Append("  identifier: ").Append(identifier).Append("\n");
			sb.Append("  userID: ").Append(userID).Append("\n");
			sb.Append("  createTime: ").Append(createTime).Append("\n");
			sb.Append("  updateTime: ").Append(updateTime).Append("\n");
			sb.Append("  createUserID: ").Append(createUserID).Append("\n");
			sb.Append("  updateUserID: ").Append(updateUserID).Append("\n");
			sb.Append("  fileType: ").Append(fileType).Append("\n");
			sb.Append("  size: ").Append(size).Append("\n");
			sb.Append("  dataAccessRightID: ").Append(dataAccessRightID).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}
	}
	}
