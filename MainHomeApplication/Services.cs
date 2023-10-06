using System.Reflection.Metadata;

namespace MainHomeApplication
{
    public interface IGetHomeIndex  // интерфейс
    {
        public int Index(); // метод интерфейса

    }
    class HomeIndexGenerator : IGetHomeIndex
    {
        private static int _index = 0; //статич поле 
        private int index;            //обычное поле

        public HomeIndexGenerator() // конструктор для эемента
        {
            this.index = _index; // нумеруем домики
            _index++;
        }
        public int Index() // реализуем интерфейсный метод
        {
            return this.index;
        }
    }

    public interface IGetHomeImagePath  // ещё один
    {
        public string GetImagePath(Home home); // метод интерфейса
    }

    class HomePathGenerator: IGetHomeImagePath  // путь к картинке
    {
        public string GetImagePath(Home home) // принимаем объект дома
        {
            return $"images/home_{home.id}.jpg"; //   C:\Users\Admin\Source\Repos\ASP.NET_HomeMarket\MainHomeApplication\wwwroot\images\home_0.jpg
        }
    }

}
