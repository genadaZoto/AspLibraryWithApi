﻿using Library.Areas.Member.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.ModelTools
{
    public static class SessionUtils
    {
        public static bool IsConnected
        {
            get
            {
                if(HttpContext.Current.Session["IsConnected"] != null)
                {
                    return (bool)HttpContext.Current.Session["IsConnected"];
                }
                return false;
            }
            set
            {
                HttpContext.Current.Session["IsConnected"] = value;
            }
        }

        public static ProfileModel ConnectedUser
        {
            get
            {
                if (HttpContext.Current.Session["ConnectedUser"] != null)
                {
                    return (ProfileModel)HttpContext.Current.Session["ConnectedUser"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["ConnectedUser"] = value;
            }
        }

        public static string ErrorReservation
        {
            get
            {
                if(HttpContext.Current.Session["ErrorReservation"] != null)
                {
                    return (string)HttpContext.Current.Session["ErrorReservation"];
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session["ErrorReservation"] = value;
            }
        }
    }
}