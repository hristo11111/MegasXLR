namespace CrowdSourcedNews.Services.Controllers
{
    using System.Web.Http;

    public class UsersController : ApiController
    {
        // Register -> creates user and add to DB + Login == add and return sessionKey
        // Login -> gets from db + returns session key == get and return sessionKey
        // Logout -> removes the sessionKey of the user from the database == update
        // GetAllUsers -> ...
    }
}
