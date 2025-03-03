using System.ComponentModel.DataAnnotations;

namespace AECMVCProject.ViewModel
{
    public class LoginUserView
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool  RememberMe { get; set; }
    }
}
