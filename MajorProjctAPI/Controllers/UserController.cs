using MajorProjctAPI.iInterface;
using MajorProjctAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MajorProjctAPI.Controllers
{
    //[ApiController]
    //[Route("[controller]")]

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {


        private IContactRepository dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(IContactRepository contactDBContext, ILogger<UserController> logger)
        {
            dbContext = contactDBContext;
            _logger = logger;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ReturnType<string>> ContactAdd(User obj)
        {
            ReturnType<string> res = new ReturnType<string>();
            try
            {
                res = await dbContext.AddContact(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UserController > ContactAdd" + JsonConvert.SerializeObject(obj));
            }
            return res;
        }



        //[HttpGet]
        //[Route("get")]
        //public async Task<ReturnType<string>> ContactGet()
        //{
        //    ReturnType<User> res = new ReturnType<string>();
        //    try
        //    {
        //        res = await dbContext.get();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "UserController > ContactGet" + JsonConvert.SerializeObject(res));
        //    }
        //    return res;
        //}

        [HttpGet]
        [Route("get")]
        public async Task<ReturnType<User>> ContactGet()
        {
            ReturnType<User> res = new ReturnType<User>();
            try
            {
                // ReturnType<User> result = dbContext.get();

                res = await dbContext.get();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UserController > ContactGet" + JsonConvert.SerializeObject(res));
            }
            return res;
        }





        //[HttpPost]
        [HttpDelete]
        [Route("delete")]
        public async Task<ReturnType<string>> ContactDelete(User obj)
        {
            ReturnType<string> res = new ReturnType<string>();
            try
            {
                res = await dbContext.UserContact_Delete(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "UserController > ContactDelete" + JsonConvert.SerializeObject(obj));
            }
            return res;
        }


    }
}
