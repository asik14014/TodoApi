﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using TodoApi.Code;
using TodoApi.Models;
using TodoData.Models.User;

namespace TodoApi.Controllers
{
    public class UserController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public object Registration(User user)
        {
            logger.Log(LogLevel.Debug, $"UserController.Registration({Json(user)})");
            try
            {
                var result = UserManager.Register(user);

                try
                {
                    GroupManager.CreateFavorites(result.Id);
                }
                catch (Exception e)
                {
                    logger.Log(LogLevel.Error, $"Не смог создать группу избранное." +
                        $"UserController.Registration({Json(user)}) - {e}");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"UserController.Registration({Json(user)}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>'
        [Authorize]
        [HttpGet]
        public object GetToken(string login, string password)
        {
            return "";
        }

        [Authorize]
        [HttpGet]
        public object Find(string login)
        {
            logger.Log(LogLevel.Debug, $"UserController.Find({login})");
            try
            {
                return UserManager.FindUserInfo(login);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"UserController.Find({login}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public object Update(User user)
        {
            logger.Log(LogLevel.Debug, $"UserController.Update({Json(user)})");
            try
            {
                return UserManager.Update(user);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"UserController.Update({Json(user)}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }

        /*
        private System.Web.Http.IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }*/
    }
}