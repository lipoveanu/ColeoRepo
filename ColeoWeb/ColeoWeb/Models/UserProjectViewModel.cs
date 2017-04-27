using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColeoWeb.Models
{
    public class UserProjectViewModel
    {
        #region Properties

        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        public bool IsAssigned { get; set; }

        #endregion Properties

        #region Methods

        #endregion Methods
    }
}