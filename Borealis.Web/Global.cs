global using System.Xml;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.Extensions.Configuration;
global using MudBlazor;
global using MudBlazor.Services;
global using Borealis.Web;
global using Borealis.Web.Utilities;
global using Borealis.DataManagement;
global using NLog.Web;
global using Force.DeepCloner;
using Borealis.Web.Utilities.Options.Theme;

namespace Borealis.Web
{
    public static class Global
    {
        private static ThemeOptions ThemeOptions { get; set; }
        public static bool IsDarkMode { get; set; } = false;
        public static async Task<ThemeOptions> GetThemeOptions()
        {
            return ThemeOptions;
        }
        public static void SetThemeOptions(ThemeOptions _themeOptions)
        {
            ThemeOptions = _themeOptions;
        }
    }
}
