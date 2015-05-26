using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ColorCoded
{
    public partial class UserInterface : Form
    {
        private Dictionary<char, string> _getString;
        private Dictionary<string, char> _getChar;
        private Dictionary<string, byte> _getByte;
        private Dictionary<byte, string> _getStringFromByte;
        public UserInterface()
        {
            InitializeComponent();
            //InitDictionary();
            Test();
        }

        private void uxReadImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ReadImage(uxOpenFileDialog.FileName);
                        MessageBox.Show("File Read.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred: " + ex.ToString());
            }

        }
        private string ReadImage(string filename)
        {
            using (FileStream fs = new FileStream(uxSaveFileDialog.FileName, FileMode.Create, FileAccess.Write))
            {
                StringBuilder sb = new StringBuilder();

                Bitmap myBitmap = new Bitmap(filename);
                for (int y = 0; y < myBitmap.Height; y++)
                {
                    for (int x = 0; x < myBitmap.Width; x++)
                    {

                        // Get the color of a pixel within myBitmap.
                        Color pixelColor = myBitmap.GetPixel(x, y);
                        string pixelColorStringValue =
                            pixelColor.B.ToString("D3") + " " +
                            pixelColor.G.ToString("D3") + " " +
                            pixelColor.R.ToString("D3");
                        if (pixelColorStringValue == "255 255 255")
                        {
                            myBitmap.Dispose();
                            return sb.ToString();
                        }
                        fs.WriteByte(_getByte[pixelColorStringValue]);
                    }
                }

                throw new ArgumentOutOfRangeException("Text is longer than encoding");
            }
        }
        private void WriteImage(string filename)
        {
            using (FileStream fs = new FileStream(uxOpenFileDialog.FileName, FileMode.Open, FileAccess.Read))
            {

                int textLength = (int)fs.Length;

                int width = (int)Math.Ceiling(Math.Sqrt(textLength));

                while ((width * 3) % 4 != 0)
                {
                    width++;
                }

                int height = width;
                /* Create an array of bytes consisting of the area's worth of pixels
                 * with 3 bytes of data each.
                 */
                byte[] pixels = new byte[width * height * 3];

                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = 255;
                }



                int count = 0;
                for (int i = 0; i < textLength * 3; i++)
                {
                    int[] arr = GetRGB((byte)fs.ReadByte());
                    pixels[i] = (byte)arr[0];
                    i++;
                    pixels[i] = (byte)arr[1];
                    i++;
                    pixels[i] = (byte)arr[2];
                    count++;
                }

                Bitmap bmp = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb,
                                        System.Runtime.InteropServices.GCHandle.Alloc(pixels, System.Runtime.InteropServices.GCHandleType.Pinned).AddrOfPinnedObject());


                bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                bmp.Dispose();
            }
        }

        private int[] GetRGB(byte c)
        {
            string RGB;
            if (_getStringFromByte.TryGetValue(c, out RGB))
            {
                string[] arr = RGB.Split(' ');
                int[] intArr = new int[3];

                for (int i = 0; i < arr.Length; i++)
                {
                    intArr[i] = Convert.ToInt16(arr[i]);
                }

                return intArr;
            }
            else
            {
                throw new ArgumentException("Character \"" + c.ToString() + "\" cannot be encoded");
            }

        }

        private void uxWriteMessage_Click(object sender, EventArgs e)
        {
            // try
            // {
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    WriteImage(uxSaveFileDialog.FileName);
                    MessageBox.Show("File Written.");
                }
            }
            // }
            //catch (Exception ex)
            //{
            //  MessageBox.Show("Error Occurred: " + ex.ToString());
            //}

        }

        private void Test()
        {
            //increase by 36
            //7 times a loop
            _getByte = new Dictionary<string, byte>();
            _getStringFromByte = new Dictionary<byte, string>();

            byte[] byteArray = new byte[256];

            Random rnd = new Random(256);

            for (int i = 0; i < 256; i++)
            {
                byteArray[i] = (byte)i;
            }

            for (int i = 0; i < byteArray.Length * 3; i++)
            {
                int a = rnd.Next(byteArray.Length);
                int x = rnd.Next(byteArray.Length);

                byte temp = byteArray[a];
                byteArray[a] = byteArray[x];
                byteArray[x] = temp;

            }

            int r;
            int g;
            int b;
            int count = 0;
            for (int i = 0; i < 7; i++)
            {
                r = i * 45;
                for (int j = 0; j < 7; j++)
                {
                    g = j * 36;
                    for (int k = 0; k < 7; k++)
                    {
                        b = k * 36;
                        if (count < 256)
                        {
                            string rgb = r.ToString("D3") + " " + g.ToString("D3") + " " + b.ToString("D3");
                            _getByte.Add(rgb, byteArray[count]);
                            _getStringFromByte.Add(byteArray[count], rgb);
                        }
                        count++;
                    }
                }
            }
        }
    }
}
