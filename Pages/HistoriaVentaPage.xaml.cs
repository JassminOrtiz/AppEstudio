using AppPruebaV1.ViewModels;

namespace AppPruebaV1.Pages;

public partial class HistoriaVentaPage : ContentPage
{
    public HistoriaVentaPage(HistorialVentaVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}