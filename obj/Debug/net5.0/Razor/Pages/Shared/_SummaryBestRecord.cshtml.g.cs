#pragma checksum "C:\Users\User\source\repos\ScoreUp\Pages\Shared\_SummaryBestRecord.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73c9615deba12ac91ec7ce51ddd6dd80d0c4f7e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ScoreUp.Pages.Shared.Pages_Shared__SummaryBestRecord), @"mvc.1.0.view", @"/Pages/Shared/_SummaryBestRecord.cshtml")]
namespace ScoreUp.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\User\source\repos\ScoreUp\Pages\_ViewImports.cshtml"
using ScoreUp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\User\source\repos\ScoreUp\Pages\Shared\_SummaryBestRecord.cshtml"
using ScoreUp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73c9615deba12ac91ec7ce51ddd6dd80d0c4f7e1", @"/Pages/Shared/_SummaryBestRecord.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15132bb56248bdb4efbc80017b72cebf8d727316", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared__SummaryBestRecord : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RecordInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div style=\"padding-top: 20px; \">\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h3>Giocatore: ");
#nullable restore
#line 8 "C:\Users\User\source\repos\ScoreUp\Pages\Shared\_SummaryBestRecord.cshtml"
                      Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <ul class=\"list-group list-group-flush\">\r\n\r\n                <li class=\"list-group-item\">Nome Giocatore: ");
#nullable restore
#line 13 "C:\Users\User\source\repos\ScoreUp\Pages\Shared\_SummaryBestRecord.cshtml"
                                                       Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">Cognome Giocatore: ");
#nullable restore
#line 14 "C:\Users\User\source\repos\ScoreUp\Pages\Shared\_SummaryBestRecord.cshtml"
                                                          Write(Model.Cognome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">Numeri di Record: ");
#nullable restore
#line 15 "C:\Users\User\source\repos\ScoreUp\Pages\Shared\_SummaryBestRecord.cshtml"
                                                         Write(Model.RecordPartite);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n               \r\n            </ul>\r\n        </div>\r\n       \r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RecordInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591
