using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColeoWeb
{
    public static class ColeoHelper
    {
        public class OrderItem
        {
            public int Key { get; set; }
            public int Value { get; set; }
        }

        private class FileSession
        {
            public int Destination { get; set; }
            public List<FileViewModel> Files { get; set; }
        }

        public enum FileType
        {
            None = 0,
            Project = 1,
            Issue = 2,
            Note = 3
        }

        #region Set/get files in session

        public static void SetFiles(this HttpSessionStateBase session, List<FileViewModel> files, int type)
        {
            FileSession file = new FileSession()
            {
                Destination = type,
                Files = files
            };

            if (session["files"] == null)
            {
                session["files"] = new List<FileSession>();
            }
            ((List<FileSession>)session["files"]).Add(file);
        }

        public static List<FileViewModel> GetFiles(this HttpSessionStateBase session, int type)
        {
            List<FileViewModel> result = new List<FileViewModel>();
            List<FileSession> sessionFiles = (List<FileSession>)session["files"];
            if (sessionFiles != null)
            {
                sessionFiles.Where(d => d.Destination == type).ToList().ForEach(x => x.Files.ForEach(y => result.Add(y)));
            }
            
            return result;
        }

        public static void CleanFiles(this HttpSessionStateBase session,int type)
        {
            List<FileSession> sessionFiles = (List<FileSession>)session["files"];
            if (sessionFiles != null)
            {
                sessionFiles.RemoveAll(d => d.Destination == type);
            }
        }

        #endregion
    }
}