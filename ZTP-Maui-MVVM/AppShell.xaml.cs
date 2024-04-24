using ZTP_Maui_MVVM.Views;

namespace ZTP_Maui_MVVM;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(NewProductView), typeof(NewProductView));
        Routing.RegisterRoute(nameof(ProductListView), typeof(ProductListView));
        Routing.RegisterRoute(nameof(ProductView), typeof(ProductView));
    }
}