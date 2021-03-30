using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ScoreCombination.Application.Dtos;
using ScoreCombination.Application.Interfaces;

namespace ScoreCombination.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScoreCombinationController : ControllerBase
    {
        private readonly IApplicationServiceRecord _applicationServiceRecord;

        public ScoreCombinationController(IApplicationServiceRecord applicationServiceRecord)
        {
            _applicationServiceRecord = applicationServiceRecord;
        }

        /// <summary>
        /// Get the request from body, store the request and returns the score combination result.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///         "Sequence": [5, 20, 2, 1],
        ///         "Target": 47
        ///     }
        /// 
        /// </remarks>
        /// <param name="request">Request is an object that has one list of long called 'Sequence' and a long number called 'Target'.</param>
        /// <returns>If there are no errors, it returns the combination result.</returns>
        [HttpPost]
        public ActionResult<ScoreCombinationResultDto> Post([FromBody] ScoreCombinationRequestDto request)
        {
            if (request == null)
            {
                return BadRequest("Please add some information to the request.");
            }

            if (request.Sequence == null)
            {
                ModelState.AddModelError(nameof(request.Sequence), "Please add one or more scores to the sequence.");
                return BadRequest(ModelState);
            }

            if (request.Sequence.Any())
            {
                return Ok(_applicationServiceRecord.Post(request));
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Get the dates from url and returns all requests made between them.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     https://localhost:44362/api/scoreCombination/initialDate/2021-01-01/finalDate/2021-12-31
        /// 
        /// </remarks>
        /// <param name="initialDate">Initial Date</param>
        /// <param name="finalDate">Final Date</param>
        /// <returns>If there are no errors, it returns a list with all the api calls between the dates.</returns>
        [HttpGet("initialDate/{initialDate}/finalDate/{finalDate}")]
        public ActionResult<IEnumerable<ScoreCombinationRecordDto>> Get(DateTime initialDate, DateTime finalDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (finalDate < initialDate)
            {
                return BadRequest("Final date must be greater than or equal to initial date.");
            }

            try
            {
                return Ok(_applicationServiceRecord.GetCallHistory(initialDate, finalDate));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
