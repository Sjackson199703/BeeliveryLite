using BeeliveryLite.BoilerPlate;
using Xamarin.Forms;

namespace BeeliveryLite
{
    public partial class App : Application
    {

        public Locator Locator { get; private set; }

        public App()
        {
            InitializeComponent();
            Locator = new Locator(this);
            _ = Locator.SetFirstPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}