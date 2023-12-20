using System.Net;
using Cohorts_01.Models;
using Cohorts_01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cohorts_01.Controllers;

[Route("api")]
[ApiController]
//localhost:5067/api => Base Path
public class UserController : Controller
{
    UserService service = new UserService();

    // api/users
    [HttpGet("users")]
    public List<User> Get()
    {
        return UserService.users;
    }

    [HttpGet("user/{id}")]
    public User GetById(int id)
    {
        return service.findById(id);
    }

    [HttpPost("user")]
    public HttpResponseMessage Post([FromBody] User user)
    {
       service.createUser(user);
       return new HttpResponseMessage(HttpStatusCode.Created);
    }

    [HttpPut("user/{id}")]
    public HttpResponseMessage Put(int id,[FromBody] User user)
    {
       bool isRecord = service.updateUser(id,user);
       if (isRecord == false)
       {
           return new HttpResponseMessage(HttpStatusCode.NotFound);
       }
       return new HttpResponseMessage(HttpStatusCode.Created);
    }

    [HttpDelete("user/{id}")]
    public HttpResponseMessage Delete(int id)
    {
        service.deleteUser(id);
        return new HttpResponseMessage(HttpStatusCode.NoContent);
    }

    [HttpPatch("user/{id}")]
    public HttpResponseMessage Patch(int id,[FromBody] User user)
    {
       bool isUpdate = service.patchName(id,user);
       if (isUpdate)
       {
           return new HttpResponseMessage(HttpStatusCode.OK);
       }

       return new HttpResponseMessage(HttpStatusCode.NotModified);
    }

}

