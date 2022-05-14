using MudBlazor.Utilities;
namespace Borealis.Web.Utilities.Options.Theme
{
    public class PaletteOption
    {
        public string Black { get; set; } = "#272c34";
        public string White { get; set; } = Colors.Shades.White;
        public string Primary { get; set; } = "#594AE2";
        public string PrimaryContrastText { get; set; } = Colors.Shades.White;
        public string Secondary { get; set; } = Colors.Pink.Accent2;
        public string SecondaryContrastText { get; set; } = Colors.Shades.White;
        public string Tertiary { get; set; } = "#1EC8A5";
        public string TertiaryContrastText { get; set; } = Colors.Shades.White;
        public string Info { get; set; } = Colors.Blue.Default;
        public string InfoContrastText { get; set; } = Colors.Shades.White;
        public string Success { get; set; } = Colors.Green.Accent4;
        public string SuccessContrastText { get; set; } = Colors.Shades.White;
        public string Warning { get; set; } = Colors.Orange.Default;
        public string WarningContrastText { get; set; } = Colors.Shades.White;
        public string Error { get; set; } = Colors.Red.Default;
        public string ErrorContrastText { get; set; } = Colors.Shades.White;
        public string Dark { get; set; } = Colors.Grey.Darken3;
        public string DarkContrastText { get; set; } = Colors.Shades.White;
        public string TextPrimary { get; set; } = Colors.Grey.Darken3;
        public string TextSecondary { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.54).ToString(MudColorOutputFormats.HexA);
        public string TextDisabled { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.38).ToString(MudColorOutputFormats.HexA);
        public string ActionDefault { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.54).ToString(MudColorOutputFormats.HexA);
        public string ActionDisabled { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.26).ToString(MudColorOutputFormats.HexA);
        public string ActionDisabledBackground { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.12).ToString(MudColorOutputFormats.HexA);
        public string Background { get; set; } = Colors.Shades.White;
        public string BackgroundGrey { get; set; } = Colors.Grey.Lighten4;
        public string Surface { get; set; } = Colors.Shades.White;
        public string DrawerBackground { get; set; } = Colors.Shades.White;
        public string DrawerText { get; set; } = Colors.Grey.Darken3;
        public string DrawerIcon { get; set; } = Colors.Grey.Darken2;
        public string AppbarBackground { get; set; } = "#594AE2";
        public string AppbarText { get; set; } = Colors.Shades.White;
        public string LinesDefault { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.12).ToString(MudColorOutputFormats.HexA);
        public string LinesInputs { get; set; } = Colors.Grey.Lighten1;
        public string TableLines { get; set; } = new MudColor(Colors.Grey.Lighten2).SetAlpha(1.0).ToString(MudColorOutputFormats.HexA);
        public string TableStriped { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.02).ToString(MudColorOutputFormats.HexA);
        public string TableHover { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.04).ToString(MudColorOutputFormats.HexA);
        public string Divider { get; set; } = Colors.Grey.Lighten2;
        public string DividerLight { get; set; } = new MudColor(Colors.Shades.Black).SetAlpha(0.8).ToString(MudColorOutputFormats.HexA);
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
