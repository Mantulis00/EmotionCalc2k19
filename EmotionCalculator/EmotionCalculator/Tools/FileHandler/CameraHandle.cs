using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EmotionCalculator.EmotionCalculator.Tools.FileHandler
{
    class CameraHandle
    {
        private VideoCaptureDevice camera;
        private FilterInfoCollection cameraHW;
        private PictureBox pic;

        public bool cameraIsRoling { get; set; }

        public CameraHandle(PictureBox pic)
        {
            cameraHW = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            camera = new VideoCaptureDevice(cameraHW[0].MonikerString);
            camera.NewFrame += new NewFrameEventHandler(NewFrame);


            this.pic = pic;
            cameraIsRoling = false;
        }

        public void Start()
        {
            if (!cameraIsRoling)
            {
                camera.Start();
                cameraIsRoling = true;
            }
            else
            {
                //
            }

        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pic.Image = (Image)eventArgs.Frame.Clone();
        }


        public void Stop()
        {
            if (cameraIsRoling)
            {
                camera.Stop();
                cameraIsRoling = false;

                pic.Image = null;
            }
            else
            {
                //
            }

        }

    }
}
