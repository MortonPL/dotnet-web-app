using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NTR.Entities
{
    /// <summary>
    /// A single user's monthly activity summary.
    /// </summary>
    public class UserMonth
    {
        /// <summary>Is this month complete?</summary>
        public bool frozen { get; set; }

        /// <summary>Array of activity entries.</summary>
        public List<UserActivity> entries { get; set; }

        /// <summary>Array of activity entries approved by a manager.</summary>
        public List<ApprovedUserActivity> accepted { get; set; }

        /// <summary>Has this entry been correctly read?</summary>
        [JsonIgnore]
        public bool invalid = false;
        
        public UserMonth(){
            this.entries = new List<UserActivity>();
            this.accepted = new List<ApprovedUserActivity>();
        }

        public UserMonth(bool invalid){
            this.invalid = invalid;
            this.entries = new List<UserActivity>();
            this.accepted = new List<ApprovedUserActivity>();
        }
    }
}
