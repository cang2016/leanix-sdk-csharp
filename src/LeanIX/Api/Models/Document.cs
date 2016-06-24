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
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace LeanIX.Api.Models {
  public class Document {
    /*  */
    public string ID { get; set; }

    /*  */
    public string name { get; set; }

    /*  */
    public string url { get; set; }

    /*  */
    public string topic { get; set; }

    /*  */
    public string version { get; set; }

    /*  */
    public string documentTypeID { get; set; }

    /*  */
    public string referenceSystem { get; set; }

    /*  */
    public string referenceType { get; set; }

    /*  */
    public string referenceID { get; set; }

    /*  */
    public string referenceSyncTime { get; set; }

    /*  */
    public string description { get; set; }

    /*  */
    public List<FactSheetHasDocument> factSheetHasDocuments { get; set; }

    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Document {\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
      sb.Append("  name: ").Append(name).Append("\n");
      sb.Append("  url: ").Append(url).Append("\n");
      sb.Append("  topic: ").Append(topic).Append("\n");
      sb.Append("  version: ").Append(version).Append("\n");
      sb.Append("  documentTypeID: ").Append(documentTypeID).Append("\n");
      sb.Append("  referenceSystem: ").Append(referenceSystem).Append("\n");
      sb.Append("  referenceType: ").Append(referenceType).Append("\n");
      sb.Append("  referenceID: ").Append(referenceID).Append("\n");
      sb.Append("  referenceSyncTime: ").Append(referenceSyncTime).Append("\n");
      sb.Append("  description: ").Append(description).Append("\n");
      sb.Append("  factSheetHasDocuments: ").Append(factSheetHasDocuments).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }
  }
  }
