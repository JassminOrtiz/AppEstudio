using AppPruebaV1.ViewModels;

namespace AppPruebaV1.Pages;

public partial class CategoriasPage : ContentPage
{
    public CategoriasPage(CategoriasVM viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
    }

}