using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support.XA.Feature.Maps.Commands
{
    public class WebEditSelectMapPoint : Sitecore.XA.Feature.Maps.Commands.WebEditSelectMapPoint
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