using CommunityToolkit.Mvvm.ComponentModel;

namespace ZTP_Maui_MVVM.Models;

public partial class Product : ObservableObject
{
    [ObservableProperty] private string? _id;
    [ObservableProperty] private string _name = null!;
    [ObservableProperty] private string _description = null!;
    [ObservableProperty] private decimal _price;
    [ObservableProperty] private int _quantity;
}