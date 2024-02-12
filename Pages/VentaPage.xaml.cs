using AppPruebaV1.ViewModels;

namespace AppPruebaV1.Pages;

public partial class VentaPage : ContentPage
{
    public VentaPage(VentaVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}