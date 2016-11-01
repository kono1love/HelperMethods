﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData =
                {
            new Person {FirstName="Adam", LastName="Vseravnov", Role = Role.Admin },
             new Person {FirstName="Vlad", LastName="Konovalov", Role = Role.User },
              new Person {FirstName="WhatIsLove", LastName="Kono1love", Role = Role.User },
               new Person {FirstName="Kot", LastName="Babaduk", Role = Role.Guest }
        };
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult GetPeopleData(string selectedRole = "All")
        {
            IEnumerable<Person> data = personData;
            if(selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return PartialView(data);
        }
        public ActionResult GetPeople(string selectedRole = "All")
        {
            return View((object)selectedRole);
        }
        
    }
}