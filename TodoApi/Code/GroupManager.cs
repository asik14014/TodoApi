﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoData.Dao;
using TodoData.Enum;
using TodoData.Models.Group;

namespace TodoApi.Code
{
    public static class GroupManager
    {
        private static GroupDaoManager groupDaoManager = new GroupDaoManager();

        public static List<Group> GetAllGroups()
        {
            return groupDaoManager.GetAll();
        }

        public static IList<Group> GetAllGroupsByUser(long userId)
        {
            return groupDaoManager.GetAllByUserId(userId);
        }

        public static Group Create(Group group)
        {
            return groupDaoManager.Save(group);
        }

        public static void Delete(Group group)
        {
            groupDaoManager.Delete(group);
        }

        public static Group GetGroup(long id)
        {
            return groupDaoManager.GetById(id);
        }

        public static Group SaveOrUpdate(Group group)
        {
            return groupDaoManager.SaveOrUpdate(group);
        }

        public static Group CreateFavorites(long userId)
        {
            var group = new Group()
            {
                Id = 0,
                UserId = userId,
                GroupType = (int)GroupTypeEnum.FAVOURITES,
                Name = "Избранное",
                Description = "Группа избранное",
                Order = 0,
                CreationDate = DateTime.Now,
                LastUpdate = DateTime.Now,
                IsActive = true
            };
            return groupDaoManager.Save(group);
        }
    }
}
