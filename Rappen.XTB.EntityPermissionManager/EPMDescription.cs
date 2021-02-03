using System;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.EPM
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Portal Entity Permission Manager"),
        ExportMetadata("Description", "Manage Power Apps Portals Entity Permissions and visualize their true structure."),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAMAAABEpIrGAAAAFXRFWHRDcmVhdGlvbiBUaW1lAAflAQgMORMkqPe+AAAAB3RJTUUH5QEIDykoCCZR4gAAAAlwSFlzAAAKjAAACowBvcbP2AAAAaRQTFRF///G3ufGrca9jKW9e5y9hKW9pb291t7GIVq1AEKtAEq9IVqcKWOUGFqta5S17/fGCEqlUoRzSoScAGP/rc5S1ucpMXu1Y4xrEFKlWoS1vc69GFKtAEK1MXOt9/cIhLV7WpSMEEqtlK29AErOAGP3zt4x5+8YEGvvxt455+8QAFLWlLW9GFKcY5R7Y6WcjLVz//8Ac62MOYTGe62EAFrnc5y9tcYx7/cQMYTOtdZKQoSlnLW9MWuUzt4hGGO93u8hSpS1UoR7CEqtvdZCpcZSEGvna6WUSnu15+/GAFLenL1CWpylc6WMlL1jCGvvxta9lL1rWoxzAFrvKXPGhK1rlLVSe7V7MYTGIXPeKWO1CGv3WpSUGHPn3uchKXvWUpSt9//GSoy1WpycY5ycIWO13ucYjK29AErGGFqlxt4xWpSElK1KOXOM1uchCFLGc62EQoy9IXveSpStvdY59/8Ie6VaUpylUoS1CFrWxtYpY4y1tdZCQnOEQnO1EFKtQnuM1t4hWoxrY4x7SoSUvc4pEEqlhK1Sc5xjQoytKWucOWuMc5S9fLR2XQAAAAF0Uk5TAEDm2GYAAAKXSURBVHjabZPrWxJBFMYXw8tZEa0RDVzX27LianpEFK3UYpS8YCpakglYJEhGamkmpd3v/3RnBhB99HzYfXbf3zPn9o6ilGNzsXc4n//X6dlUrorq/Clo6p+/GQ1C7sVLsu0IHL/aGWt0Mfb70AEn1Rf1qg616aCRCWB0aCqIq6eh9Hm9Eiwja3YTMIWILq+J+s+G/OY5fZYlMUX6XrAnQlzUMYfHP/IlvQK+GYzHDcYSwfFtJiKjJfXvUMwyc/oJXWEcov/crFPp1Rb//MX6is2hQqV5jSVziAMx5sdwhoBd/HCMH7VsTj2RDUKAMcOri+L096oWsLLH0BDcMVK4Ah4ChjU61NAXErtj+jiIGNmaaDo4jCbwXeaIgBqLgH3ZA38bzWhRw0+nbfUFYpgKhOopQ5SkZ7gnhpBjoga2PxieBsuPbwzKUQGirRTG6BnBmAREQNcubjAtraRFCWwQaTzrHNfOAO31JKd5OBV7LaeIo4/zHC6rGqiFgB2Mc/7Krdi3i0AW8aVaBnbQyyVQSrHB8bmY8fZSMjadiMSRy5E7z4r0Ct1Yf7GFMny4JCtJKzPFNoW+biLqfn8qPB/rxkExPyBrPbFk/U/pewN9k/GEsAWtJUnP2Q7yRCUVsYTLXdGV1UeF44P88VpYDkZ1i22HZtmYVwWYo3XN+8z5yIKXMgUfMhYAaV6nZnDakjXlYgXTMjYdRjT7DfWB9EN9y10cn6htnfSdAewetvnwfshWsJQHRmTq0TIwZhrsNtwpmbK371b/gOyrCPjJgAEYLtu+E7oMr7S9BAxfT7cF9vMXw9OiteqNJaBNb1c7qi5erXonNFy/UQCamm+C23b5dtprANRaB02kzlmtXBm2imt2e2XVBfU/o4KP2jCFJSoAAAAASUVORK5CYII="),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#FFFFC0"),
        ExportMetadata("PrimaryFontColor", "#0000C0"),
        ExportMetadata("SecondaryFontColor", "#0000FF")]
    public class EPMDescription : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new EPMControl();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public EPMDescription()
        {
            // If you have external assemblies that you need to load, uncomment the following to
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}