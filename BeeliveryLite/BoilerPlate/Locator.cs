using FunctionZero.MvvmZero;
using BeeliveryLite.Pages;
using BeeliveryLite.PageViewModels;
using SimpleInjector;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BeeliveryLite.BoilerPlate
{
	public class Locator
	{
		private Container _IoCC;

		internal Locator(Application currentApplication)
		{
			_IoCC = new Container();

			_IoCC.Register<IPageServiceZero>(
				() =>
				{
					var pageService = new PageServiceZero(() => App.Current.MainPage.Navigation, (theType) => _IoCC.GetInstance(theType));
					return pageService;
				},
				Lifestyle.Singleton
			);

			_IoCC.Register<HomePage>(Lifestyle.Singleton);
			_IoCC.Register<PlaceOrder>(Lifestyle.Singleton);
			_IoCC.Register<ViewBasket>(Lifestyle.Singleton);
			_IoCC.Register<Checkout>(Lifestyle.Singleton);
			_IoCC.Register<OrderTracking>(Lifestyle.Singleton);

			_IoCC.Register<HomePageVm>(Lifestyle.Singleton);
			_IoCC.Register<PlaceOrderVm>(Lifestyle.Singleton);
			_IoCC.Register<ViewBasketVm>(Lifestyle.Singleton);
			_IoCC.Register<CheckoutVm>(Lifestyle.Singleton);
			_IoCC.Register<OrderTrackingVm>(Lifestyle.Singleton);
		}
		internal async Task SetFirstPage()
		{

			App.Current.MainPage = new NavigationPage();
			await _IoCC.GetInstance<IPageServiceZero>().PushPageAsync<HomePage, HomePageVm>((vm) => {});
		}
		private void PageCreated(Page thePage)
		{
			Debug.WriteLine(thePage);
		}
	}
}
