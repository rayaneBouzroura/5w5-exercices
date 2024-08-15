using _5W5_exo02_cookie_backend.Models;
using _5W5_exo02_cookie_backend.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _5W5_exo02_cookie_backend.Controllers
{





    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //TODO05 inject usernamanager et signinmanager dans le cotnrolleur
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        //TODO06 Creation method register
        [HttpPost(("enregistrer"))]
        public async Task<ActionResult> Register(RegisterDTO register)
        {

            //if pw is same
            if(register.Password != register.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "mdp de confirmation est different" });
            }
            //creer demo user obj
            DemoUser user = new DemoUser()
            {
                UserName = register.Username,
                Email = register.Email
            };
            //add user w le pw
            IdentityResult identityResult = await _userManager.CreateAsync(user,register.Password);

            //test sur le resut
            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = identityResult.Errors });
            }

            //si tt va bien return ok
            return Ok(new { msg = "yippy!" });

        }

    }
}
