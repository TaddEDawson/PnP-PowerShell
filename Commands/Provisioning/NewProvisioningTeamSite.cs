﻿using OfficeDevPnP.Core.Framework.Provisioning.Model;
using SharePointPnP.PowerShell.CmdletHelpAttributes;
using System.Linq;
using System.Management.Automation;

namespace SharePointPnP.PowerShell.Commands.Provisioning
{
    [Cmdlet(VerbsCommon.New, "PnPProvisioningTeamSite", SupportsShouldProcess = true)]
    [CmdletHelp("Creates a team site object",
        Category = CmdletHelpCategory.Provisioning)]
    [CmdletExample(
       Code = @"PS:> $site = New-PnPProvisioningTeamSite -Alias ""MyTeamSite"" -Title ""My Team Site""",
       Remarks = "Creates a new team site object with the specified variables",
       SortOrder = 1)]
    public class NewProvisioningTeamSite : PSCmdlet
    {

        [Parameter(Mandatory = true)]
        public string Alias;

        [Parameter(Mandatory = true)]
        public string Title;

        [Parameter(Mandatory = false)]
        public string Description = "";

        [Parameter(Mandatory = false)]
        public string DisplayName = "";

        [Parameter(Mandatory = false)]
        public string Classification;

        [Parameter(Mandatory = false)]
        public SwitchParameter Public;

        [Parameter(Mandatory = false)]
        public SwitchParameter HubSite;

        [Parameter(Mandatory = false)]
        public string[] TemplateIds;

        protected override void ProcessRecord()
        {
            var site = new TeamSiteCollection
            {
                Alias = Alias,
                Classification = Classification,
                Description = Description,
                DisplayName = DisplayName,
                IsHubSite = HubSite.IsPresent,
                IsPublic = Public.IsPresent,
                Title = Title
            };
            if (TemplateIds != null)
            {
                site.Templates.AddRange(TemplateIds.ToList());
            } 
            WriteObject(site);
        }
    }
}
