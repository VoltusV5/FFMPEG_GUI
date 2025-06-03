namespace FFmpegWrapperLib
{
    public class FFmpegCommandBuilder
    {
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public string Resolution { get; set; }

        public string BuildCommand()
        {
            return $"ffmpeg -i \"{InputPath}\" -vf scale={Resolution} \"{OutputPath}\"";
        }
    }
}
