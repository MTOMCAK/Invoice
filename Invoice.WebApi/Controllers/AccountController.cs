using System.Threading.Tasks;
using System.Web.Http;
using BusinessLogic.UserApi;
using BusinessLogic.API_Auth;

namespace Invoice.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        public AccountController()
        {
            _repo = new AuthRepository();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(IdentityUser userToRegister)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repo.RegisterUser(userToRegister);
            if (result)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}
