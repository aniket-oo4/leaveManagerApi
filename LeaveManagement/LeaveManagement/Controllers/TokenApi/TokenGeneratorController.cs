using LeaveManagement.Auth;
using LM.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace LeaveManagement.Controllers.TokenApi
{
    public class TokenGeneratorController : ApiController
    {
        // POST: api/TokenGenerator/
        [HttpPost]
        [Route("api/tokenGenerator")]
        public HttpResponseMessage Post([FromBody]Users login)
        {
            return Request.CreateResponse(HttpStatusCode.OK, CustomJwtHandler.GenerateToken(login.userName, login.roleName));
        }
    }
}
