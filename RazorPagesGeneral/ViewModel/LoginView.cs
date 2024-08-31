using System.ComponentModel.DataAnnotations;

namespace RazorPagesGeneral.ViewModel
{
    public class LoginView
    {
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
