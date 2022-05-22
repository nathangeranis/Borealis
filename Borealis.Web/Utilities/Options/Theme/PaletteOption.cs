using MudBlazor.Utilities;
namespace Borealis.Web.Utilities.Options.Theme
{
    public class PaletteOption
    {
        public string Black { get; set; }
        public string White { get; set; }
        public string Primary { get; set; }
        public string PrimaryContrastText { get; set; }
        public string Secondary { get; set; }
        public string SecondaryContrastText { get; set; }
        public string Tertiary { get; set; }
        public string TertiaryContrastText { get; set; }
        public string Info { get; set; }
        public string InfoContrastText { get; set; }
        public string Success { get; set; }
        public string SuccessContrastText { get; set; }
        public string Warning { get; set; }
        public string WarningContrastText { get; set; }
        public string Error { get; set; }
        public string ErrorContrastText { get; set; }
        public string Dark { get; set; }
        public string DarkContrastText { get; set; }
        public string TextPrimary { get; set; }
        public string TextSecondary { get; set; }
        public string TextDisabled { get; set; }
        public string ActionDefault { get; set; }
        public string ActionDisabled { get; set; }
        public string ActionDisabledBackground { get; set; }
        public string Background { get; set; }
        public string BackgroundGrey { get; set; }
        public string Surface { get; set; }
        public string DrawerBackground { get; set; }
        public string DrawerText { get; set; }
        public string DrawerIcon { get; set; }
        public string AppbarBackground { get; set; }
        public string AppbarText { get; set; }
        public string LinesDefault { get; set; } 
        public string LinesInputs { get; set; }
        public string TableLines { get; set; } 
        public string TableStriped { get; set; }
        public string TableHover { get; set; }
        public string Divider { get; set; }
        public string DividerLight { get; set; }
        internal static PaletteOption ConvertToDarkTheme(PaletteOption palette)
        {
            palette.Primary = "#776be7";
            palette.Black = "#27272f";
            palette.Background = "#32333d";
            palette.BackgroundGrey = "#27272f";
            palette.Surface = "#373740";
            palette.DrawerBackground = "#27272f";
            palette.DrawerText = new MudColor("rgba(255,255,255, 0.50)").ToString(MudColorOutputFormats.HexA);
            palette.DrawerIcon = new MudColor("rgba(255,255,255, 0.50)").ToString(MudColorOutputFormats.HexA);
            palette.AppbarBackground = "#27272f";
            palette.AppbarText = new MudColor("rgba(255,255,255, 0.70)").ToString(MudColorOutputFormats.HexA);
            palette.TextPrimary = new MudColor("rgba(255,255,255, 0.70)").ToString(MudColorOutputFormats.HexA);
            palette.TextSecondary = new MudColor("rgba(255,255,255, 0.50)").ToString(MudColorOutputFormats.HexA);
            palette.ActionDefault = "#adadb1";
            palette.ActionDisabled = new MudColor("rgba(255,255,255, 0.26)").ToString(MudColorOutputFormats.HexA);
            palette.ActionDisabledBackground = new MudColor("rgba(255,255,255, 0.12)").ToString(MudColorOutputFormats.HexA);
            palette.Divider = new MudColor("rgba(255,255,255, 0.12)").ToString(MudColorOutputFormats.HexA);
            palette.DividerLight = new MudColor("rgba(255,255,255, 0.06)").ToString(MudColorOutputFormats.HexA);
            palette.TableLines = new MudColor("rgba(255,255,255, 0.12)").ToString(MudColorOutputFormats.HexA);
            palette.LinesDefault = new MudColor("rgba(255,255,255, 0.12)").ToString(MudColorOutputFormats.HexA);
            palette.LinesInputs = new MudColor("rgba(255,255,255, 0.3)").ToString(MudColorOutputFormats.HexA);
            palette.TextDisabled = new MudColor("rgba(255,255,255, 0.2)").ToString(MudColorOutputFormats.HexA);
            palette.Info = "#3299ff";
            palette.Success = "#0bba83";
            palette.Warning = "#ffa800";
            palette.Error = "#f64e62";
            palette.Dark = "#27272f";
            return palette;
        }
    }
}
