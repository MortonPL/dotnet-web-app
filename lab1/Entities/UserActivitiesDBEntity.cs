using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NTR.Entities
{
    /// <summary>
    /// A class handling IO of each user's monthly activities database.
    /// </summary>
    public class UserActivitiesDBEntity
    {
        /// <summary>
        /// Load the the user's monthly activities from the database.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="date">Year and month, in yyyy-MM format.</param>
        /// <returns>User's month object.</returns>
        public static UserMonth Load(string name, string date)
        {
            UserMonth userMonth;
            try
            {
                var json = System.IO.File.ReadAllText("db/" + name + "-" + date + ".json");
                try
                {
                    userMonth = System.Text.Json.JsonSerializer.Deserialize<UserMonth>(json);
                }
                catch (System.Text.Json.JsonException)
                {
                    userMonth = new UserMonth(true);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                return new UserMonth(true);
            }

            return userMonth;
        }

        /// <summary>
        /// Save a user's monthly activity to the database.
        /// </summary>
        /// <param name="name">Name of the user.</param>
        /// <param name="date">Year and month, in yyyy-MM format.</param>
        /// <param name="activities">User's monthly activities object.</param>
        public static void Save(string name, string date, UserMonth activities)
        {
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { IncludeFields = true, WriteIndented = true };
            var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(activities, jsonOptions);
            System.IO.File.WriteAllBytes("db/" + name + "-" + date + ".json", bytes);
        }
    }
}
