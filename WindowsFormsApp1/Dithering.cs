using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Dithering
    {
        Color[] colors;

        private int NearestColor(int b, int g, int r)
        {
            double minDistanse=int.MaxValue;
            int indexColor = 0;
            double temp;
            for (int i=0;i<colors.Length;i++)
            {
                temp = Math.Sqrt(0.07*Pow(b-colors[i].B)+0.71*Pow(g-colors[i].G)+0.22*Pow(r-colors[i].R));
                if (temp < minDistanse)
                {
                    minDistanse = temp;
                    indexColor = i;
                }
            }

            return indexColor;
        }

        private double Pow(double number)
        {
            return number * number;
        }

        public void doReplace(byte[] rgbValues, int width, Color[] colors0)
        {
            colors = colors0;
            int replaceColor;
            double dR, dB, dG;
            int counter = 0;
            for(int i = 0; i < rgbValues.Length; i+=3)
            {
                if ((i + 2)<rgbValues.Length)
                {
                    
                        replaceColor = NearestColor(rgbValues[i], rgbValues[i + 1], rgbValues[i + 2]);

                        dB = rgbValues[i] - colors[replaceColor].B; dG = rgbValues[i + 1] - colors[replaceColor].G; dR = rgbValues[i + 2] - colors[replaceColor].R;

                        
                    if (i + width + 5 < rgbValues.Length)
                    {

                        if ((i+3)%width != 0 )
                        {
                            rgbValues[i] = colors[replaceColor].B; rgbValues[i + 1] = colors[replaceColor].G; rgbValues[i + 2] = colors[replaceColor].R;
                            rgbValues[i + width] += (byte)(dB * ((double)3 / 8)); rgbValues[i + width + 1] += (byte)(dG * ((double)3 / 8)); rgbValues[i + width + 2] += (byte)(dR * ((double)3 / 8));
                            rgbValues[i + 3] += (byte)(dB * ((double)3 / 8)); rgbValues[i + 4] += (byte)(dG * ((double)3 / 8)); rgbValues[i + 5] += (byte)(dR * ((double)3 / 8));
                            rgbValues[i + width + 3] += (byte)(dB * ((double)1 / 4)); rgbValues[i + width + 4] += (byte)(dG * ((double)1 / 4)); rgbValues[i + width + 5] += (byte)(dR * ((double)1 / 4));

                        }
                        else
                        {
                            counter++;
                            rgbValues[i] = colors[replaceColor].B; rgbValues[i + 1] = colors[replaceColor].G; rgbValues[i + 2] = colors[replaceColor].R;
                            
                            rgbValues[i + width] += (byte)(dB * ((double)3 / 8)); rgbValues[i + width + 1] += (byte)(dG * ((double)3 / 8)); rgbValues[i + width + 2] += (byte)(dR * ((double)3 / 8));
                        }

                    }


                }
                else break;
               
            }
            int k = counter;

        }
    }
}
