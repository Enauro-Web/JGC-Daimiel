#pragma checksum "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df9fca6705046862e0b83c746dc2216912d6b30e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Historico), @"mvc.1.0.view", @"/Views/Home/Historico.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Historico.cshtml", typeof(AspNetCore.Views_Home_Historico))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\_ViewImports.cshtml"
using Daimiel;

#line default
#line hidden
#line 2 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\_ViewImports.cshtml"
using Daimiel.Models;

#line default
#line hidden
#line 2 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df9fca6705046862e0b83c746dc2216912d6b30e", @"/Views/Home/Historico.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d22da33e1000a77a37d39abf8c9039052c2fa5b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Historico : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Daimiel.Models.TblLlenadoras>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(80, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
  
    ViewData["Title"] = "Historico";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(174, 491, true);
            WriteLiteral(@"
<div class=""jumbotron jumbotron-fluid mt-2"">
    <div class=""container"">
        <h1 class=""display-4"">Históricos</h1>
        <p class=""lead"">En esta tabla se listan los datos históricos de producciones de llenadoras</p>
    </div>
</div>

<!--<p>
    <a asp-action=""Create"">Create New</a>
</p>-->

<div class=""container-fluid mt-2"">
    <div class=""row"">
        <div class=""form-group col-md-3"">
            <select class=""form-control"" id=""cbLlenadora"">
                ");
            EndContext();
            BeginContext(665, 46, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df9fca6705046862e0b83c746dc2216912d6b30e4457", async() => {
                BeginContext(682, 20, true);
                WriteLiteral("Selecciona Llenadora");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(711, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 25 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(778, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(798, 50, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df9fca6705046862e0b83c746dc2216912d6b30e6148", async() => {
                BeginContext(828, 11, false);
#line 27 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                                            Write(item.puesto);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 27 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                       WriteLiteral(item.puesto);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(848, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 28 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                }

#line default
#line hidden
            BeginContext(869, 2719, true);
            WriteLiteral(@"            </select>
        </div>
        <div class=""form-group col-md-6"">
            <div class=""form-check form-check-inline"">
                <input class=""form-check-input"" type=""checkbox"" value="""" id=""chIniciado"" checked>
                <label class=""form-check-label"" for=""chIniciado"">
                    Iniciado
                </label>
            </div>
            <div class=""form-check form-check-inline"">
                <input class=""form-check-input"" type=""checkbox"" value="""" id=""chFinalizado"" checked>
                <label class=""form-check-label"" for=""chFinalizado"">
                    Finalizado
                </label>
            </div>
            <div class=""form-check form-check-inline"">
                <input class=""form-check-input"" type=""checkbox"" value="""" id=""chConsolidado"" checked>
                <label class=""form-check-label"" for=""chConsolidado"">
                    Consolidado
                </label>
            </div>
        </div>
        <div clas");
            WriteLiteral(@"s=""form-group col-md-3"">
            <nav aria-label=""..."">
                <ul class=""pagination"">
                    <li class=""page-item disabled"">
                        <a class=""page-link"" href=""#"" tabindex=""-1"">Previous</a>
                    </li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">1</a></li>
                    <li class=""page-item active"">
                        <a class=""page-link"" href=""#"">2 <span class=""sr-only"">(current)</span></a>
                    </li>
                    <li class=""page-item""><a class=""page-link"" href=""#"">3</a></li>
                    <li class=""page-item"">
                        <a class=""page-link"" href=""#"">Next</a>
                    </li>
                </ul>
            </nav>
        </div>
    </div>
    <table class=""table table-striped table-hover"" id=""tbl"">
        <thead class=""thead-dark"">
            <tr>
                <th>
                    Orden
                </th>
                <th");
            WriteLiteral(@">
                    Semielaborado
                </th>
                <!--<th>
                    Origen
                </th>-->
                <th>
                    Llenadora
                </th>
                <th>
                    Inicio
                </th>
                <th>
                    Fin
                </th>
                <th>
                    Cantidad
                </th>
                <th>
                    Duración
                </th>
                <th>
                    Estado
                </th>
                <!--<th></th>-->
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 103 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(3645, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3718, 40, false);
#line 107 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.DisplayFor(modelItem => item.orden));

#line default
#line hidden
            EndContext();
            BeginContext(3758, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3838, 48, false);
#line 110 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.DisplayFor(modelItem => item.semielaborado));

#line default
#line hidden
            EndContext();
            BeginContext(3886, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3966, 41, false);
#line 113 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.DisplayFor(modelItem => item.puesto));

#line default
#line hidden
            EndContext();
            BeginContext(4007, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4087, 47, false);
#line 116 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.DisplayFor(modelItem => item.fecha_inicio));

#line default
#line hidden
            EndContext();
            BeginContext(4134, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
#line 118 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                      
                        DateTimeFormatInfo datetimeFormat = new CultureInfo("es-ES", false).DateTimeFormat;
                        if (item.fecha_fin == Convert.ToDateTime("01-01-1900", datetimeFormat))
                        {

#line default
#line hidden
            BeginContext(4420, 105, true);
            WriteLiteral("                            <td>\r\n                                --\r\n                            </td>\r\n");
            EndContext();
#line 125 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(4609, 66, true);
            WriteLiteral("                            <td>\r\n                                ");
            EndContext();
            BeginContext(4676, 44, false);
#line 129 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                           Write(Html.DisplayFor(modelItem => item.fecha_fin));

#line default
#line hidden
            EndContext();
            BeginContext(4720, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 131 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(4807, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(4858, 43, false);
#line 134 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.DisplayFor(modelItem => item.cantidad));

#line default
#line hidden
            EndContext();
            BeginContext(4901, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4981, 43, false);
#line 137 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.DisplayFor(modelItem => item.duracion));

#line default
#line hidden
            EndContext();
            BeginContext(5024, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
#line 139 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                      
                        if (item.estado == "Iniciado")
                        {

#line default
#line hidden
            BeginContext(5160, 88, true);
            WriteLiteral("                            <td class=\"table-warning\">\r\n                                ");
            EndContext();
            BeginContext(5249, 41, false);
#line 143 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                           Write(Html.DisplayFor(modelItem => item.estado));

#line default
#line hidden
            EndContext();
            BeginContext(5290, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 145 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                        }
                        else if (item.estado == "Finalizado")
                        {

#line default
#line hidden
            BeginContext(5444, 88, true);
            WriteLiteral("                            <td class=\"table-success\">\r\n                                ");
            EndContext();
            BeginContext(5533, 41, false);
#line 149 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                           Write(Html.DisplayFor(modelItem => item.estado));

#line default
#line hidden
            EndContext();
            BeginContext(5574, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 151 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                        }
                        else if (item.estado == "Consolidado")
                        {

#line default
#line hidden
            BeginContext(5729, 88, true);
            WriteLiteral("                            <td class=\"table-primary\">\r\n                                ");
            EndContext();
            BeginContext(5818, 41, false);
#line 155 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                           Write(Html.DisplayFor(modelItem => item.estado));

#line default
#line hidden
            EndContext();
            BeginContext(5859, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 157 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(5980, 66, true);
            WriteLiteral("                            <td>\r\n                                ");
            EndContext();
            BeginContext(6047, 41, false);
#line 161 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                           Write(Html.DisplayFor(modelItem => item.estado));

#line default
#line hidden
            EndContext();
            BeginContext(6088, 37, true);
            WriteLiteral("\r\n                            </td>\r\n");
            EndContext();
#line 163 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                        }
                    

#line default
#line hidden
            BeginContext(6175, 56, true);
            WriteLiteral("\r\n                    <!--<td>\r\n                        ");
            EndContext();
            BeginContext(6232, 65, false);
#line 167 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(6297, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(6326, 71, false);
#line 168 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(6397, 28, true);
            WriteLiteral(" |\r\n                        ");
            EndContext();
            BeginContext(6426, 69, false);
#line 169 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(6495, 55, true);
            WriteLiteral("\r\n                    </td>-->\r\n                </tr>\r\n");
            EndContext();
#line 172 "C:\Users\ESORTIZPOSTR\source\repos\JGC\Daimiel\Views\Home\Historico.cshtml"
            }

#line default
#line hidden
            BeginContext(6565, 3250, true);
            WriteLiteral(@"        </tbody>
    </table>    
</div>

<script>
    $(document).ready(function () {

        $(""#cbLlenadora"").change(() => {           
            prepareAjaxQuery();
        });

        $(""#chIniciado"").change(() => {
            prepareAjaxQuery();
        });

        $(""#chFinalizado"").change(() => {
            prepareAjaxQuery();
        });

        $(""#chConsolidado"").change(() => {
            prepareAjaxQuery();
        });

    });

    function prepareAjaxQuery() {
        var oFilter = new Object();
        var llenadora = $(""#cbLlenadora"").val();
        var estadoIniciado = 0;
        var estadoFinalizado = 0;
        var estadoConsolidado = 0;
        if ($(""#chIniciado"").is(':checked'))
            estadoIniciado = 1;
        if ($(""#chFinalizado"").is(':checked'))
            estadoFinalizado = 2;
        if ($(""#chConsolidado"").is(':checked'))
            estadoConsolidado = 4;
        oFilter.llenadora = llenadora;
        oFilter.estado = estadoI");
            WriteLiteral(@"niciado + estadoFinalizado + estadoConsolidado;
        ajaxFilterQuery('/Home/FiltrarLlenadoras', oFilter);
    }

    function ajaxFilterQuery(urlToSend, objDato) {

        //debugger;         
        //console.log(objDato);
        $.ajax({
            type: ""POST"",
            url: urlToSend,
            contentType: 'application/json',
            data: JSON.stringify(objDato),
            success: function (result) {
                console.log(result);
                $(""#tbl > tbody"").empty();
                $.each(result, (index, item) => {

                    var fecha_fin = '';
                    if (item.fecha_fin == '1900-01-01T00:00:00')
                        fecha_fin = '---';
                    else
                        fecha_fin = new Date(item.fecha_fin).toLocaleString('es-ES');

                    var lastColumn = '';

                    if (item.estado == ""Iniciado"")
                    {
                        lastColumn = '<td class=""table-warnin");
            WriteLiteral(@"g"">Iniciado</td>';
                    }
                    else if (item.estado == ""Finalizado"")
                    {
                        lastColumn = '<td class=""table-success"">Finalizado</td>';
                    }
                    else if (item.estado == ""Consolidado"")
                    {
                        lastColumn = '<td class=""table-primary"">Consolidado</td>';
                    }
                    else
                    {
                        lastColumn = '<td>Desconocido</td>';
                    }

                    $(""#tbl > tbody:last-child"").append($('<tr><td>' + item.orden + '</td><td>' + item.semielaborado + '</td><td>' + item.puesto + '</td><td>' + new Date(item.fecha_inicio).toLocaleString('es-ES') + '</td><td>' + fecha_fin + '</td><td>' + item.cantidad + '</td><td>' + item.duracion + '</td>' + lastColumn + '</tr>'));
                    //console.log(item.material + "" - "" + item.semielaborado);
                    $(""#inputSemielaborado"").val(it");
            WriteLiteral("em.semielaborado);\r\n                });\r\n            },\r\n            error: function (result) {\r\n                alert(\'error\');\r\n            }\r\n        });\r\n\r\n    }\r\n</script>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Daimiel.Models.TblLlenadoras>> Html { get; private set; }
    }
}
#pragma warning restore 1591
