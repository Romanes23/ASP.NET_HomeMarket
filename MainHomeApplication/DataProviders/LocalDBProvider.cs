using MainHomeApplication.Models;

namespace MainHomeApplication.DataProviders
{
    public class LocalDBProvider : IHomeDataProvider
    {
        ApplicationContext _context;
        public LocalDBProvider(ApplicationContext context) {
            _context = context;
        }
        Home IHomeDataProvider.createHome(Home home)
        {
            Home newhome = this._context.Homes.Add(home);
        }

        void IHomeDataProvider.deleteHome(Home home)
        {
            throw new NotImplementedException();
        }

        List<Home> IHomeDataProvider.getAllHomes()
        {
            throw new NotImplementedException();
        }

        Home IHomeDataProvider.getHome(int id)
        {
            throw new NotImplementedException();
        }

        Home IHomeDataProvider.updateHome(Home home)
        {
            throw new NotImplementedException();
        }
    }
}
