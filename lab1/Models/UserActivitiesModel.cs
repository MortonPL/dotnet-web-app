using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

using NTR.Entities;

namespace NTR.Models
{
    /// <summary>
    /// A model for user activities view.
    /// </summary>
    public class UserActivitiesModel
    {
        /// <summary>Date entered by the user.</summary>
        public string Date;

        /// <summary>Logged user's name.</summary>
        public string User;

        /// <summary>User's monthly report object.</summary>
        public UserMonth UserMonth;

        /// <summary>Is the activity view per day or per month?</summary>
        public bool IsMonthlyView = false;

        public UserActivitiesModel(){
            this.Date = DateTime.Today.ToString("yyyy-MM-dd");
        }
        
        /// <summary>Extract the saved date.</summary>
        /// <returns>Saved date as string in yyyy-MM format</returns>
        public string GetMonth()
        {
            return this.Date.Remove(this.Date.Length - 3);
        }

        /// <summary>Get set date's activties for saved user.</summary>
        /// <returns>Filtered list of user activities.</returns>
        public IEnumerable<UserActivity> GetActivities()
        {
            IEnumerable<UserActivity> list = this.IsMonthlyView
                ? this.UserMonth.entries.Where(e => e.date.Remove(e.date.Length - 3) == this.Date.Remove(this.Date.Length - 3))
                : this.UserMonth.entries.Where(e => e.date == this.Date);
            return list.OrderBy(e => e.date).ToList();
        }

        /// <summary>Checks if the current user can delete the UA and deletes it.</summary>
        /// <param name="code">Code of the project.</param>
        /// <param name="date">Date of the project.</param>
        /// <param name="subcode">Subcode of the project.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public bool DeleteUserActivity(string code, string date, string subcode)
        {
            foreach(UserActivity UA in this.UserMonth.entries)
            {
                if (UA.code == code && UA.date == date && UA.IsEqualSubactivity(subcode))
                {
                    this.UserMonth.entries.Remove(UA);
                    return true;
                }
            }
            return false;
        }

        /// <summary>Freezes the month.</summary>
        public void LockUserActivity()
        {
            this.UserMonth.frozen = true;
        }

        /// <summary>Load user activities from the database.</summary>
        public void LoadFromDB()
        {
            this.UserMonth = Entities.UserActivitiesDBEntity.Load(this.User, this.GetMonth());
        }

        /// <summary>Save user activities to the database.</summary>
        public void SaveToDB()
        {
            Entities.UserActivitiesDBEntity.Save(this.User, this.GetMonth(), this.UserMonth);
        }
    }
}
