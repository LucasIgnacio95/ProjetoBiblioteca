#pragma checksum "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39f610839852c666fb54de94aabe51afd1226429"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_listaDeUsuarios), @"mvc.1.0.view", @"/Views/Usuario/listaDeUsuarios.cshtml")]
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
#nullable restore
#line 1 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\_ViewImports.cshtml"
using Biblioteca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\_ViewImports.cshtml"
using Biblioteca.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39f610839852c666fb54de94aabe51afd1226429", @"/Views/Usuario/listaDeUsuarios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ea07f0214da259abc315dec5bc842518e8ae187", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_listaDeUsuarios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Usuários cadastrados no sistema</h1>\r\n\r\n<p class=\"text-danger\">");
#nullable restore
#line 4 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
                  Write(ViewData["mensangem"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th scope=\"row\">Nome</th>\r\n            <th scope=\"row\">Login</th>\r\n            <th scope=\"row\">Tipo</th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n");
#nullable restore
#line 16 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
         foreach (Usuario u in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 19 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
               Write(u.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
               Write(u.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 21 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
                 if (u.Tipo == Usuario.admin)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Administrador</td>\r\n");
#nullable restore
#line 24 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <td>Padrão</td>\r\n");
#nullable restore
#line 28 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td><a");
            BeginWriteAttribute("href", " href=\"", 716, "\"", 745, 2);
            WriteAttributeValue("", 723, "EditarUsuario?Id=", 723, 17, true);
#nullable restore
#line 29 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
WriteAttributeValue("", 740, u.Id, 740, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 782, "\"", 812, 2);
            WriteAttributeValue("", 789, "ExcluirUsuario?Id=", 789, 18, true);
#nullable restore
#line 30 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
WriteAttributeValue("", 807, u.Id, 807, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Excluir</td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "C:\Users\lucca\Desktop\SENAC\Atividade 1 Mantis\Biblioteca\Views\Usuario\listaDeUsuarios.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<a href=\"RegistrarUsuario\">Registrar novo usuário</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591
