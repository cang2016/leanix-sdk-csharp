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
  public class Project {
    /*  */
    public string ID { get; set; }

    /*  */
    public string displayName { get; set; }

    /*  */
    public string parentID { get; set; }

    /*  */
    public long level { get; set; }

    /*  */
    public string name { get; set; }

    /*  */
    public string reference { get; set; }

    /*  */
    public string alias { get; set; }

    /*  */
    public string description { get; set; }

    /*  */
    public long progress { get; set; }

    /*  */
    public string businessValueID { get; set; }

    /*  */
    public string businessValueDescription { get; set; }

    /*  */
    public string projectRiskID { get; set; }

    /*  */
    public string projectRiskDescription { get; set; }

    /*  */
    public double budgetOpex { get; set; }

    /*  */
    public double budgetCapex { get; set; }

    /*  */
    public string costComment { get; set; }

    /*  */
    public double netPresentValue { get; set; }

    /*  */
    public double paybackPeriod { get; set; }

    /*  */
    public string benefitComment { get; set; }

    /*  */
    public string objectStatusID { get; set; }

    /*  */
    public List<string> tags { get; set; }

    /*  */
    public string fullName { get; set; }

    /*  */
    public string resourceType { get; set; }

    /*  */
    public string completion { get; set; }

    /*  */
    public string qualitySealExpiry { get; set; }

    /*  */
    public string modificationTime { get; set; }

    /*  */
    public List<FactSheetHasParent> factSheetHasParents { get; set; }

    /*  */
    public List<FactSheetHasChild> factSheetHasChildren { get; set; }

    /*  */
    public List<FactSheetHasDocument> factSheetHasDocuments { get; set; }

    /*  */
    public List<FactSheetHasLifecycle> factSheetHasLifecycles { get; set; }

    /*  */
    public List<UserSubscription> userSubscriptions { get; set; }

    /*  */
    public List<FactSheetHasPredecessor> factSheetHasPredecessors { get; set; }

    /*  */
    public List<FactSheetHasSuccessor> factSheetHasSuccessors { get; set; }

    /*  */
    public List<FactSheetHasRequires> factSheetHasRequires { get; set; }

    /*  */
    public List<FactSheetHasRequiredby> factSheetHasRequiredby { get; set; }

    /*  */
    public List<ServiceHasProject> serviceHasProjects { get; set; }

    /*  */
    public List<ProjectHasBusinessCapability> projectHasBusinessCapabilities { get; set; }

    /*  */
    public List<ProjectHasProvider> projectHasProviders { get; set; }

    /*  */
    public List<ProjectHasResource> projectHasResources { get; set; }

    /*  */
    public List<ProjectHasConsumer> projectHasConsumers { get; set; }

    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class Project {\n");
      sb.Append("  ID: ").Append(ID).Append("\n");
      sb.Append("  displayName: ").Append(displayName).Append("\n");
      sb.Append("  parentID: ").Append(parentID).Append("\n");
      sb.Append("  level: ").Append(level).Append("\n");
      sb.Append("  name: ").Append(name).Append("\n");
      sb.Append("  reference: ").Append(reference).Append("\n");
      sb.Append("  alias: ").Append(alias).Append("\n");
      sb.Append("  description: ").Append(description).Append("\n");
      sb.Append("  progress: ").Append(progress).Append("\n");
      sb.Append("  businessValueID: ").Append(businessValueID).Append("\n");
      sb.Append("  businessValueDescription: ").Append(businessValueDescription).Append("\n");
      sb.Append("  projectRiskID: ").Append(projectRiskID).Append("\n");
      sb.Append("  projectRiskDescription: ").Append(projectRiskDescription).Append("\n");
      sb.Append("  budgetOpex: ").Append(budgetOpex).Append("\n");
      sb.Append("  budgetCapex: ").Append(budgetCapex).Append("\n");
      sb.Append("  costComment: ").Append(costComment).Append("\n");
      sb.Append("  netPresentValue: ").Append(netPresentValue).Append("\n");
      sb.Append("  paybackPeriod: ").Append(paybackPeriod).Append("\n");
      sb.Append("  benefitComment: ").Append(benefitComment).Append("\n");
      sb.Append("  objectStatusID: ").Append(objectStatusID).Append("\n");
      sb.Append("  tags: ").Append(tags).Append("\n");
      sb.Append("  fullName: ").Append(fullName).Append("\n");
      sb.Append("  resourceType: ").Append(resourceType).Append("\n");
      sb.Append("  completion: ").Append(completion).Append("\n");
      sb.Append("  qualitySealExpiry: ").Append(qualitySealExpiry).Append("\n");
      sb.Append("  modificationTime: ").Append(modificationTime).Append("\n");
      sb.Append("  factSheetHasParents: ").Append(factSheetHasParents).Append("\n");
      sb.Append("  factSheetHasChildren: ").Append(factSheetHasChildren).Append("\n");
      sb.Append("  factSheetHasDocuments: ").Append(factSheetHasDocuments).Append("\n");
      sb.Append("  factSheetHasLifecycles: ").Append(factSheetHasLifecycles).Append("\n");
      sb.Append("  userSubscriptions: ").Append(userSubscriptions).Append("\n");
      sb.Append("  factSheetHasPredecessors: ").Append(factSheetHasPredecessors).Append("\n");
      sb.Append("  factSheetHasSuccessors: ").Append(factSheetHasSuccessors).Append("\n");
      sb.Append("  factSheetHasRequires: ").Append(factSheetHasRequires).Append("\n");
      sb.Append("  factSheetHasRequiredby: ").Append(factSheetHasRequiredby).Append("\n");
      sb.Append("  serviceHasProjects: ").Append(serviceHasProjects).Append("\n");
      sb.Append("  projectHasBusinessCapabilities: ").Append(projectHasBusinessCapabilities).Append("\n");
      sb.Append("  projectHasProviders: ").Append(projectHasProviders).Append("\n");
      sb.Append("  projectHasResources: ").Append(projectHasResources).Append("\n");
      sb.Append("  projectHasConsumers: ").Append(projectHasConsumers).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }
  }
  }
