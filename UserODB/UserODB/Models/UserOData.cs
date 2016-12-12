/*
 NAME: ADEEL KHILJI
 ASSIGNMENT: -CREATE MVC WITH ODATA,
             -USE ODATA QUERIES WITHIN THE ADDRESS LINE TO DEMONSTRATE HOW IT WORKS.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserODB.Models
{
    public class UserOData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}