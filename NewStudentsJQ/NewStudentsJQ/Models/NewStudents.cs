/*
 NAME: ADEEL KHILJI
 ASSIGNMENT: -CREATE CODE FIRST MVC WITH ENTITY FRAMEWORK, 
             -USE CONSOLE TO ENABLE DATA MIGRATIONS,
             -USE JQUERY TO MAKE THE DISPLAY MORE READABLE,
 NOTE: IF THE DB DOES NOT WORK, JUST GO TO THE CONSOLE AND WRITE DOWN THE FOLLOWING:
             -"enable-migrations"
             -"add-migration initial" if any
             -"update-database"
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NewStudentsJQ.Models
{
    public class NewStudents
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public DateTime JoinDate { get; set; }
    }
}