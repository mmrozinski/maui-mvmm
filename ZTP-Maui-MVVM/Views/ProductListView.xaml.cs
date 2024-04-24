using ZTP_Maui_MVVM.Clients;
using ZTP_Maui_MVVM.Models;
using ZTP_Maui_MVVM.ViewModels;

namespace ZTP_Maui_MVVM.Views;

public partial class ProductListView : ContentPage
{
    private readonly IProductsClient _productsClient;
    private readonly IServiceProvider _serviceProvider;
    
    public ProductListView(ProductListViewModel viewModel, IProductsClient productsClient, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _productsClient = productsClient;
        _serviceProvider = serviceProvider;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await (BindingContext as ProductListViewModel).Load();
    }

    private void ListView_OnItemSelected(object? sender, SelectedItemChangedEventArgs e)
    {
        var view = _serviceProvider.GetService<ProductView>()!;
        var viewModel = _serviceProvider.GetService<ProductViewModel>()!;
        viewModel.Product = (Product)e.SelectedItem;
        view.BindingContext = viewModel;
        Navigation.PushAsync(view);
    }

    private void AddProductButton_OnClicked(object? sender, EventArgs e)
    {
        var view = _serviceProvider.GetService<NewProductView>()!;
        view.BindingContext = _serviceProvider.GetService<NewProductViewModel>();
        Navigation.PushAsync(view);
    }
}