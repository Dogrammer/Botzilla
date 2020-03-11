using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Botzilla.Core.Abstractions;
using Botzilla.Core.CreateRequestModels;
using Botzilla.Core.Services;
using Botzilla.Core.UpdateRequestModels;
using Botzilla.Core.ViewModels;
using Botzilla.Domain.Domain;
using Botzilla.Infrastructure.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Botzilla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICountryService _countryService;

        public CountryController(
            IMapper mapper,
            ICountryService countryService
            )
        {
            _mapper = mapper;
            //_unitOfWork = unitOfWork;
            _countryService = countryService;
        }

        [HttpGet]
        [Route("getCountries")]
        public async Task<IActionResult> GetCountriesAsync()
        {
            var countries = await _countryService
                .Queryable()
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .ProjectTo<CountryViewModel>(configuration: _mapper.ConfigurationProvider)
                .ToListAsync();

            return Ok(countries);
        }

        [HttpPost]
        [Route("countries")]
        public async Task<ActionResult> AddCountry(CreateCountryRequest request)
        {
            var existing = await _countryService
                .Queryable()
                .Where(x => x.Name == request.Name && !x.IsDeleted)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (existing == null)
            {
                var domain = _mapper.Map<Country>(request);
                _countryService.Insert(domain);

                var save = await _countryService.SaveChangesAsync();
            }

            var newlyAdded = await _countryService
                .Queryable()
                .AsNoTracking()
                .Where(py =>  py.Name.ToUpper() == request.Name.ToUpper())
                .SingleOrDefaultAsync();

            return Ok(newlyAdded);
            
        }

        [HttpDelete("{id}", Name = nameof(DeleteCountryAsync))]
        [Produces(typeof(CountryViewModel))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCountryAsync(long id)
        {
            if (id <= 0)
            {
                // notify the caller that he has made a bad request
                return BadRequest("Provided Id is not valid");
            }

            // see if we can find that entity in the data store
            var existing = await _countryService
                .Queryable()
                .AsNoTracking()
                .Where(py => !py.IsDeleted && py.Id == id)
                .SingleOrDefaultAsync();

            if (existing != null)
            {
                try
                {
                    _countryService.Delete(existing);

                    var save = await _countryService.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    // an exception has hapenned, notify caller
                    return BadRequest("Exception: " + ex.Message);
                }
            }
            else
            {
                // existing item was not found, notify caller
                return NotFound("Existing item not found");
            }

            //return Ok("Item: " + existing.Name + " is deleted");
            return NoContent();
        }

        [HttpPut("{id}", Name = nameof(EditCountryAsync))]
        [Produces(typeof(CountryViewModel))]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> EditCountryAsync(long id, [FromBody]UpdateCountryRequest request)
        {
            if (id <= 0)
            {
                // notify the caller that he has made a bad request
                return BadRequest("Provided Id is not valid");
            }

            // check to see if the [UpdatePedagogicalYearRequest] request model is valid
            if (!ModelState.IsValid)
                return Ok(ModelState.GetErrorMessages());
            //return Ok(FleksbitResponse.CreateResponse(HttpStatusCode.BadRequest, ModelState.GetErrorMessages()));

            // see if we can find that entity in the data store
            var existing = await _countryService
                .Queryable()
                .AsNoTracking()
                .Where(py => !py.IsDeleted && py.Id == id)
                .SingleOrDefaultAsync();

            if (existing != null)
            {
                var mapped = _mapper.Map<Country>(request);
                mapped.Id = id;

                try
                {
                    _countryService.Update(mapped);

                    var save = await _countryService.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    // an exception has hapenned, notify caller
                    return Ok(HttpStatusCode.InternalServerError + ex.Message);
                }
            }
            else
            {
                // existing item was not found, notify caller
                return NotFound("Item was not found in data store");
            }

            // return the newly updated entity to the caller, in the form of a view model
            var updated = await _countryService
                .Queryable()
                .AsNoTracking()
                .Where(py => !py.IsDeleted && py.Id == request.Id)
                .SingleOrDefaultAsync();

            var mapVmAfter = _mapper.Map<CountryViewModel>(updated);

            return Ok(mapVmAfter);
        }
    }
}