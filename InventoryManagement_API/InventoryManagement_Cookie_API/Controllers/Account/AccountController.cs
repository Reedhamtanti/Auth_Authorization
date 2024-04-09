using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_Cookie_API.Controllers.Account
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly string _userName;
        private readonly string _password;


       public AccountController(){
           
           _userName = "naadhaduk";
           _password = "password";
       }


       [Route("Login")]
       [HttpPost("Login")]
       public async Task<IActionResult> Login(LoginModel model)
       {
           try
           {
               if (string.IsNullOrEmpty(model.Username))
               {
                   return BadRequest($"{nameof(model.Username)} is required");
               }
               if (string.IsNullOrEmpty(model.Password))
               {
                   return BadRequest($"{nameof(model.Password)} is required");
               }

               var validUser = await Task.FromResult(_userName == model.Username && _password == model.Password);

               if (!validUser)
               {
                   return Unauthorized();
               }

               var claim = new Claim[]
               {
                   new Claim(ClaimTypes.Name, "Nikunj"),
                   new Claim(ClaimTypes.Role, "SalesRep"),
                   new Claim(ClaimTypes.Email, "nikunj@nikunj.com"),
               };

               var identity = new ClaimsIdentity(claim, AuthenticationSchema.DefaultAuthenticationSchema);

               var claimPrincipal = new ClaimsPrincipal(identity);

               await HttpContext.SignInAsync(AuthenticationSchema.DefaultAuthenticationSchema, claimPrincipal, new AuthenticationProperties()
               {
                   IsPersistent = false,
               });

               return Ok();
           }
           catch (Exception ex)
           {
                return BadRequest(ex.Message);  
           }
       }
    }
}
