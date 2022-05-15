using MudBlazor.Utilities;

using System.Reflection;
namespace Borealis.Web.Utilities.Options.Theme
{
    public static class Extensions
    {
        public static Palette FromPaletteOption(this PaletteOption option)
        {
            Palette p = new Palette();
            List<PropertyInfo> pProps = p.GetType().GetProperties().OrderBy(x => x.Name).ToList();
            List<PropertyInfo> oProps = option.GetType().GetProperties().OrderBy(x => x.Name).ToList();
            foreach (PropertyInfo oProp in oProps)
            {
                PropertyInfo pProp = pProps.First(x => oProp.Name.Equals(x.Name));
                if (pProp.PropertyType.Equals(typeof(MudColor)))
                {
                    MudColor c = new MudColor(oProp.GetValue(option).ToString());
                    pProp.SetValue(p, c);
                }
            }
            return p;
        }
        public static PaletteOption ToPaletteOption(this Palette p)
        {
            PaletteOption pOpt = new PaletteOption();
            List<PropertyInfo> oProps = pOpt.GetType().GetProperties().OrderBy(x => x.Name).ToList();
            List<PropertyInfo> pProps = p.GetType().GetProperties().OrderBy(x => x.Name).ToList();
            foreach (PropertyInfo oProp in oProps)
            {
                PropertyInfo pProp = pProps.First(x => oProp.Name.Equals(x.Name));
                if (pProp.PropertyType.Equals(typeof(MudColor)))
                {
                    MudColor c = new MudColor(pProp.GetValue(p).ToString());
                    oProp.SetValue(pOpt, c.ToString(MudColorOutputFormats.HexA));
                }
            }
            return pOpt;
        }
        public static ThemeOptions ToMudTheme(this ThemeOptions themeOpts)
        {
            MudTheme theme = new MudTheme
            {
                Palette = themeOpts.Palette.FromPaletteOption(),
                PaletteDark = themeOpts.PaletteDark.FromPaletteOption(),
                Shadows = new Shadow(),
                LayoutProperties = new LayoutProperties(),
                Typography = new Typography(),
                ZIndex = new ZIndex()
            };
            themeOpts.Theme = theme;
            return themeOpts;
        }
        public static ThemeOptions ToThemeOptionsFromMudTheme(this MudTheme theme)
        {
            return new ThemeOptions()
            {
                Theme = theme,
                Palette = theme.Palette.ToPaletteOption(),
                PaletteDark = theme.PaletteDark.ToPaletteOption()
            };
        }
    }
}
