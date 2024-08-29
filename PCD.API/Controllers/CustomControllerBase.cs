﻿using Microsoft.AspNetCore.Mvc;
using PCD.ApplicationServices.Messaging;

namespace PCD.API.Controllers;

public class CustomControllerBase : ControllerBase
{
    protected IActionResult Output(BaseResponse response)
    {
        if (response.StatusCode == CustomStatusCode.Success)
        {
            return Ok(response);
        }
        return BadRequest();
    }
}
