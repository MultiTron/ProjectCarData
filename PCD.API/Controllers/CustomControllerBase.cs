using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCD.Infrastructure.Messaging;

namespace PCD.API.Controllers;

/// <summary>
/// Custom WebAPI Controller class derived by every other Controller.
/// </summary>
[Authorize]
public class CustomControllerBase : ControllerBase
{
    /// <summary>
    /// This method automatically evaluates the response of the Application service layer and returns an IActionResult.
    /// </summary>
    /// <param name="response">The response of the Application service layer.</param>
    /// <returns>An IActionResult determined by the status code of the <paramref name="response"/></returns>
    protected IActionResult Output(BaseResponse response)
    {
        if (response.StatusCode == CustomStatusCode.Success)
        {
            return Ok(response);
        }
        return BadRequest();
    }
}
