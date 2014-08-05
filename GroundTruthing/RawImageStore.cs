using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using LadybugAPI;

namespace GroundTruthing
{
    class RawImageStore
    {
        /**
         * The PGR file location
         **/
        private string filename = "";

        /**
         * The PGR context for all ladybug interactions
         **/
        private int ladybugContext = -1;

        /**
         * The PGR context for all ladybug streamFile interactions
         **/
        private int streamLadybugContext = -1;

        /**
         * The number of images in out capture file
         **/
        private uint imageFileCount = 0;

        /**
         * The header informatino for when we have loaded a file;
         **/
        private LadybugStreamHeadInfo streamHeadInfo;

        /**
         * Constructor just sets the filename and waits for loading
         **/
        public RawImageStore(string filename)
        {
            this.filename = filename;
        }

        /**
         * Constructor just sets the filename and waits for loading
         **/
        public bool Open()
        {
            LadybugError error = Ladybug.CreateContext(out ladybugContext);

            handleError(error);

            LadybugError streamContextError = Ladybug.CreateStreamContext(out streamLadybugContext);

            if (!File.Exists(filename))
            {
                return false;
            }

            LadybugError streamFileError = Ladybug.InitializeStreamForReading(streamLadybugContext, filename, true);

            handleError(streamFileError);

            streamFileError = Ladybug.GetStreamHeader(streamLadybugContext, out streamHeadInfo, null);

            imageFileCount = streamHeadInfo.ulNumberOfImages;

            ReadImage(2);

            return true;

        }

        /**
         * Construct our image from index
         **/
        public Image ReadImage(uint index)
        {
            if (streamLadybugContext == -1)
            {
                return DefaultImage();
            }

            else
            {
                LadybugImage returnImage;

                LadybugError seekError = Ladybug.GoToImage(streamLadybugContext, index);
                handleError(seekError);

                LadybugError readError = Ladybug.ReadImageFromStream(streamLadybugContext, out returnImage);
                handleError(readError);

                unsafe
                {
                    byte[] bufferData = new byte[returnImage.uiDataSizeBytes];
                    Marshal.Copy((IntPtr)returnImage.pData, bufferData, 0, (int)returnImage.uiDataSizeBytes);
                    Stream bitmapStream = new MemoryStream(bufferData);

                    JpegBitmapDecoder bmpReturnImage = new JpegBitmapDecoder(bitmapStream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    BitmapSource bitmapSource = bmpReturnImage.Frames[0];

                    return DefaultImage();
                }
            }
        }

        /**
         * Just a plain image, default is red
         **/
        public static Image DefaultImage()
        {
            Bitmap bmp = new Bitmap(1024, 1024);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, 1024, 1024);
                graph.FillRectangle(Brushes.Red, ImageSize);
            }
            return bmp;
        }

        /**
         * Throw a message box on error
         **/
        public void handleError(LadybugError errorCode)
        {
            if (errorCode != LadybugError.LADYBUG_OK)
            {
                //Console.Out.WriteLine(Ladybug.ErrorToString(errorCode));
                MessageBox.Show(System.Runtime.InteropServices.Marshal.PtrToStringAnsi(Ladybug.ErrorToString(errorCode)));
            }
        }

    }
}
