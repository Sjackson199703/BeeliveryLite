using FunctionZero.CommandZero;
using FunctionZero.MvvmZero;
using BeeliveryLite.Pages;
using BeeliveryLite.ViewModels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeeliveryLite.PageViewModels
{
    public class CheckoutVm : BaseVm
    {
        private readonly IPageServiceZero _pageService;

        public ICommand HomePageCommand { get; }
        public ICommand PlaceOrderPageCommand { get; }

        public ICommand ViewBasketPageCommand { get; }

        public ICommand OrderTrackingPageCommand { get; }

        public CheckoutVm(IPageServiceZero pageService)
        {
            _pageService = pageService;
            HomePageCommand = new CommandBuilder().SetExecuteAsync(HomePageCommandExecuteAsync).SetName("Home").Build();
            PlaceOrderPageCommand = new CommandBuilder().SetExecuteAsync(PlaceOrderPageCommandExecuteAsync).SetName("Place Order").Build();
            ViewBasketPageCommand = new CommandBuilder().SetExecuteAsync(ViewBasketPageCommandExecuteAsync).SetName("View Basket").Build();
            OrderTrackingPageCommand = new CommandBuilder().SetExecuteAsync(OrderTrackingPageCommandExecuteAsync).SetName("Order Tracking").Build();
        }

        public async Task HomePageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<HomePage, HomePageVm>((vm) => { });
        }
        public async Task PlaceOrderPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<PlaceOrder, PlaceOrderVm>((vm) => { });
        }
        public async Task ViewBasketPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<ViewBasket, ViewBasketVm>((vm) => { });
        }
        public async Task OrderTrackingPageCommandExecuteAsync()
        {
            await _pageService.PushPageAsync<OrderTracking, OrderTrackingVm>((vm) => { });
        }
    }
}