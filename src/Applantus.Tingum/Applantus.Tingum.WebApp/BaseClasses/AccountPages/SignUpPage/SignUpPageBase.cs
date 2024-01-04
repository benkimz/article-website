using Applantus.Tingum.Core.Interfaces.ICoreCanvas.IAppUsers;
using Applantus.Tingum.WebApp.Services;
using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace Applantus.Tingum.WebApp.BaseClasses.AccountPages.SignUpPage
{
    public class SignUpPageBase : ComponentBase
    {
        // ~ inject services
        [Inject]
        private IAppUsersRepository? AppUsersRepository { get; set; }

        [Inject]
        private DataValidation? Validator { get;set; } 

        [Inject]
        private NavigationManager? NavigationManager { get; set; } 
        //

        protected string? Name { get; set; } 

        protected string? UserName { get; set; } 

        protected string Email { get; set; } = string.Empty;

        protected string Password { get; set; } = string.Empty; 

        protected string ConfirmPassword { get; set; } = string.Empty; 

        protected bool AgreeToTerms { get; set; } = true;

        // ~ error placeholder
        protected string? ErrorMessage { get; set; }  

        // ~ methods
        protected void ToggleAgreeToTerms()
        {
            AgreeToTerms = !AgreeToTerms;
        }

        protected void RegisterUser()
        {
            ErrorMessage = string.Empty;
            ErrorMessage += AgreeToTerms ? string.Empty : "You must agree to terms before proceeding.";
            ErrorMessage += (Password == ConfirmPassword) ? ErrorMessage : "Passwords are not matching.";
            if (AppUsersRepository == null || NavigationManager == null || Validator == null)
            {
                ErrorMessage += "A problem occured in the system. Please try again later.";
            }
            else
            {
                //
            }
            //
			/*if (!AgreeToTerms)
            {
                ErrorMessage = "You must agree to terms before proceeding."; 
			}*/
		}
	}
}
