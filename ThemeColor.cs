using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esto
{
    public static class ThemeColor
    {
        public static List<string> ColorList = new List<string>()
        {
            "#800000",
            "#ff0000",	
            "#800080",	
            "#ff00ff",		
            "#008000",
            "#00ff00",	
	        "#808000",	
	        "#ffff00",
	        "#000080",
	        "#0000ff",
	        "#008080",
	        "#00ffff",
	        "#ffa500",
	        "#faebd7",
	        "#7fffd4",
	        "#ffe4c4",
	        "#ffebcd",
	        "#8a2be2",
	        "#a52a2a",
            "#ff7f50"
        };
        public static Color ChangeColorBrightness(Color color,double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            if(correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A,(byte)red, (byte)green, (byte)blue);
        }   
    }
}
