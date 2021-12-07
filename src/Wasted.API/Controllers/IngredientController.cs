using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Wasted.API.Data;
using Wasted.API.Dtos;
using Wasted.API.Models;
using System.Collections.Generic;
using System;

namespace Wasted.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepo _repository;
        private readonly IDishRepo _dishRepository;
        private readonly IProductRepo _productRepository;

        private readonly IMapper _mapper;

        public IngredientController(IIngredientRepo repository, IProductRepo productRepository, IMapper mapper)
        {
            _repository = repository;
            _productRepository = productRepository;
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

        //POST api/ingredient/{dishId}
        [HttpPost("{dishId}")]
        public ActionResult <List<IngredientWEB>> CreateNewIngredient(int dishId, List<IngredientWEB> ingredients)
        {
            List<Ingredient> newList = new List<Ingredient>();

            foreach (var ingredient in ingredients)
            {
                Ingredient newIngredient = new Ingredient();
                newIngredient.DishId = dishId;
                IEnumerable<Product> products = _productRepository.GetProductList();
                foreach (var product in products)
                {
                    if(product.Name == ingredient.Item)
                    {
                        newIngredient.ProductId = product.Id;
                    }
                }
                newIngredient.Amount = ingredient.Amount;
                newList.Add(newIngredient);
            }

            _repository.CreateNewIngredient(newList);
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

        //DELETE api/ingredient/{dishId}
        [HttpDelete("{dishId}")]
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
