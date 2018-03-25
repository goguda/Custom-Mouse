using System;
using System.Drawing;

namespace CustomMouseController
{
    [Serializable]
    public class ProgramInfo
    {
        private string name;
        private string path;

        [NonSerialized]
        private Icon icon;
        [NonSerialized]
        private Icon grayscaleIcon;

        public ProgramInfo(string name, string path, Icon icon)
        {
            this.name = name;
            this.path = path;
            this.icon = icon;
            this.grayscaleIcon = Icon.FromHandle(ConvertBitmapToGrayscale(icon.ToBitmap()).GetHicon());
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }

        public Icon Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                grayscaleIcon = Icon.FromHandle(ConvertBitmapToGrayscale(value.ToBitmap()).GetHicon());
            }
        }

        public Icon GrayscaleIcon
        {
            get
            {
                return grayscaleIcon;
            }
        }

        private Bitmap ConvertBitmapToGrayscale(Bitmap toConvert)
        {
            Bitmap image = (Bitmap)toConvert.Clone();

            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColour = image.GetPixel(i, j);

                    if (pixelColour != Color.FromArgb(0, 0, 0, 0) && pixelColour != Color.FromArgb(0, 255, 255, 255))
                    {
                        byte grayPixel = (byte)(.21 * pixelColour.R + .71 * pixelColour.G + .071 * pixelColour.B);
                        image.SetPixel(i, j, Color.FromArgb(pixelColour.A, grayPixel, grayPixel, grayPixel));
                    }
                    else
                    {
                        image.SetPixel(i, j, Color.Transparent);
                    }
                }
            }
            return image;
        }
    }
}
