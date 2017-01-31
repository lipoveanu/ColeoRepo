using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColeoWeb
{
    public static class ColeoHelper 
    {
        #region Set/get files in session 

        public static void SetFiles(this HttpSessionStateBase session, List<FileViewModel> files)
        {
            session["files"] = files;
        }

        public static List<FileViewModel> GetFiles(this HttpSessionStateBase session)
        {
            return (List<FileViewModel>)session["files"];
        }

        #endregion 
    }
}