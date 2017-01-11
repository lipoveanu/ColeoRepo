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

        UserProject Model { get; set; }

        public int? Id { get; set; }

        public int UserId { get; set; }
        public int ProjectId { get; set; }

        //public List<UserViewModel> AllUsers { get; set; }

        //public List<UserViewModel> AttachedUsers { get; set; }

        #endregion Properties

        #region Methods

        public void InitializeData()
        {
            
        }

        #endregion Methods
    }
}