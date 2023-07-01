using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json.Linq;

namespace Audisoft.Application.CustomAttributes
{
    public class Version : Attribute, IActionConstraint
    {

        public Version(string Header, string Version)
        {
            this.header = Header;
            this.version = Version;
        }

        public string header { get; }
        public string version { get; }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var headers = context.RouteContext.HttpContext.Request.Headers;
            if (!headers.ContainsKey(header))
                return false;

            return string.Equals(headers[header], version, StringComparison.OrdinalIgnoreCase);
        }
    }
}
