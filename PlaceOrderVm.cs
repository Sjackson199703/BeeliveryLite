using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using BeeliveryLite.Pages;
using BeeliveryLite.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeeliveryLite.PageViewModels
{
    public class PlaceOrderVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public ICommand HomePageCommand { get; }
        public ICommand OrderTrackingPageCommand { get; }

        public ICommand ViewBasketPageCommand { get; }

        public ICommand CheckoutPageCommand { get; }


        public PlaceOrderVm(IPageServiceZero pageService)
        {
            _pageService = pageService;
            HomePageCommand = new CommandBuilder().SetExecuteAsync(HomePageCommandExecuteAsync).SetName("Home").Build();
            OrderTrackingPageCommand = new CommandBuilder().SetExecuteAsync(OrderTrackingPageCommandExecuteAsync).SetName("Order Tracking").Build();
            ViewBasketPageCommand = new CommandBuilder().SetExecuteAsync(ViewBasketPageCommandExecuteAsync).SetName("View Basket").Build();
            CheckoutPageCommand = new CommandBuilder().SetExecuteAsync(CheckoutPageCommandExecuteAsync).SetName("Check Out").Build();
        }

        public async Task OrderTrackingPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<OrderTracking, OrderTrackingVm>((vm) => { });
        }
        public async Task ViewBasketPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<ViewBasket, ViewBasketVm>((vm) => { });
        }
        public async Task CheckoutPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<Checkout, CheckoutVm>((vm) => { });
        }
        public async Task HomePageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<HomePage, HomePageVm>((vm) => { });
        }
    }
}