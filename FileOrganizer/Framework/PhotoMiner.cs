namespace PhotoLibaryToolkit.Framework
{
    using System;
    using PFP.Imaging;

    class PhotoMiner : MediaMinerBase
    {
        public PhotoMiner(string path, bool scanSubfolders)
            : base(path, scanSubfolders)
        {}

        protected override string[] GetFolderSearchPatternsList()
        {
            return ImageInfo.GetImageExtensions();
        }

        protected override DateTime GetTakenDate(string file)
        {
            var takenDate = ImageInfo.GetTakenDate(file);
            return takenDate ?? base.GetTakenDate(file);
        }
    }
}
