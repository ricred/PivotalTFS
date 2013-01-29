using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using PivotalTFSSync.Properties;
using PivotalTFSSync.TFS.Templates;

namespace PivotalTFSSync.TFS
{
    public class TFS2010 : ITFS
    {
      
        private const string Pivotalid = "PIVOTALID:";
        private const string ProductBacklogItem = "Product Backlog Item";
        private const string HistoryField = "History";
        private readonly WorkItemStore store;
        // private readonly TfsConfigurationServer tfsConfigurationServer;
        private TemplateProxy templateproxy = new TemplateProxy();

        public TFS2010(string servername, string domain, string username, string password)
        {
            if (string.IsNullOrEmpty(servername))
                throw new ArgumentException("Parameter named:servername cannot be null or empty.");

            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Parameter named:username cannot be null or empty.");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Parameter named:password cannot be null or empty.");

            //ICredentialsProvider provider = new UICredentialsProvider();
            //tfsConfigurationServer = TeamFoundationServerFactory.GetServer(serverName, provider);
            //if (!tfsConfigurationServer.HasAuthenticated)
            //    tfsConfigurationServer.Authenticate();

            //tfsConfigurationServer = new TfsConfigurationServer(new Uri(string.Concat("http://", servername)),
            //                                                    new NetworkCredential(username, password, domain));


            //TeamProjectPicker pp = new TeamProjectPicker(TeamProjectPickerMode.SingleProject, false);

            //pp.ShowDialog();

            //var coll = new TfsTeamProjectCollection(new Uri(string.Concat("http://", servername)), new UICredentialsProvider());
            var tfsTeamProjectCollection = new TfsTeamProjectCollection(new Uri(string.Concat("http://", servername)), new NetworkCredential(username, password, domain));
            tfsTeamProjectCollection.EnsureAuthenticated();
            store = (WorkItemStore)tfsTeamProjectCollection.GetService(typeof(WorkItemStore));

            //var processTemplates = (IProcessTemplates)tfsTeamProjectCollection.GetService(typeof(IProcessTemplates));
            //var node = processTemplates.GetTemplateNames();

            //ICommonStructureService css = (ICommonStructureService)tfsTeamProjectCollection.GetService(typeof(ICommonStructureService));
            //ProjectInfo projectInfo = css.GetProjectFromName(store.Projects[5].Name);
            //String projectName;
            //String prjState;
            //int templateId = 0;
            //ProjectProperty[] projectProperties;


            //css.GetProjectProperties(
            //        projectInfo.Uri, out projectName, out prjState, out templateId, out projectProperties);
      

            // //tfsConfigurationServer.Authenticate();
            // var tpcService = tfsConfigurationServer.GetService<ITeamProjectCollectionService>();
            //var  collections = tpcService.GetCollections();
            // //var wstore= ((TfsTeamProjectCollection )collections[0]).GetService(typeof (WorkItemStore));
            // var ws=tpcService.GetServicingOperation("WorkItemStore");

            // store = (WorkItemStore) tfsConfigurationServer.GetService(typeof (WorkItemStore));
        }

        #region ITFS Members

        public NodeCollection GetIterationPaths(string projectname)
        {
            try
            {
                return store.Projects[projectname].IterationRootNodes;
            }
            catch (Exception)
            {
                //TODO: log error. 
            }
            return null;
        }

        public bool DeletePivotalStoryFromTFS(Story storyToDelete, string projectname, string iterationPath)
        {
            var iteration = store.Projects[projectname].IterationRootNodes[iterationPath];
            if (iteration != null)
            {
                var nodes =
                    store.Projects[projectname].IterationRootNodes[iterationPath].ChildNodes.GetEnumerator();
                while (nodes.MoveNext())
                {
                    if (((WorkItem)nodes.Current).History.Contains(string.Concat(Pivotalid, storyToDelete.Id)))
                    {
                        var workitem = ((WorkItem)nodes.Current);
                        if (workitem != null)
                        {
                            workitem.Open();
                            workitem.Reason = "Deleted in Pivotal.";
                            workitem.State = "Closed";
                            workitem.Save();
                        }
                    }
                }
            }
            return false;
        }

