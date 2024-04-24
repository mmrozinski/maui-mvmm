using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using ZTP_Maui_MVVM.Clients;
using ZTP_Maui_MVVM.Models;
using ZTP_Maui_MVVM.Views;

namespace ZTP_Maui_MVVM.ViewModels;

public partial class ProductViewModel : ObservableObject
{
    private readonly IProductsClient _service;
    
    [ObservableProperty] private bool _isBusy = false;
    
    [ObservableProperty] private Product _product;

    public ProductViewModel(IProductsClient service)
    {
        _service = service;
        _product = new Product();
    }
    
    [RelayCommand]
    private async Task Update()
    {
        IsBusy = true;
        var response = await _service.PutProduct(Product.Id!, Product);
        await Shell.Current.GoToAsync("..");
        IsBusy = false;
    }
    
    [RelayCommand]
    private async Task Delete()
    {
        IsBusy = true;
        var response = await _service.DeleteProduct(Product.Id!);
        await Shell.Current.GoToAsync("..");
        IsBusy = false;
    }
}