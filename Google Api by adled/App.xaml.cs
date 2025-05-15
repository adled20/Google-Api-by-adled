using Google_Api_by_adled.Data;

namespace Google_Api_by_adled
{
    public partial class App : Application
    {
        private static UbicacionDataBase DataBase;
        public static UbicacionDataBase dataBase
        {
            get
            {
                if (DataBase == null)
                {
                    var url = Path.Combine(FileSystem.AppDataDirectory, "BaseDatos.db3");
                    return DataBase = new UbicacionDataBase(url);
                }
                else
                {
                    return DataBase;
                }
            }
        }
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}