        public void AddPivotalStoryToTFS(Story pivotalStoryToAdd, string projectname, string iterationPath,
                                         string subPath)
        {
            var workItemTypes = store.Projects[projectname].WorkItemTypes;

            var existingworkingItem = GetTFSBacklogItemByPivotalId(projectname, iterationPath, subPath,
                                                                   pivotalStoryToAdd.Id);
            if (existingworkingItem != null)
            {
                existingworkingItem.Description = string.Concat(pivotalStoryToAdd.URL, Environment.NewLine,
                                                                pivotalStoryToAdd.Description);
                existingworkingItem.Save();
                return;
            }

            var workItem = new WorkItem(workItemTypes[ProductBacklogItem]);

            if (pivotalStoryToAdd.Type == "bug")
            {
                workItem = new WorkItem(workItemTypes["Bug"]);
            }

            templateproxy.CopyPivotalStoryValuesToWorkItem(pivotalStoryToAdd, workItem);
            //if (workItem.Fields.Contains(ConchangoTeamsystemScrumEstimatedeffort))
            //{
            //    workItem.Fields[ConchangoTeamsystemScrumEstimatedeffort].Value = pivotalStoryToAdd.Estimate;
            //    workItem.Fields[ConchangoTeamsystemScrumBusinesspriority].Value = pivotalStoryToAdd.Priority;
            //    workItem.Fields[ConchangoTeamsystemScrumDeliveryorder].Value = pivotalStoryToAdd.Priority;
            //}
            //else
            //{
            //    workItem.Fields["Microsoft.VSTS.Scheduling.Effort"].Value = pivotalStoryToAdd.Estimate;
            //    workItem.Fields["Microsoft.VSTS.Common.BacklogPriority"].Value = pivotalStoryToAdd.Priority;
            //}

        workItem.Description = string.Concat(pivotalStoryToAdd.URL, Environment.NewLine,
                                                 pivotalStoryToAdd.Description);
            workItem.Title = pivotalStoryToAdd.Name;
            workItem.IterationPath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);
            workItem.Fields[HistoryField].Value = string.Concat(Pivotalid, pivotalStoryToAdd.Id, ":");

            //Add Hyper Link
            //Link most be valid!
            var hp = new Hyperlink(pivotalStoryToAdd.URL) { Comment = "Link to pivotal story." };
            workItem.Links.Add(hp);

            //Add Attachment
            //TFS will search for the file, so make sure it exists.

            //Attachment a = new Attachment(@"C:\FileToAdd.txt", "Comment....");
            //workItem.Attachments.Add(a);

            //Make sure your Work Item is Valid
            //After you finish adding all the wanted values into the Work Item make sure that all fields are Valid and your can save the Work Item, This step is to make sure that you prepare the Work Item Definition for the migration. 

