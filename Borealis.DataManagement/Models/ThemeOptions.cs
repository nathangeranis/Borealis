using System.Text.Json.Serialization;
namespace Borealis.DataManagement.Models
{
    public partial class ThemeOptions
    {
        public bool RTL { get; set; }
        public string FontFamily { get; set; }
        public int DefaultBorderRadius { get; set; }
        public int DefaultElevation { get; set; }
        public int AppBarElevation { get; set; }
        public int DrawerElevation { get; set; }
        public DrawerClipMode DrawerClipMode { get; set; }
        public PaletteOption Palette { get; set; }
        public PaletteOption PaletteDark { get; set; }
        public ThemeOptions()
        {
            RTL = false;
            FontFamily = "Roboto";
            DefaultBorderRadius = 8;
            DefaultElevation = 1;
            AppBarElevation = 25;
            DrawerElevation = 2;
            DrawerClipMode = DrawerClipMode.Always;
            Palette = new PaletteOption();
            PaletteDark = PaletteOption.ConvertToDarkTheme(Palette);
        }
    }
}
