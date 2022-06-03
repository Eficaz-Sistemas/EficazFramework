using DefaultDocumentation;
using DefaultDocumentation.Models;
using DefaultDocumentation.Api;
using System.IO;

namespace EficazFramework.DocsApiPlugin
{
    public sealed class DocItemUrlFactory : IUrlFactory
    {
        // so it override the default one
        public string Name => "DocItem";

        public string GetUrl(IGeneralContext context, string id)
        {
            if (!context.Items.TryGetValue(id, out DocItem item))
            {
                return null;
            }

            if (item is ExternDocItem externItem)
            {
                return externItem.Url;
            }

            DocItem pagedItem = item;
            while (!pagedItem.HasOwnPage(context))
            {
                pagedItem = pagedItem.Parent;
            }

            // only difference with the default implementation is that you should append the links base url to all urls to make them absolute instead of relative
            // since the urls are only generated once and cached for later use, there's no way to make them aware of a relative page change
            string url = context.Settings.LinksBaseUrl + context.GetFileName(pagedItem);
            if (context.GetRemoveFileExtensionFromUrl() && Path.HasExtension(url))
            {
                url = url.Substring(0, url.Length - Path.GetExtension(url).Length);
            }
            if (item != pagedItem)
            {
                url += "#" + PathCleaner.Clean(item.FullName, context.GetInvalidCharReplacement());
            }

            return url;
        }
    }
}
