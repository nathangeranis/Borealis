﻿using Borealis.Web.Utilities.Options.Theme;
using System.Text.Json;
namespace Borealis.Web.Utilities
{
    public class ThemeUtility
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, MaxDepth = 3 };
        public static string filePath = Path.Combine(AppContext.BaseDirectory, @"Config\Theme\Theme.json");

        public static async Task<ThemeOptions> LoadTheme(CosmosRepository<ThemeOptions> Repo)
        {
            try
            {
                Repo.Initialize("Resources", "Default");
                var options = await Repo.GetItemsAsync();
                Global.SetThemeOptions(options.FirstOrDefault().ToMudTheme());

                return await Global.GetThemeOptions();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public static void CreateOrUpdateTheme(MudTheme _theme)
        {
            try
            {
                if (!File.Exists(filePath))
                    CreateTheme(JsonSerializer.Serialize(_theme.ToThemeOptionsFromMudTheme(), JsonSerializerOptions));
                else
                {
                    string json = File.ReadAllText(filePath);
                    ThemeOptions theme = JsonSerializer.Deserialize<ThemeOptions>(json);
                    if ((object)theme == null)
                        CreateTheme(JsonSerializer.Serialize(_theme.ToThemeOptionsFromMudTheme(), JsonSerializerOptions));
                    else
                        UpdateTheme(theme, _theme);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing app settings");
            }
        }

        private static void UpdateTheme(ThemeOptions fromFile, MudTheme fromUser)
        {
            if (fromUser.Equals(fromFile.ToMudTheme()))
                return;
            CreateTheme(JsonSerializer.Serialize(fromUser.ToThemeOptionsFromMudTheme(), JsonSerializerOptions));
        }
        private static void CreateTheme(string output)
        {
            if (!Directory.Exists(Path.Combine(AppContext.BaseDirectory, @"Config\Theme")))
                Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, @"Config\Theme"));
            File.WriteAllText(filePath, output);
        }
    }
}
