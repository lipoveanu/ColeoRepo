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

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        public bool IsAssigned { get; set; }

        #endregion Properties

        #region Methods

        public void InitializeData()
        {
            AspNetUser user = AspNetUser.GetById(UserId);
            User = new UserViewModel { 
                UserName = user.UserName,
                Id = user.Id,
                Email = user.Email,
                Image = user.Image
            };
        }

        #endregion Methods
    }
}