using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using UM.Shared.SharedLib.Dtos;

namespace UM.Shared.SharedLib.ControllerBases
{
    public class CustomBaseController : ControllerBase //ControllerBase getirtmek için sağ tık Edit Project File'e manuel ekledik.
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
