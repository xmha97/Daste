namespace PhotoLibaryToolkit.Framework
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;

    internal abstract class MediaMinerBase : IMediaMiner {
        private string m_path;
        private bool m_scanSubfolders;

        private int m_currentProgress;


        public MediaMinerBase(string path, bool scanSubfolders)
        {
            m_path = path;
            m_scanSubfolders = scanSubfolders;
        }

        public Dictionary<string, DateTime> GetMediaFilesList()
        {
            var searchOption = m_scanSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var result = new Dictionary<string, DateTime>();

            foreach (var searchPattern in GetFolderSearchPatternsList())
            {
                var filesList = Directory.GetFiles(m_path, searchPattern, searchOption);
                m_currentProgress = 0;

                Dictionary<string, DateTime> interimResult = filesList.AsParallel()
                    .Select(p => new { File = p, TakenDate = GetTakenDateEntry(p) })
                    .Where(p => p.TakenDate != null).ToDictionary(p => p.File, p => p.TakenDate.Value);

                result = result.Concat(interimResult).ToDictionary(p => p.Key, p => p.Value);
            }

            return result;
        }

        protected abstract string[] GetFolderSearchPatternsList();

        private DateTime? GetTakenDateEntry(string filePath)
        {
            try
            {
                DateTime result = GetTakenDate(filePath);

                int currentValue = Interlocked.Increment(ref m_currentProgress);
                if (currentValue % 50 == 0)
                {
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        protected virtual DateTime GetTakenDate(string filePath)
        {
            DateTime[] dates = new[]
            {
                File.GetCreationTime(filePath), 
                File.GetLastWriteTime(filePath)
            };

            return dates.Min();
        }
    }
}