﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi02.Infrastructure
{
    public class EmployeeAuthenteficationAttribute: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string autorizationToken = actionContext.Request
                    .Headers.Authorization.Parameter;
                string decodedAuthenToken = Encoding.UTF8
                    .GetString(Convert.FromBase64String(autorizationToken));

                string[] usernamePassArray = decodedAuthenToken.Split(':');
                string username = usernamePassArray[0];
                string password = usernamePassArray[1];

                if (EmployeeSecurity.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
                   // var o = actionContext.Request.CreateResponse(HttpStatusCode.)
                }
            }
        }
    }
   
}