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
            foreach (PropertyInfo pProp in pProps)
            {
                foreach (PropertyInfo oProp in oProps)
                {
                    if (!pProp.Name.Equals(oProp.Name))
                        break;
                    if (pProp.PropertyType.Equals(typeof(MudColor)))
                    {
                        MudColor c = new MudColor(oProp.GetValue(option).ToString());
                        pProp.SetValue(p, c);

                    }
                }
            }
            return p;
        }
        public static MudTheme ToMudTheme(this ThemeOptions themeOpts)
        {
            MudTheme theme = new MudTheme
            { 
                Palette = themeOpts.Palette.FromPaletteOption() 
            };
            return theme;
        }
    }
}
