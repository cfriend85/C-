﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LogReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LogReg.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(e => e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                } else {
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("LoggedInUser", newUser.UserId);
                    return RedirectToAction("Success");
                }
            } else {
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser logUser)
        {
            if(ModelState.IsValid)
            {
                User userInDb = _context.Users.FirstOrDefault(e => e.Email == logUser.LEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LEmail", "Invalid login attempt");
                    return View("Index");
                }
                PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logUser, userInDb.Password, logUser.LPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LEmail", "Invalid login attempt");
                    return View("Index");
                } else {
                    HttpContext.Session.SetInt32("LoggedInUser", userInDb.UserId);
                    return RedirectToAction("Success");
                }
            } else {
                return View("Index");
            }
        }

        [HttpGet("Success")]
        public IActionResult Success()
        {
            int? loggedIn = HttpContext.Session.GetInt32("LoggedInUser");
            if(loggedIn != null)
            {
                ViewBag.User = _context.Users.FirstOrDefault(a => a.UserId == (int)loggedIn);
                return View();
            } else {
                return RedirectToAction("Index");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
