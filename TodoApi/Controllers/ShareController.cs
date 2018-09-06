﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NLog;
using TodoApi.Code;
using TodoApi.Models;
using TodoData.Models.Group;
using TodoData.Models.Task;

namespace TodoApi.Controllers
{
    public class ShareController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public object Task(Task task, long userId, int type)
        {
            logger.Log(LogLevel.Debug, $"ShareController.Task({Json(task)}, {userId})");
            try
            {
                return ShareManager.ShareTask(task, userId, type);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"ShareController.Task({Json(task)}, {userId}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }

        public object Group(Group group, long userId, int type)
        {
            logger.Log(LogLevel.Debug, $"ShareController.Group({Json(group)}, {userId})");
            try
            {
                return ShareManager.ShareGroup(group, userId, type);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"ShareController.Group({Json(group)}, {userId}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }

        public object DeleteTask(Task task, long userId)
        {
            logger.Log(LogLevel.Debug, $"ShareController.DeleteTask({Json(task)}, {userId})");
            try
            {
                if (ShareManager.UnshareTask(task, userId))
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"ShareController.DeleteTask({Json(task)}, {userId}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }

        public object DeleteGroup(Group group, long userId)
        {
            logger.Log(LogLevel.Debug, $"ShareController.DeleteGroup({Json(group)}, {userId})");
            try
            {
                if (ShareManager.UnshareGroup(group, userId))
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, $"ShareController.DeleteGroup({Json(group)}, {userId}) - {ex}");
                //изменить http status code
                return new Response(100, ex.Message);
            }
        }
    }
}