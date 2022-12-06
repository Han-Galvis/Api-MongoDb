using ApiMongodb.Context;
using ApiMongodb.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongodb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        UserColletions Db = new UserColletions();
        
        [HttpGet]
        public IActionResult GetUserall()
        {
            return Ok(Db.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserId(string Id)
        {
            return Ok(Db.GetUsersId(Id));
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] Users users)
        {
            if (users == null)
                return BadRequest();
            return Ok(Db.InsertUsers(users));
        }

        [HttpPut("{id}")]
        public IActionResult PutUserId([FromBody] Users users, string id)
        {
            if (users.id == null)
                return BadRequest();
            users.id = new MongoDB.Bson.ObjectId( id);
            return Ok(Db.UpdateUsers(users));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(string Id)
        {
            if(string.IsNullOrEmpty(Id))
                return BadRequest();
            return Ok(Db.DeleteUsers(Id));
        }
    }
}
