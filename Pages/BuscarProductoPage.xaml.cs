using AppPruebaV1.ViewModels;
namespace AppPruebaV1.Pages;

public partial class BuscarProductoPage : ContentPage
{
    public BuscarProductoPage(BuscarProductoVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}