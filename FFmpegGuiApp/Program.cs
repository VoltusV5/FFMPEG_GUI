using FFmpegWrapperLib;
using PresetManager;

namespace FFmpegGuiApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var builder = new FFmpegCommandBuilder
            {
                InputPath = "input.mp4",
                OutputPath = "output.mp4",
                Resolution = "1280:720"
            };

            string command = builder.BuildCommand();
            Console.WriteLine(command);
        }
    }
}
