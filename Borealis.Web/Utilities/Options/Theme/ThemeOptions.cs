using System.Text.Json.Serialization;
namespace Borealis.Web.Utilities.Options.Theme
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
        public ShadowOption Shadow { get; set; }
        //public TypographyOption Typography { get; set; }
        //public LayoutOption LayoutProperties { get; set; }
        //public ZIndexOption ZIndex { get; set; }
        [JsonIgnore]
        public MudTheme? Theme { get; set; }
        public ThemeOptions()
        {
            RTL = false;
            FontFamily = "Roboto";
            DefaultBorderRadius = 4;
            DefaultElevation = 1;
            AppBarElevation = 25;
            DrawerElevation = 2;
            DrawerClipMode = DrawerClipMode.Docked;
            Palette = new PaletteOption();
            PaletteDark = PaletteOption.ConvertToDarkTheme(Palette);
            Shadow = new ShadowOption();
        }
        public partial class TypographyOption
        {

        }
        public partial class LayoutOption
        {

        }
        public partial class ZIndexOption
        {

        }
    }
}
