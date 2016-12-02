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
            bool quit = false;
            while (!quit)
            {

                List<Object> objectsOnScreen = getListOfObjectsFromScreen();
                DetermineAndMakeNextMove(objectsOnScreen);
                //if detect certain state - e.g. AI hasn't improved in like 1 hour, quit game
                quit = true; //for now quit automatically after one detection of the screen
            }
            

            //Interpreter.AILoader("HardcodedAI.json");

            //Thread.Sleep(3000);
            //input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            //Thread.Sleep(2000);
            //input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
        }
        public static void DetermineAndMakeNextMove(List<Object> objects) { }
        public static List<Object> getListOfObjectsFromScreen()
        {
            int version = 14;
            Bitmap bitmap = getBitmapFromScreen();
                bitmap = processBitmap(bitmap, makeRed);// makeBitmapRed(bitmap);
                bitmap.Save("test_" + version + ".jpg", ImageFormat.Jpeg);
                Console.WriteLine(bitmap.Size);
                Bitmap grayMap = MakeGrayscale3(bitmap);
                grayMap.Save("test_" + version + "_gray.jpg", ImageFormat.Jpeg);
            
            //processBitmap(bitmap, printRGBAs);
            //processBitmap(grayMap, printRGBAs);
            //Bitmap brightnessMatrix = processBitmap(bitmap, getBrightnessMatrix, false);

            Byte[] brightnessMatrix = getBrightnessMatrix(bitmap);
            //Console.WriteLine("brightnessMatrix");

            //Console.WriteLine(brightnessMatrix); 
            //for (var i = 0; i < brightnessMatrix.Length; i++)
            //{
            //    Console.WriteLine(brightnessMatrix[i]);
            //}
            Byte[] edges = getEdges(brightnessMatrix, bitmap.Width, bitmap.Height);
            List<GameObject> gameObjects = getObjects(edges);
            //brightnessMatrix.Save("test_" + version + "_bmp.bmp");

            List<Object> objects = new List<Object>();
            return objects;
        }

        public static Bitmap processBitmap(Bitmap bitmap, Func<Byte[], Byte[]> action, int bytesPerOutPixel = 4)
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
            byte[] outBytes = action(rgbValues);
            // Copy the RGB values back to the bitmap
            int numOutBytes = numBytes * bytesPerOutPixel / 4;
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numOutBytes);

            // Unlock the bits
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        public static byte[] getBrightnessMatrix(Bitmap rgbaMatrix)
        {
            Rectangle rect = new Rectangle(0, 0, rgbaMatrix.Width, rgbaMatrix.Height);
            BitmapData bmpData = rgbaMatrix.LockBits(rect, ImageLockMode.ReadWrite, rgbaMatrix.PixelFormat);

            //get the address of the first line
            IntPtr ptr= bmpData.Scan0;

            //Declare an array to hold the bytes of the rgbaMatrix.
            //This code is specific to a rgbaMatrix with 32 bits per pixels - 1 byte for each of rgba
            int numBytes = rgbaMatrix.Width * rgbaMatrix.Height * 4;
            byte[] rgbValues = new byte[numBytes];

            // Copy the RGB Values into the array. 
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, numBytes);
            //modify/use the rgbValues
            byte[] brightnessMatrix = new byte[rgbValues.Length / 4];
            for (int i = 0; i < brightnessMatrix.Length; i += 1)
            {
                //Y = .2126 * R^gamma + .7152 * G^gamma + .0722 * B^gamma
                brightnessMatrix[i] = (byte)(((float)rgbValues[i]) * .0722  + ((float)rgbValues[i + 1]) * .7152 + ((float)rgbValues[i + 2]) * .2126 ); //TODO: Learn linear algebra so that I don't have to manually loop through each element of the matrix. There's gotta be some better way.
            }
            
            // Copy the RGB values back to the rgbaMatrix
            int numOutBytes = numBytes / 4;
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numOutBytes);

            // Unlock the bits
            rgbaMatrix.UnlockBits(bmpData);
            //return the byte matrix
            return brightnessMatrix;
        }
        //edge detection algorithm
        public static byte[] getEdges(Byte[] brightnessMatrix, int width, int height) {
            //convolve the signal matrix using a 3x3 Gaussian kernel - per gimp https://docs.gimp.org/en/plug-in-convmatrix.html
            int[,] kernel = new int[,] { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
            int offset = kernel.Length / 2;
            Byte[] edgeMatrix = new Byte[brightnessMatrix.Length];
            for (int i = 1; i < width -1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    for (int k = 0; k < kernel.Length; k++)
                    {
                        for (int l = 0; l < kernel.Length; l++)
                        {
                            //edgeMatrix[width * i + j] += brightnessMatrix[width * (i + (k - offset)) + (j + (l - offset))];
                        }
                    }

                }
            }
            return edgeMatrix;
        }
        public static List<GameObject> getObjects(Byte[] edges) {
            return new List<GameObject>();
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
        static Func<byte[], byte[]> printVal = brightnessVals =>
        {
            for (int i = 0; i  < brightnessVals.Length; i += 1)
            {
                Console.WriteLine(i + ": " + brightnessVals[i]);
            }
            return brightnessVals;
        };
        //static Func<byte[], byte[]> getBrightnessMatrix = rgbValues =>
        //{
        //    byte[] brightnessMatrix = new byte[rgbValues.Length / 4];
        //    for (int i = 0; i +4 < rgbValues.Length; i += 4 * 1)
        //    {
        //        //Y = .2126 * R^gamma + .7152 * G^gamma + .0722 * B^gamma
        //        brightnessMatrix[i] = (byte)(((float)rgbValues[i]) * .0722 / 255 + ((float)rgbValues[i + 1]) * .7152 / 255+ ((float)rgbValues[i + 2]) * .2126/ 255); //TODO: Learn linear algebra so that I don't have to manually loop through each element of the matrix. There's gotta be some better way.
        //    }
        //    return brightnessMatrix;
        //};
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
