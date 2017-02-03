using ColeoWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ColeoWeb.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public List<FileViewModel> Upload(IEnumerable<HttpPostedFileBase> fileUpload)
        {
            List<FileViewModel> result = new List<FileViewModel>();
            foreach (var file in fileUpload)
            {
                string fileName = string.Format("{0}{1}.{2}", 
                                                Path.GetFileNameWithoutExtension(file.FileName), 
                                                Guid.NewGuid().ToString(), 
                                                file.FileName.Split('.').Last());
                string UploadPath = "D:/01 COLEO/Images/";

                if (file.ContentLength == 0)
                    continue;

                if (file.ContentLength > 0)
                {
                    string path = Path.Combine(UploadPath, fileName);// Path.Combine(HttpContext.Request.MapPath(UploadPath), fileName);
                    string extension = Path.GetExtension(file.FileName);

                    try
                    {
                        file.SaveAs(path); 
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }

                    result.Add(new FileViewModel
                    {
                        LocalName = file.FileName,
                        Name = fileName,
                        Extension = file.ContentType
                    });
                }
            }

            return result;
        }
    }
}