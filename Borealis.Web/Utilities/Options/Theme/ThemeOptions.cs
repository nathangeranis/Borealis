using System.Text.Json.Serialization;
namespace Borealis.Web.Utilities.Options.Theme
{
    public partial class ThemeOptions
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public bool RTL { get; set; }
        public string FontFamily { get; set; }
        public int DefaultBorderRadius { get; set; }
        public int DefaultElevation { get; set; }
        public int AppBarElevation { get; set; }
        public int DrawerElevation { get; set; }
        public DrawerClipMode DrawerClipMode { get; set; }
        public PaletteOption Palette { get; set; }
        public PaletteOption PaletteDark { get; set; }
        [JsonIgnore]
        public MudTheme? Theme { get; set; }
    }
}
