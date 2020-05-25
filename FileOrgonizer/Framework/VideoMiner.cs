namespace PhotoLibaryToolkit.Framework
{
    using System;

    class VideoMiner : MediaMinerBase
    {
        public VideoMiner(string path, bool scanSubfolders)
            : base(path, scanSubfolders)
        {
        }

        protected override string[] GetFolderSearchPatternsList()
        {
            return VideoInfo.GetVideoExtensions();
        }

        protected override DateTime GetTakenDate(string filePath)
        {
            return VideoInfo.GetVideoFileTakenDate(filePath) ?? base.GetTakenDate(filePath);
        }
    }
}
