using ExcepitionMidLib.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ExcepitionMidLib.GlobalResponce
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public HttpActionResponce HttpActionResult(object data, [Optional]string userMessage)
        {
            var httpActionResponce = new HttpActionResponce();
            if(data != null)
            {
                httpActionResponce.TrackingId = Guid.NewGuid().ToString();
                httpActionResponce.UserMessage= userMessage;
                httpActionResponce.Data = data;
                httpActionResponce.DeveloperMessage = null;
                httpActionResponce.StatusCode= 200;
            }
            else
            {
                httpActionResponce.TrackingId = Guid.NewGuid().ToString();
                httpActionResponce.UserMessage= userMessage;
                httpActionResponce.Data = data;
                httpActionResponce.DeveloperMessage= null;
                httpActionResponce.StatusCode= 204;
            }
            return httpActionResponce;
        }
    }
}
