using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBTBlazor.MessageHandlers
{
    public class CBTApiAuthorizationMessageHandler : AuthorizationMessageHandler
    {
       
        public CBTApiAuthorizationMessageHandler(
            IAccessTokenProvider provider, NavigationManager navigation) 
            : base(provider, navigation)
        {
            ConfigureHandler(
                  authorizedUrls: new[] { "https://localhost:4002/" });
        }
    }
}
