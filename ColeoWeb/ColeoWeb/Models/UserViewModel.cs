using ColeoDataLayer.ModelColeo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ColeoWeb.Models
{
    public class UserViewModel
    {
        #region Properties

        //AspNetUser Model { get; set; }

        public string Id { get; set; }

        [DisplayName("Name")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Image")]
        public string Image { get; set; }

        [DisplayName("Role")]
        public string Role { get; set; }

        #endregion Properties

        //public void SetDataFromModel() 
        //{
        //    Model = AspNetUser.GetById(Id);

        //    UserName = Model.UserName;
        //    Email = Model.Email;
        //    Image = Model.Image;
        //}
    }
}