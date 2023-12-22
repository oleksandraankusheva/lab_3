using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MirrorImage
{

    class Program
    {
        private static void FlipImageVertical(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            for (int y = 0; y < height / 2; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color temp = image.GetPixel(x, y);
                    image.SetPixel(x, y, image.GetPixel(x, height - 1 - y));
                    image.SetPixel(x, height - 1 - y, temp);
                }
            }
        }
        static void Main(string[] args)
        {
            MessageBox.Show("SomeMessage");
            
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (string fileName in files)
            {
                
                try
                {
                    Bitmap newImage = new Bitmap(fileName);

                    FlipImageVertical(newImage);

                    newImage.Save(Path.ChangeExtension(fileName, "-mirrored.gif"));
                }
                
                catch (Exception)
                {
                    Console.WriteLine(" Файл '{0}' не є графічним файлом", fileName);
                }
            }
            Console.ReadKey();
        }      
    }
}