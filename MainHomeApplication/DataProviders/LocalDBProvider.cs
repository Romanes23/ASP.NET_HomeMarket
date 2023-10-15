using MainHomeApplication.Models;

namespace MainHomeApplication.DataProviders
{
    public class LocalDBProvider : IDataProvider
    {
        ApplicationContext _context;
        public LocalDBProvider(ApplicationContext context)
        {
            _context = context;
        }
        Home IDataProvider.createHome(Home home)
        {
            this._context.Homes.Add(home);
            this._context.SaveChanges();
            return home;
        }

        void IDataProvider.deleteHome(int homeId)
        {
            Home? dbHome =  this._context.Homes.Find(homeId);
            if (dbHome == null)
            {
                return;
            }
            this._context.Homes.Remove(dbHome);
            this._context.SaveChanges();
        }

        List<Home> IDataProvider.getAllHomes()
        {
            return this._context.Homes.ToList();
        }

        Home? IDataProvider.getHome(int id)
        {
            return this._context.Homes.Find(id);
        }

        Home? IDataProvider.updateHome(Home home)
        {
            Home? dbHome = this._context.Homes.Find(home.Id);
            if (dbHome == null) {
                return null;
            }
            else
            {
                dbHome.address = home.address;
                dbHome.ownerName = home.ownerName;
                this._context.SaveChanges();
                return dbHome;
            }
        }



        ServiceUser IDataProvider.createUser(ServiceUser user)
        {

            user.AccessLevel = "user";


            this._context.ServiceUsers.Add(user);
            this._context.SaveChanges();
            return user;
        }

        void IDataProvider.deleteUser(int UserId)
        {
            ServiceUser? dbUser = this._context.ServiceUsers.Find(UserId);
            if (dbUser == null)
            {
                return;
            }
            this._context.ServiceUsers.Remove(dbUser);
            this._context.SaveChanges();
        }

        List<ServiceUser> IDataProvider.getAllUsers()
        {
            return this._context.ServiceUsers.ToList();
        }

        ServiceUser? IDataProvider.getUser(int id)
        {
            return this._context.ServiceUsers.Find(id);
        }






        ServiceUser? IDataProvider.updateUser(ServiceUser user)
        {
            ServiceUser? dbUser = this._context.ServiceUsers.Find(user.Id);
            if (dbUser == null)
            {
                return null;
            }
            else
            {
                dbUser.Email = user.Email;
                dbUser.Password = user.Password;
                dbUser.PhoneNumber = user.PhoneNumber;
                dbUser.Gender = user.Gender;
                dbUser.AccessLevel = user.AccessLevel;



               
                this._context.SaveChanges();
                return dbUser;
            }
        }



 





    }
}