            var invalidFields = new ArrayList();
            foreach (Field field in workItem.Fields)
            {
                if (!field.IsValid)
                {
                    invalidFields.Add(field);
                    Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Invalid_Field, field.Name, field.Status);
                    Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Current_Value, field.Value);
                }
            }
            //There are some Invalid Fields.
            if (invalidFields.Count > 0)
            {
                Console.WriteLine(Resources.TFS_AddPivotalStoryToTFS_Invalid_Bug_Track_ID, invalidFields.ToArray());
                return;
            }
            workItem.Save();
        }

        public ProjectCollection GetProjects()
        {
            try
            {
                return store.Projects;
            }
            catch (Exception)
            {
                //TODO: log error. 
            }
            return null;
        }

        public void GetNextPriorityNumberAndPriorityStep(string projectname, string iterationPath, string subPath,
                                                         out int nextPriority, out int priorityStep)
        {
            nextPriority = 1;
            priorityStep = 10;
            var workItemTypes = store.Projects[projectname].WorkItemTypes;

            var workitems = GetWorkItems(projectname, iterationPath, subPath, workItemTypes["Product Backlog Item"], -1);

            if (workitems.Count == 0)
            {
                nextPriority = 100;
                priorityStep = 10;
                return;
            }


            int lastWorkItemStepNumber = -1, nextlastWorkItemStepNumber = -1;
            var currentItemIndex = workitems.Count - 1;
            bool foundLastWorkItem = false, foundSecondLastWorkItem = false;
            if (workitems.Count == 1)
            {
                GetPriorityFieldValue(workitems[0], out lastWorkItemStepNumber);
                priorityStep = lastWorkItemStepNumber;
                nextPriority = lastWorkItemStepNumber + priorityStep;
                return;
            }
            //DumpAllWorkItems(workitems);

            while (true)
            {
                try
                {
                    if (!foundLastWorkItem)
                    {
                        var lastWorkItem = workitems[currentItemIndex];
                        GetPriorityFieldValue(lastWorkItem, out lastWorkItemStepNumber);

                        if (lastWorkItemStepNumber > 0)
                        {
                            //next lastWorkItemStepNumber
                            foundLastWorkItem = true;
                        }
                    }

                    if (!foundSecondLastWorkItem)
                    {
                        var nextLastWorkItem = workitems[currentItemIndex - 1];
                        GetPriorityFieldValue(nextLastWorkItem, out nextlastWorkItemStepNumber);

                        foundSecondLastWorkItem = true;
                    }

                    if (foundLastWorkItem)
                    {
                        priorityStep = lastWorkItemStepNumber - nextlastWorkItemStepNumber;
                        break;
                    }
                }
                catch (Exception)
                {
                    //TODO: log error. 
                }
                currentItemIndex--;
                if (currentItemIndex <= 0)
                {
                    break;
                }
            }
            nextPriority = lastWorkItemStepNumber + priorityStep;
        }

        public WorkItemCollection GetWorkItems(string projectname, string iterationPath, string subPath,
                                               WorkItemType workitemtype, int forSpecificBacklogItemId)
        {
            var completeiterationpath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);
            if (forSpecificBacklogItemId < 0)
            {
                return
                    store.Query(
                        string.Format(
                            "SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.WorkItemType] = '{2}'",
                            projectname, completeiterationpath, workitemtype.Name));
            }

            return
                store.Query(
                    string.Format(
                        "SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.WorkItemType] = '{2}' AND [System.BacklogWorkItemId] = '{3}'",
                        projectname, completeiterationpath, workitemtype.Name, forSpecificBacklogItemId));
        }

        public WorkItemTypeCollection GetWorkItemTypes(string projectname)
        {
            return store.Projects[projectname].WorkItemTypes;
        }

        public void UpdateWorkItem(WorkItem workitem)
        {
          //  throw new NotImplementedException();
        }

        #endregion

        private void DumpAllWorkItems(WorkItemCollection workitems)
        {
            foreach (WorkItem item in workitems)
            {
                foreach (Field field in item.Fields)
                {
                    Console.Write(field.Id);
                    Console.Write(":");
                    Console.Write(field.Name);
                    Console.Write(":");
                    Console.Write(field.Value);
                    Console.WriteLine("---");
                }
            }
        }

        private WorkItem GetTFSBacklogItemByPivotalId(string projectname, string iterationPath, string subPath, int id)
        {
            var completeiterationpath = string.Concat(projectname, "\\", iterationPath, "\\", subPath);

            var results=
                store.Query(
                    string.Format(
                        "SELECT * FROM WorkItems WHERE [System.TeamProject] = '{0}' AND [System.IterationPath]='{1}' AND  [System.History] contains '%{2}{3}:%'",
                        projectname, completeiterationpath, Pivotalid, id));
            if (results != null && results.Count >0)
                return results[0];
            else
                return null;
        }

        private static bool GetPriorityFieldValue(WorkItem wrk, out int val)
        {
            const string conchangoTeamsystemScrumBusinesspriority = "Business Priority (Scrum)";
            const string vstsBusinessPriority = "Microsoft.VSTS.Common.BacklogPriority";
            try
            {
                Field field = null;
                if (wrk.Fields.Contains(conchangoTeamsystemScrumBusinesspriority))
                    field = wrk.Fields[conchangoTeamsystemScrumBusinesspriority];
                else
                    field = wrk.Fields[vstsBusinessPriority];
                val = int.Parse(field.Value.ToString());
                return true;
            }
            catch (Exception)
            {
                val = -1;
                return false;
            }
        }
    }
}