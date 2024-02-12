using AppPruebaV1.ViewModels;

namespace AppPruebaV1
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage(MainVM vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }


    }

}
