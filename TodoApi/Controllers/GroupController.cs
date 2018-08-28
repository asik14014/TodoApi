using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Response Get()
        {
            return new Response();
        }

        /// <summary>
        /// Создать группу
        /// </summary>
        public Response Create()
        {
            return new Response();
        }

        /// <summary>
        /// Редактировать группу
        /// </summary>
        /// <returns></returns>
        public Response Modify()
        {
            return new Response();
        }

        /// <summary>
        /// Удалить группу
        /// </summary>
        /// <returns></returns>
        public Response Delete()
        {
            return new Response();
        }
    }
}