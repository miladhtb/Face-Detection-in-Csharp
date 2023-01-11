using System;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace FaceDetection
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat image = CvInvoke.Imread("image.jpg", ImreadModes.Color);

            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            CascadeClassifier faceClassifier = new CascadeClassifier("haarcascade_frontalface_default.xml");

            Rectangle[] faces = faceClassifier.DetectMultiScale(grayImage);

            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new MCvScalar(0, 255, 0));
            }

            image.Save("detected_faces.jpg");
        }
    }
}
