/*
 * File: ProgramInfo.cs
 * Contains: ProgramInfo class
 * 
 * This class is used to store information about a program
 * that is assigned to a button such as the program's name,
 * path, and icon. It is serializable so its state can be 
 * saved and restored with the closing and opening of the
 * application.
 * 
 * Author: David Goguen
 * Original release: March 26, 2018
 * 
 * Last updated: March 26, 2018
 * 
 */

using System;
using System.Drawing;

namespace CustomMouseController
{
    [Serializable]
    public class ProgramInfo
    {
        /* stores the name of the program */
        private string name;

        /* stores the path of the program executable */
        private string path;

        /* stores the program's icon */
        /* is not serialized since icons do not serialize well */
        [NonSerialized]
        private Icon icon;

        /* stores a grayscale version of the program's icon */
        /* is not serialized since icons do not serialize well */
        [NonSerialized]
        private Icon grayscaleIcon;

        /*
         * Main constructor that takes the program's name, path,
         * and icon as arguments. It also creates a grayscale icon
         * from the passed icon and saves it in the grayscaleIcon
         * reference variable.
         */
        public ProgramInfo(string name, string path, Icon icon)
        {
            this.name = name;
            this.path = path;
            this.icon = icon;
            this.grayscaleIcon = Icon.FromHandle(ConvertBitmapToGrayscale(icon.ToBitmap()).GetHicon());
        }

        /*
         * Getter and setter for the program name.
         */
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

        /*
         * Getter and setter for the program executable path.
         */
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

        /*
         * Getter and setter for the program's icon. A grayscale
         * version is automatically created whenever this is changed.
         */
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

        /*
         * Getter for the grayscale version of the icon. This is
         * read-only and is automatically created whenever a new
         * icon is assigned.
         */
        public Icon GrayscaleIcon
        {
            get
            {
                return grayscaleIcon;
            }
        }

        /*
         * Converts a colour bitmap passed as an argument to
         * grayscale and returns the grayscale version of the
         * bitmap. Also conserves transparency if present in
         * the original bitmap.
         */
        private Bitmap ConvertBitmapToGrayscale(Bitmap toConvert)
        {
            Bitmap image = (Bitmap)toConvert.Clone();

            // convert each pixel of the bitmap to grayscale
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    Color pixelColour = image.GetPixel(i, j);

                    // do not convert transparent pixels to grayscale and instead set them as transparent
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
