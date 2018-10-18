using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWT_Authentication.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Login(User user)
        {
            User principal = new UserRepository().GetUser(user.UserName);

            if (principal == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found!");

            bool credentials = principal.Password.Equals(user.Password);
            if (!credentials)
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Password Wrong!");

            return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(user.UserName));
        }

        [HttpGet]
        public HttpResponseMessage Validate(string token, string username)
        {
            //checks the existence of the username in the repository
            bool exists = new UserRepository().GetUser(username) != null;

            //validates the token using the previously created method and returns a proper HTTP response
            if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
                 "The user was not found.");

            string tokenUsername = TokenManager.ValidateToken(token);

            if (username.Equals(tokenUsername))
                return Request.CreateResponse(HttpStatusCode.OK);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
