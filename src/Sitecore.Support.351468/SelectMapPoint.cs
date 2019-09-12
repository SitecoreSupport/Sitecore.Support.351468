using Newtonsoft.Json;
using Sitecore.Data;
using Sitecore.Data.Items;
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
            if (!args.IsPostBack)
            {
                base.Context.ClientPage.SendMessage(this, string.Format("item:save(id={0})", args.Parameters["itemId"]));
                base.ShowDialog(args.Parameters);
                args.WaitForPostBack();
            }
            else
            {
                if (!string.IsNullOrEmpty(args.Result) && args.Result.ToUpperInvariant() != "UNDEFINED")
                {
                    Dictionary<string, string> result = JsonConvert.DeserializeObject<Dictionary<string, string>>(args.Result);
                    Item item = base.Context.ContentDatabase.Items.GetItem(ID.Parse(args.Parameters["itemId"]));
                    if (!base.Validate(item, result))
                    {
                        return;
                    }
                    base.EditItem(item, result);
                }
                base.Context.ClientPage.SendMessage(this, string.Format("item:load(id={0})", args.Parameters["itemId"]));
            }
        }
    }
}