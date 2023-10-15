﻿using System.Reflection.Metadata;

namespace MainHomeApplication
{
    public interface IGetHomeIndex
    {
        public int Index();

    }
    class HomeIndexGenerator : IGetHomeIndex
    {
        private static int _index = 0;
        private int index;
        public HomeIndexGenerator()
        {
            this.index = _index;
            _index++;
        }
        public int Index()
        {
            return this.index;
        }
    }

    public interface IGetHomeImagePath
    {
        public string GetImagePath(Home home);
    }

    class HomePathGenerator : IGetHomeImagePath
    {
        public string GetImagePath(Home home)
        {
            return $"images/home_{home.Id}.jpg";
        }
    }
    public interface IDataProvider
    {
        public Home? getHome(int id);
        public List<Home> getAllHomes();
        public Home? updateHome(Home home);
        public void deleteHome(int homeId);
        public Home createHome(Home home);



        public ServiceUser? getUser(int id);
        public List<ServiceUser> getAllUsers();
        public ServiceUser? updateUser(ServiceUser user);
        public void deleteUser(int userId);
        public ServiceUser createUser(ServiceUser user);






    }











}
