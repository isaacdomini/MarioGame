﻿using System;
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
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            int leftPos = 2, topPos = 15, width = 1600, height = 1020;
            Rectangle marioScreen = new Rectangle(leftPos, topPos, width, height);
            using (Bitmap bitmap = new Bitmap(marioScreen.Width, marioScreen.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, marioScreen.Size);
                }
                // lock the bitmaps bits
                Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);

                //get the address of the first line
                IntPtr ptr= bmpData.Scan0;

                //Declare an array to hold the bytes of the bitmap.
                //This code is specific to a bitmap with 32 bits per pixels - 1 byte for each of rgba
                int numBytes = bitmap.Width * bitmap.Height * 4;
                byte[] rgbValues = new byte[numBytes];

                // Copy the RGB Values into the array. 
                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, numBytes);

                //Give 1 out of every 24 pixels a full red value.
                for (int i = 2; i < rgbValues.Length; i += 4 * 24)
                {
                    rgbValues[i] = 255;
                }
                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numBytes);

                // Unlock the bits
                bitmap.UnlockBits(bmpData);
                bitmap.Save("test7.jpg", ImageFormat.Jpeg);
            }

            //Interpreter.AILoader("HardcodedAI.json");

            //Thread.Sleep(3000);
            //input.Keyboard.KeyDown(VirtualKeyCode.VK_D);
            //Thread.Sleep(2000);
            //input.Keyboard.KeyUp(VirtualKeyCode.VK_D);
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
