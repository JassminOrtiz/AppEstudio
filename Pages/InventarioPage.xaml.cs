using AppPruebaV1.ViewModels;

namespace AppPruebaV1.Pages;

public partial class InventarioPage : ContentPage
{
    public InventarioPage(InventarioVM viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}