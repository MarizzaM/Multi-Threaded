using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDelegates
{
    class Program
    {
        public class VideoEncoderEventArgs : EventArgs
        {
            public string VideoName { get; set; }
            public int timeOfVideo { get; set; }
        }

        //public delegate void Func_Void_Arg_String(string s);

        static void SendEmailAfterEncoding(object sender, VideoEncoderEventArgs e)
        {
            Console.WriteLine($"Email: encoded by {sender}...");
            Console.WriteLine($"Email Header: Video Body: {e.VideoName} successfully encoded");
            Console.WriteLine($"Email Footer: Time of vidio: {e.timeOfVideo}");
        }

        static void SendSmsAfterEncoding(object sender, VideoEncoderEventArgs e)
        {
            Console.WriteLine($"SMS: encoded by {sender}...");
            Console.WriteLine($"SMS: -- Body: {e.VideoName} successfully encoded --");
            Console.WriteLine($"SMS: -- Footer: Time of vidio: {e.timeOfVideo}");
        }

        static void uploadTheVideoIntoTheCloud(object sender, VideoEncoderEventArgs e)
        {
            Console.WriteLine($"Encoded by {sender}...");
            Console.WriteLine($"Body: {e.VideoName} successfully encoded --");
            Console.WriteLine($"Footer: Time of vidio: {e.timeOfVideo}");
        }

        //private static Action<object, VideoEncoderEventArgs> invocationMethodsList;
        private static event EventHandler<VideoEncoderEventArgs> invocationMethodsList;

        private static void MpgVideoEncoding(string videoName, int timeOfVideo)
        {
            Console.WriteLine($"Encoding video {videoName}");

            Thread.Sleep(3000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("Mpeg encoder",
                    new VideoEncoderEventArgs { VideoName = videoName, timeOfVideo = timeOfVideo }); // fire all registered methods
            }

        }

        private static void Mp4VideoEncoding(string videoName, int timeOfVideo)
        {
            Console.WriteLine($"Encoding video {videoName}");
            Thread.Sleep(3000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("Mp4 encoder",
                    new VideoEncoderEventArgs { VideoName = videoName, timeOfVideo = timeOfVideo });// fire all registered methods
            }

        }

        static void Main(string[] args)
        {
            // +=

            invocationMethodsList += SendEmailAfterEncoding;
            invocationMethodsList += SendSmsAfterEncoding;
            invocationMethodsList += uploadTheVideoIntoTheCloud;
            Mp4VideoEncoding("Batman movie...", 95);

            invocationMethodsList -= SendEmailAfterEncoding;
            // this could only be done within the class
            // which holds the delegate as member
            invocationMethodsList = null;
            invocationMethodsList += uploadTheVideoIntoTheCloud;
            // invocationMethodsList.Invoke(null, new VideoEncoderEventArgs { VideoName = "bla bla bla)" });
            MpgVideoEncoding("Superman movie...", 120);

        }
    }
}
