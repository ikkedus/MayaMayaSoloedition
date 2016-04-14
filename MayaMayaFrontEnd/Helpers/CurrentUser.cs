using System;
using System.Collections.Generic;
using System.Windows;
using MayaMayaCore.Models;
using MayaMayaCore.Services;

namespace MayaMayaFrontEnd.Helpers
{
    public static class CurrentUser
    {
        /// <summary>
        /// dit is private voor gemak anders werd het Currentuser.user.firstname ofzo :P
        /// </summary>
        private static UserModel user
        {
            get
            {
                return (UserModel)Application.Current.Properties["CurrentUser"];
            }
        }
        /// <summary>
        /// geeft je de gebruikersnaam van de huidige gebruiker
        /// </summary>
        public static string Username
        {
            get { return user.Username; }
        }
        /// <summary>
        /// geeft je de voornaam van de huidige gebruikerhjn   
        /// </summary>
        public static string Firstname
        {
            get { return user.Firstname; }
        }
        /// <summary>
        /// geeft je de achternaam van de huidige gebruiker
        /// </summary>
        public static string Lastname
        {
            get { return user.Lastname; }
        }
        /// <summary>
        /// geeft je de laatste login datum van de huidige gebruiker
        /// </summary>
        public static DateTime LastLogin
        {
            get { return user.LastLogin; }
        }
        /// <summary>
        /// geeft je de rollen van de huidige gebruiker
        /// </summary>
        public static List<string> Roles
        {
            get { return user.Roles; }
        }
        /// <summary>
        /// geeft je de id van de huidige gebruiker
        /// </summary>
        public static int Id
        {
            get { return (int)Application.Current.Properties["CurrentUserId"]; }
        }
        /// <summary>
        /// zet alle data van de gebruiker in de Applicatie Storage
        /// </summary>
        /// <param name="id">geef de id van de gebruiker</param>
        public static void SetCurrentUser(int id)
        {
            Application.Current.Properties["CurrentUserId"] = id;
            UserService us = new UserService();
            UserModel user = us.GetUser(id);
            Application.Current.Properties["CurrentUser"] = user;
        }
        /// <summary>
        /// maakt de CurrentUserLeeg
        /// </summary>
        public static void DestroyCurrentUser()
        {
            Application.Current.Properties["CurrentUser"] = new UserModel() {Roles = new List<string>()};
        }

    }


}
