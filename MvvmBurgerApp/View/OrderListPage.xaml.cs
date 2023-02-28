using MvvmBurgerApp.ViewModels;

namespace MvvmBurgerApp.View;

public partial class OrderListPage : ContentPage
{
	public OrderListPage()
	{
		InitializeComponent();
		BindingContext = new BurgerListViewModel() { Navigation = this.Navigation };
	}
}