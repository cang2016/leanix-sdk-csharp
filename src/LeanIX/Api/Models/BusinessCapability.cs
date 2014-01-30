using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace LeanIX.Api.Models {
  public class BusinessCapability {
    /*  */
    public string ID { get; set; }

    /*  */
    public string name { get; set; }

    /*  */
    public string reference { get; set; }

    /*  */
    public string alias { get; set; }

    /*  */
    public string description { get; set; }

    /*  */
    public string parentID { get; set; }

    /*  */
    public List<BusinessCapability> businessCapabilities { get; set; }

    /*  */
    public List<ServiceHasBusinessCapability> serviceHasBusinessCapabilities { get; set; }

    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class BusinessCapability {\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
      sb.Append("  name: ").Append(name).Append("\n");
      sb.Append("  reference: ").Append(reference).Append("\n");
      sb.Append("  alias: ").Append(alias).Append("\n");
      sb.Append("  description: ").Append(description).Append("\n");
      sb.Append("  parentID: ").Append(parentID).Append("\n");
      sb.Append("  businessCapabilities: ").Append(businessCapabilities).Append("\n");
      sb.Append("  serviceHasBusinessCapabilities: ").Append(serviceHasBusinessCapabilities).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }
  }
  }