using ZTP_Maui_MVVM.Views;

namespace ZTP_Maui_MVVM;

public partial class MainPage : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    public MainPage(IServiceProvider serviceProvider)
    {
        AppDomain.CurrentDomain.UnhandledException += (s, e) =>
        {
            global::System.Diagnostics.Debug.WriteLine("AppDomain");
        };
        TaskScheduler.UnobservedTaskException += (s, e) =>
        {
            global::System.Diagnostics.Debug.WriteLine("TaskScheduler");
        };

        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    private async void OnStartClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(_serviceProvider.GetService<ProductListView>());
    }
}