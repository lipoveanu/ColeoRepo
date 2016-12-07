using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ColeoWeb.Models
{
    public class ProjectStatusViewModel
    {
        public ProjectStatusViewModel()
        {
            Color = "#E8A13F";
        }

        #region Properties

        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Color")]
        public string Color { get; set; }

        #endregion Properties
    }
}