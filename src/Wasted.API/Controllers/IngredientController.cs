using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Wasted.API.Data;
using Wasted.API.Dtos;
using Wasted.API.Models;
using System.Collections.Generic;

namespace Wasted.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepo _repository;
        private readonly IMapper _mapper;

        public IngredientController(IIngredientRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/ingredient
        [HttpGet]
        public ActionResult <IEnumerable<IngredientReadDto>> GetIngredientList()
        {
            var ingredientList = _repository.GetIngredientList();
            if (ingredientList != null)
            {
                return Ok(_mapper.Map<IEnumerable<IngredientReadDto>>(ingredientList));
            }
            return NotFound();
        }

        //GET api/ingredient/{dishId}
        [HttpGet("{dishid}", Name = "GetIngredientListByDishId")]
        public ActionResult <IEnumerable<IngredientReadDto>> GetIngredientListByDishId(int dishId)
        {
            var ingredientList = _repository.GetIngredientListByDishId(dishId);
            if (ingredientList != null)
            {
                return Ok(_mapper.Map<IEnumerable<IngredientReadDto>>(ingredientList));
            }
            return NotFound();
        }

        //POST api/ingredient
        [HttpPost]
        public ActionResult <IngredientReadDto> CreateNewIngredient(IEnumerable<IngredientCreateDto> ingredientCreate)
        {
            var ingredientList = _mapper.Map<IEnumerable<Ingredient>>(ingredientCreate);

            _repository.CreateNewIngredient(ingredientList);
            _repository.SaveChanges();

            return CreatedAtRoute(1,1);
        }

        //PUT api/ingredient/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateIngredient(int DishId, IEnumerable<IngredientUpdateDto> ingredientUpdateDto)
        {
            var ingredientModelFromRepo = _repository.GetIngredientListByDishId(DishId);
            if (ingredientModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(ingredientUpdateDto, ingredientModelFromRepo);

            _repository.UpdateIngredient(ingredientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/ingredient/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteIngredient(int dishId)
        {
            var ingredientModelFromRepo = _repository.GetIngredientListByDishId(dishId);
            if (ingredientModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteIngredients(ingredientModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
