using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using ZTP_Maui_MVVM.Clients;
using ZTP_Maui_MVVM.Models;
using ZTP_Maui_MVVM.Views;

namespace ZTP_Maui_MVVM.ViewModels;

public partial class NewProductViewModel : ObservableObject
{
    private readonly IProductsClient _service;
    
    [ObservableProperty] private bool _isBusy = false;
    
    [ObservableProperty] private Product _product;

    public NewProductViewModel(IProductsClient service)
    {
        _service = service;
        _product = new Product();
    }
    
    [RelayCommand]
    private async Task Add()
    {
        IsBusy = true;
        var response = await _service.PostProduct(Product);
        await Shell.Current.GoToAsync("..");
        IsBusy = false;
    }
}