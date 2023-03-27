using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.DataAccess.Data;
using RestaurantApp.Models;
using RestaurantApp.Models.Dto;
using RestaurantApp.Repository.IRepository;
using RestaurantApp.Services.IService;
using System.Net;

namespace RestaurantApp.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        #region attributes
        protected readonly APIResponse _response;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<RestaurantController> _logger;
        #endregion
        #region constructor
        public RestaurantController(ApplicationDbContext db, IMapper mapper, IRestaurantRepository restaurantRepository, ILogger<RestaurantController> logger, IRestaurantService restaurantService)
        {
            _db = db;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
            _logger = logger;
            _response = new();
            _restaurantService = restaurantService;
        }
        #endregion
        #region endpoints
        /// <summary>
        /// Get a list of restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        public async Task<ActionResult<APIResponse>> GetRestaurants()
        {
            try
            {
                _logger.LogInformation("Getting all Restaurant");
               // IEnumerable<Restaurant> RestaurantList = await _restaurantRepository.GetAllAsync();
                IEnumerable<RestaurantDTO> RestaurantDTOList = await _restaurantService.GetAllAsync();
                _response.Result = RestaurantDTOList;
               // _response.Result = _mapper.Map<List<RestaurantDTO>>(RestaurantList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        /// <summary>
        /// Get individual restaurant
        /// </summary>
        /// <param name="id">The id of restaurant</param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetRestaurant")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<APIResponse>> GetRestaurant(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Get Restaurant Error with: " + id);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;

                    return BadRequest(_response);

                }

                var restaurantDTO =await  _restaurantService.GetAsync(id);
                if (restaurantDTO == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);

                }
                _response.Result = restaurantDTO;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;
        }

        /// <summary>
        /// Create a restaurant
        /// </summary>
        /// <param name="createDTO"></param>
        /// <returns>A newly created Restaurant</returns>
        /// <response code="201">Returns the newly created Restaurant</response>
        /// <response code="400">If the restaurant is null</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> CreateRestaurant([FromBody] RestaurantCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);

                }

     
              
                var createdRestaurant =await _restaurantService.CreateAsync(createDTO);
                _response.Result = createdRestaurant;


                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetRestaurant", new { id = createdRestaurant.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>()
                {
                    ex.ToString()
                };
            }
            return _response;

        }
        /// <summary>
        /// Update a specific restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}", Name = "UpdateRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateRestaurant(int id, [FromBody] RestaurantUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id) { return BadRequest(); }
                var restaurant = await _restaurantService.GetAsync(id, tracked: false);
                if (restaurant == null) return NotFound();

                var updatedRestaurant = await _restaurantService.UpdateAsync(updateDTO);
                _response.Result = updatedRestaurant;
                _response.StatusCode = HttpStatusCode.NoContent;

                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        /// <summary>
        /// Delete a specific restaurant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}", Name = "DeletRestaurant")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<APIResponse>> DeletRestaurant(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var restaurant = await _restaurantService.GetAsync(id,false);
                if (restaurant == null)
                {
                    return NotFound();
                }
                await _restaurantService.DeleteAsync(id);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        #endregion
    }
}
