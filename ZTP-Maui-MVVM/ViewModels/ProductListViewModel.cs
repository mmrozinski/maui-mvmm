using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Refit;
using ZTP_Maui_MVVM.Clients;
using ZTP_Maui_MVVM.Models;

namespace ZTP_Maui_MVVM.ViewModels;

public partial class ProductListViewModel : ObservableObject
{
    private readonly IProductsClient _service;
    
    [ObservableProperty] private bool _isBusy = false;

    [ObservableProperty] private ObservableCollection<Product> _products = [];

    public ProductListViewModel(IProductsClient service)
    {
        _service = service;
    }

    [RelayCommand]
    public async Task Load()
    {
        IsBusy = true;
        Products.Clear();
        var response = await _service.GetProducts();
        foreach (var product in response.Content!)
        {
            Products.Add(product);
        }
        IsBusy = false;
    }
}