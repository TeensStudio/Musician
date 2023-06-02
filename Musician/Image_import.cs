using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;

namespace Musician
{
    public class Image_import
    {
        private static string file_name = "";

        
        public static Color[] Import()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Файлы png|*.png|Файлы jpg|*.jpg";

            if (file.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(file.FileName);

                Color[] colors = new Color[image.Width];

                for (int i = 0, x = 0; (i < image.Width && x < image.Width); i++, x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        colors[i] = image.GetPixel(x, y);
                    }
                }

                file_name = file.FileName;

                return colors;
            }

            else{
                return null;
            }
        }

        public static string Get_file_name()
        {
            return file_name;
        }
    }
}