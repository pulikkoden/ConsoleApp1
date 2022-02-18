using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var imgPath = Console.ReadLine();
                var bitmap = new Bitmap(imgPath);
                int count = 0;
                for (int i = 0; i < bitmap.Width; i++) {
                    Color pixHorizontalClr = bitmap.GetPixel(i,bitmap.Height/2); 

                    if (pixHorizontalClr.Name == "ff000000")//white
                    {
                        count++;
                        bool straightLine = true; 
                        int j, k;
                        while (pixHorizontalClr.Name != "ffffffff" && i < bitmap.Width)
                        {
                            if (straightLine) {
                                //check whether length of line is equal to the top and bottom
                                //find bottom half length of line                        
                                for (j = (bitmap.Height / 2) + 1; j < bitmap.Height; j++)
                                {
                                    Color pixVerticalColor = bitmap.GetPixel(i, j);
                                    if (pixVerticalColor.Name != "ff000000")//black
                                        break;
                                }

                                //find top half length of line                                
                                for (k = (bitmap.Height / 2) - 1; k > 0; k--)
                                {
                                    Color pixVerticalColor = bitmap.GetPixel(i, k);
                                    if (pixVerticalColor.Name != "ff000000")//black
                                        break;
                                }

                                if (Math.Abs((j - (bitmap.Height / 2) - ((bitmap.Height / 2) - k))) > 20) //20px is the threshhold to consider the line is equal in both top and bottom directions
                                {
                                    count--;
                                    straightLine = false;
                                }
                            }                            

                            pixHorizontalClr = bitmap.GetPixel(i, bitmap.Height / 2);
                            i++;
                        }

                    }
                }
                Console.Write("Number of lines in image is -> ");
                Console.WriteLine(count);
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
