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
  public class ServiceHasInterface {
    /*  */
    public string ID { get; set; }

    /*  */
    public string name { get; set; }

    /*  */
    public string serviceID { get; set; }

    /*  */
    public string serviceRefID { get; set; }

    /*  */
    public string interfaceDirectionID { get; set; }

    /*  */
    public string interfaceFrequencyID { get; set; }

    /*  */
    public string interfaceTypeID { get; set; }

    /*  */
    public string interfaceTechnologyID { get; set; }

    /*  */
    public string reference { get; set; }

    /*  */
    public string visibilityID { get; set; }

    /*  */
    public string link { get; set; }

    /*  */
    public string ifaceID { get; set; }

    /*  */
    public InterfaceTechnology interfaceTechnology { get; set; }

    /*  */
    public List<BusinessObject> businessObjects { get; set; }

    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ServiceHasInterface {\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
      sb.Append("  name: ").Append(name).Append("\n");
      sb.Append("  serviceID: ").Append(serviceID).Append("\n");
      sb.Append("  serviceRefID: ").Append(serviceRefID).Append("\n");
      sb.Append("  interfaceDirectionID: ").Append(interfaceDirectionID).Append("\n");
      sb.Append("  interfaceFrequencyID: ").Append(interfaceFrequencyID).Append("\n");
      sb.Append("  interfaceTypeID: ").Append(interfaceTypeID).Append("\n");
      sb.Append("  interfaceTechnologyID: ").Append(interfaceTechnologyID).Append("\n");
      sb.Append("  reference: ").Append(reference).Append("\n");
      sb.Append("  visibilityID: ").Append(visibilityID).Append("\n");
      sb.Append("  link: ").Append(link).Append("\n");
      sb.Append("  ifaceID: ").Append(ifaceID).Append("\n");
      sb.Append("  interfaceTechnology: ").Append(interfaceTechnology).Append("\n");
      sb.Append("  businessObjects: ").Append(businessObjects).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }
  }
  }
