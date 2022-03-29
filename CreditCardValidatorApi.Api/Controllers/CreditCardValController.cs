using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardValidatorApi.Application.Features.Card.Commands;
using CreditCardValidatorApi.Application.Features.Card.Dto;
using CreditCardValidatorApi.Core.Common;

namespace CreditCardValidatorApi.Api.Controllers
{
    /// <summary>
    /// ValidateCreditCard is responsible to Validate Card,
    /// if case of successful validation returns Card Brand Name
    /// else return error(s) in response.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardValController : ApiController
    {
        [HttpPost]
        [Route("Validate")]
        public async Task<ActionResult<Response>> ValidateCreditCard(CreateCardCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
