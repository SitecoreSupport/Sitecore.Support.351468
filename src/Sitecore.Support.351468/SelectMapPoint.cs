using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.XA.Feature.Maps.Commands
{
    public class SelectMapPoint : Sitecore.XA.Feature.Maps.Commands.SelectMapPoint
    {
        protected override void Run(ClientPipelineArgs args)
        {
            CheckModifiedParameters parameters = new CheckModifiedParameters();
            parameters.ResumePreviousPipeline = true;
            if (SheerResponse.CheckModified(parameters))
            {
                base.Run(args);
            }
        }
    }
}