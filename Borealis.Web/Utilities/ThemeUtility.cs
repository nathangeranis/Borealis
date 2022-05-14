using Borealis.Web.Utilities.Options.Theme;

using System.Text.Json;
namespace Borealis.Web.Utilities
{
    public class ThemeUtility
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, MaxDepth = 3 };
        public static string filePath = Path.Combine(AppContext.BaseDirectory, @"Config\Theme\Theme.json");

        public static MudTheme LoadTheme()
        {
            if (!File.Exists(filePath))
            {
                string json = JsonSerializer.Serialize(new ThemeOptions(), JsonSerializerOptions);
                CreateTheme(json, false);
                return new MudTheme();
            }
            ThemeOptions themeOptions = JsonSerializer.Deserialize<ThemeOptions>(File.ReadAllText(filePath));

            return themeOptions.ToMudTheme();
        }
        public static void CreateOrUpdateTheme(MudTheme _theme)
        {

            //try
            //{
            //    if (!Directory.Exists(filePath))
            //        CreateTheme(JsonSerializer.Serialize(_theme, JsonSerializerOptions), false);
            //    else
            //    {
            //        string json = File.ReadAllText(filePath);
            //        MudTheme theme = JsonSerializer.Deserialize<MudTheme>(json);
            //        if (theme == null)
            //            CreateTheme(JsonSerializer.Serialize(_theme, JsonSerializerOptions));
            //        else
            //            UpdateTheme(theme, _theme);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error writing app settings");
            //}
        }

        private static void UpdateTheme(MudTheme fromFile, MudTheme fromUser)
        {
            if (!fromUser.Equals(fromFile))
                return;
            CreateTheme(JsonSerializer.Serialize(fromUser, JsonSerializerOptions));
        }
        private static void CreateTheme(string output, bool directoryExists = true)
        {
            if (!directoryExists)
                Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, @"Config\Theme"));
            File.WriteAllText(filePath, output);
        }
    }
}
