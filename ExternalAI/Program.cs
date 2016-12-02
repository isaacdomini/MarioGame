using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;

namespace ExternalAI
{
    public static class Program
    {
        static InputSimulator input;
        static int defaultPressedDuration = 500;
        public static IDictionary<string, VirtualKeyCode> keyMap = new Dictionary<string, VirtualKeyCode>()
        {
            { "left", VirtualKeyCode.VK_A},
            { "right", VirtualKeyCode.VK_D},
            { "up", VirtualKeyCode.VK_W},
            { "down", VirtualKeyCode.VK_S}
        };
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            input = new InputSimulator();
            //Thread.Sleep(1000);
            //input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            //Thread.Sleep(1000);
            //input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
            //ScreenCapture sc = new ScreenCapture();
            //// capture entire screen, and save it to a file
            //Image img = sc.CaptureScreen();
            //img.Save("C:\\Users\\John\\Source\\Repos\\MarioLopezTheSecondOne\\MarioLopez\\ExternalAI\\img.gif");
            processScreen();

            //Interpreter.AILoader("HardcodedAI.json");

            //Thread.Sleep(3000);
            //input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            //Thread.Sleep(2000);
            //input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
        }
        public static void processScreen()
        {
            int version = 14;
            Bitmap bitmap = getBitmapFromScreen();
            // lock the bitmaps bits
            bitmap = processBitmap(bitmap, makeRed);// makeBitmapRed(bitmap);
            bitmap.Save("test_" + version + ".jpg", ImageFormat.Jpeg);
            Console.WriteLine(bitmap.Size);
            //Bitmap brightnessMatrix = processBitmap(bitmap, getBrightnessMatrix, false);
            Bitmap grayMap = MakeGrayscale3(bitmap);
            
            //processBitmap(bitmap, printRGBAs);
            //processBitmap(grayMap, printRGBAs);
            Console.WriteLine(grayMap.Size);
            grayMap.Save("test_" + version + "_gray.jpg", ImageFormat.Jpeg);
            //brightnessMatrix.Save("test_" + version + "_bmp.bmp");
        }

        public static Bitmap processBitmap(Bitmap bitmap, Func<Byte[], Byte[]> action, bool rgba = true)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            BitmapData bmpData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //get the address of the first line
            IntPtr ptr= bmpData.Scan0;

            //Declare an array to hold the bytes of the bitmap.
            //This code is specific to a bitmap with 32 bits per pixels - 1 byte for each of rgba
            int numBytes = bitmap.Width * bitmap.Height * 4;
            byte[] rgbValues = new byte[numBytes];

            // Copy the RGB Values into the array. 
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, numBytes);
            //modify/use the rgbValues
            rgbValues = action(rgbValues);
            numBytes = rgba ? numBytes / 4 : numBytes;
            // Copy the RGB values back to the bitmap
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numBytes);

            // Unlock the bits
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }

        static Bitmap getBitmapFromScreen()
        {
            int leftPos = 2, topPos = 15, width = 1600, height = 1020;
            Rectangle marioScreen = new Rectangle(leftPos, topPos, width, height);
            Bitmap bitmap = new Bitmap(marioScreen.Width, marioScreen.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(Point.Empty, Point.Empty, marioScreen.Size);
            return bitmap;
            
        }
            //0 = blue; 1 = green, 2 = red, 3 = a
        static Func<byte[], byte[]> makeRed = rgbValues =>
        {
            for (int i = 2; i < rgbValues.Length; i += 4 * 24)
            {
                rgbValues[i] = 255;
            }
            return rgbValues;
        };
        static Func<byte[], byte[]> getBrightnessMatrix = rgbValues =>
        {
            byte[] brightnessMatrix = new byte[rgbValues.Length / 4];
            for (int i = 0; i +4 < rgbValues.Length; i += 4 * 1)
            {
                //Y = .2126 * R^gamma + .7152 * G^gamma + .0722 * B^gamma
                brightnessMatrix[i] = (byte)(((float)rgbValues[i]) * .0722 / 255 + ((float)rgbValues[i + 1]) * .7152 / 255+ ((float)rgbValues[i + 2]) * .2126/ 255); //TODO: Learn linear algebra so that I don't have to manually loop through each element of the matrix. There's gotta be some better way.
            }
            return brightnessMatrix;
        };
        static Action<byte[]> printRGBAs = rgbValues =>
        {
            Console.WriteLine("rgb vals length is " + rgbValues.Length);
            //for (int i = 2; i < rgbValues.Length; i += 4 * 1)
            //    {
            //    Console.WriteLine(i + ": blue: " + rgbValues[i]);
            //    Console.WriteLine(i + ": green: " + rgbValues[i+1]);
            //    Console.WriteLine(i + ": red: " + rgbValues[i+2]);
            //    Console.WriteLine(i + ": alpha: " + rgbValues[i+3]);
            //    }
        };
        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        public static void press(List<VirtualKeyCode> keys, int millisecondsPressed)
        {
            keys.ForEach(k => input.Keyboard.KeyDown(k));
            Thread.Sleep(millisecondsPressed);
            keys.ForEach(k => input.Keyboard.KeyUp(k));
        }
        static void press(VirtualKeyCode k, int millisecondsPressed)
        {
            input.Keyboard.KeyDown(k);
            Thread.Sleep(millisecondsPressed);
            input.Keyboard.KeyUp(k); 
        }
        static void press(VirtualKeyCode k)
        {
            press(k, defaultPressedDuration);
        }
        public static void left(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_A, millisecondsPressed);
        }
        public static void left(VirtualKeyCode k)
        {
            left(defaultPressedDuration);
        }
        public static void right(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_D, millisecondsPressed);
        }
        public static void right(VirtualKeyCode k)
        {
            right(defaultPressedDuration);
        }
        public static void up(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_W, millisecondsPressed);
        }
        public static void up(VirtualKeyCode k)
        {
            up(defaultPressedDuration);
        }
        public static void down(int millisecondsPressed)
        {
            press(VirtualKeyCode.VK_S, millisecondsPressed);
        }
        public static void down(VirtualKeyCode k)
        {
            down(defaultPressedDuration);
        }
    }
}
