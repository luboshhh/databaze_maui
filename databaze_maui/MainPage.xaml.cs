using databaze_maui.Interfaces;

namespace databaze_maui
{
    public partial class MainPage : ContentPage
    {
        
        private readonly DatabaseService _databaseService;
        private readonly IBirthDateValidator _birthDateValidator;
        private readonly IIdentityNumberValidator _identityNumberValidator;
        private readonly IStringValidator _nameValidator;

        public MainPage()
        {
            InitializeComponent();

           
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "people.db3");

            _databaseService = new DatabaseService(databasePath);
            _birthDateValidator = new BirthDateValidator();
            _identityNumberValidator = new IdentityNumberValidator();
            _nameValidator = new NameValidator();

            LoadPeople();



        }

        private void LoadPeople()
        {
            var people = _databaseService.GetAllPeople();
            PeopleListView.ItemsSource = people;
        }


        private void OnAddPersonClicked(object sender, EventArgs e)
        {
            var firstName = FirstNameEntry.Text;
            var lastName = LastNameEntry.Text;
            var birthDate = BirthDatePicker.Date;
            var socialSecurityNumber = SocialSecurityNumberEntry.Text;

         
            var validationErrors = new List<string>();

            if (!_nameValidator.IsValid(firstName))
                validationErrors.Add("Jméno je povinné.");

            if (!_nameValidator.IsValid(lastName))
                validationErrors.Add("Příjmení je povinné.");

            if (!_birthDateValidator.IsValid(birthDate))
                validationErrors.Add("Datum narození musí být v minulosti.");

            if (!_identityNumberValidator.IsValid(socialSecurityNumber, birthDate))
                validationErrors.Add("Rodné číslo není platné.");

            if (validationErrors.Any())
            {
                
                DisplayAlert("Chyba", string.Join("\n", validationErrors), "OK");
                return;
            }

            
            var newPerson = new Person
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                SocialSecurityNumber = socialSecurityNumber
            };

            _databaseService.AddPerson(newPerson);
            LoadPeople();
        }

        private void OnDeletePersonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var personId = (int)button.CommandParameter;

            _databaseService.DeletePerson(personId);
            LoadPeople(); 
        }
    }

    
    public class NameValidator : IStringValidator
    {
        public bool IsValid(string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }


    }
}