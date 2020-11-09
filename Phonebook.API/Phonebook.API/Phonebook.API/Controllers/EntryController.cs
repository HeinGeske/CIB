using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Attributes;
using Phonebook.Components.Interfaces;
using Phonebook.Models;
using Phonebook.Models.ApiRequest;
using Phonebook.Models.ApiResponse;

namespace Phonebook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RecordMetricsAttribute]
    public class EntryController : ControllerBase
    {
        private readonly IEntryComponent _entryComponent;
        public EntryController(IEntryComponent entryComponent)
        {
            _entryComponent = entryComponent;
        }

        [HttpPost]
        [Route("SearchEntries")]
        public async Task<IActionResult> SearchEntries(SearchEntriesModel model)
        {
            return Ok(new ApiResponseModel<List<EntryModel>>()
            {
                Result = await _entryComponent.GetEntriesFiltered(model.PhonebookId,model.Search),
                StatusCode = (int)HttpStatusCode.OK,
            });
        }

        [HttpPost]
        [Route("AddEntry")]
        [ValidatorActionFilter]
        public async Task<IActionResult> AddEntry(AddEntryModel model)
        {
            await _entryComponent.AddEntry(model);
            return Ok();
        }
    }
}
