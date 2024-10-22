using databaze_maui.Interfaces;

namespace databaze_maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        readonly IStringValidator nameValidator;
        readonly IIdentityNumberValidator rodneCisloValidator;
        readonly IBirthDateValidator birthValidator;

        public MainPage()
        {
            InitializeComponent();


            
        }

      
    }
}