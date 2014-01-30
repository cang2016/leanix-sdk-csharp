using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace LeanIX.Api.Models {
  public class Resource {
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
    public string objectCategoryID { get; set; }

    /*  */
    public string locationID { get; set; }

    /*  */
    public List<ResourceHasProviderSvc> resourceHasProvidersSvc { get; set; }

    /*  */
    public List<ResourceHasProviderSW> resourceHasProvidersSW { get; set; }

    /*  */
    public List<ResourceHasProviderHW> resourceHasProvidersHW { get; set; }

    /*  */
    public List<ResourceHasResourceCapability> resourceHasResourceCapabilities { get; set; }

    /*  */
    public List<ServiceHasResourceSvc> serviceHasResourcesSvc { get; set; }

    /*  */
    public List<ServiceHasResourceSW> serviceHasResourcesSW { get; set; }

    /*  */
    public List<ServiceHasResourceHW> serviceHasResourcesHW { get; set; }

    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Resource {\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
      sb.Append("  name: ").Append(name).Append("\n");
      sb.Append("  reference: ").Append(reference).Append("\n");
      sb.Append("  alias: ").Append(alias).Append("\n");
      sb.Append("  description: ").Append(description).Append("\n");
      sb.Append("  objectCategoryID: ").Append(objectCategoryID).Append("\n");
      sb.Append("  locationID: ").Append(locationID).Append("\n");
      sb.Append("  resourceHasProvidersSvc: ").Append(resourceHasProvidersSvc).Append("\n");
      sb.Append("  resourceHasProvidersSW: ").Append(resourceHasProvidersSW).Append("\n");
      sb.Append("  resourceHasProvidersHW: ").Append(resourceHasProvidersHW).Append("\n");
      sb.Append("  resourceHasResourceCapabilities: ").Append(resourceHasResourceCapabilities).Append("\n");
      sb.Append("  serviceHasResourcesSvc: ").Append(serviceHasResourcesSvc).Append("\n");
      sb.Append("  serviceHasResourcesSW: ").Append(serviceHasResourcesSW).Append("\n");
      sb.Append("  serviceHasResourcesHW: ").Append(serviceHasResourcesHW).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }
  }
  }