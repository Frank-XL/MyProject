using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ClothingMall.Web.ViewModels
{
    public class UsersViewModel
    {
        [JsonProperty(PropertyName = "userId")]
        public int UserId { get; set; }
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "userPassword")]
        public string UserPassword { get; set; }
        [JsonProperty(PropertyName = "createTime")]
        public Nullable<System.DateTime> CreateTime { get; set; }
        [JsonProperty(PropertyName = "updateTime")]
        public Nullable<System.DateTime> UpdateTime { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}