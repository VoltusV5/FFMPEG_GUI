namespace FFmpegWrapperLib
{
    public class FFmpegCommandBuilder
    {
        public string InputPath { get; set; } = string.Empty;
        public string OutputPath { get; set; } = string.Empty;
        public string Resolution { get; set; } = string.Empty;

        public string BuildCommand()
        {
            return $"ffmpeg -i \"{InputPath}\" -vf scale={Resolution} \"{OutputPath}\"";
        }
    }
}
