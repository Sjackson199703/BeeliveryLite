using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using BeeliveryLite.Pages;
using BeeliveryLite.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeeliveryLite.PageViewModels
{
    public class HomePageVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public ICommand PlaceOrderPageCommand { get; }

        public ICommand ViewBasketPageCommand { get; }

        public ICommand CheckoutPageCommand { get; }

        public ICommand OrderTrackingPageCommand { get; }

        public HomePageVm(IPageServiceZero pageService)
        {
            _pageService = pageService;
            PlaceOrderPageCommand = new CommandBuilder().SetExecuteAsync(PlaceOrderPageCommandExecuteAsync).SetName("Place Order").Build();
            ViewBasketPageCommand = new CommandBuilder().SetExecuteAsync(ViewBasketPageCommandExecuteAsync).SetName("View Basket").Build();
            CheckoutPageCommand = new CommandBuilder().SetExecuteAsync(CheckoutPageCommandExecuteAsync).SetName("Check Out").Build();
            OrderTrackingPageCommand = new CommandBuilder().SetExecuteAsync(OrderTrackingPageCommandExecuteAsync).SetName("Order Tracking").Build();
        }

        public async Task PlaceOrderPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<PlaceOrder, PlaceOrderVm>((vm) => {});
        }
        public async Task ViewBasketPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<ViewBasket, ViewBasketVm>((vm) => {});
        }
        public async Task CheckoutPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<Checkout, CheckoutVm>((vm) => { });
        }
        public async Task OrderTrackingPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<OrderTracking, OrderTrackingVm>((vm) => { });
        }
    }
}