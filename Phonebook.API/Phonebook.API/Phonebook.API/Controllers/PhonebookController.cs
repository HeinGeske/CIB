using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Attributes;
using Phonebook.Components.Interfaces;
using Phonebook.Models;
using Phonebook.Models.ApiResponse;

namespace Phonebook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RecordMetricsAttribute]
    public class PhonebookController : ControllerBase
    {
        private readonly IPhonebookComponent _phonebookComponent;
        public PhonebookController(IPhonebookComponent phonebookComponent)
        {
            _phonebookComponent = phonebookComponent;
        }

        [HttpGet]
        [Route("GetEntries")]
        public async Task<IActionResult> GetEntries(int? id)
        {
            return Ok(new ApiResponseModel<PhonebookModel>()
            {
                Result = await _phonebookComponent.GetEntries((id == null) ? 1 : Convert.ToInt32(id)),
                StatusCode = (int)HttpStatusCode.OK,
            });
        }
    }
}
