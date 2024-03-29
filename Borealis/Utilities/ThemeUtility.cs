﻿using Borealis.Utilities.Options.Theme;
using System.Text.Json;
namespace Borealis.Utilities
{
    public class ThemeUtility
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions() { WriteIndented = true, MaxDepth = 3 };
        public static string filePath = Path.Combine(AppContext.BaseDirectory, @"Config\Theme\Theme.json");

        public static ThemeOptions LoadTheme()
        {
            if (!File.Exists(filePath))
            {
                string json = JsonSerializer.Serialize(new ThemeOptions(), JsonSerializerOptions);
                CreateTheme(json);
                return new ThemeOptions();
            }
            ThemeOptions themeOptions = JsonSerializer.Deserialize<ThemeOptions>(File.ReadAllText(filePath));

            return themeOptions.ToMudTheme();
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
                    if (theme == null)
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
