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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/product
        [HttpGet]
        public ActionResult <IEnumerable<ProductReadDto>> GetProductList()
        {
            var productList = _repository.GetProductList();
            if (productList != null)
            {
                return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productList));
            }
            return NotFound();
        }

        //GET api/product/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult <ProductReadDto> GetProductById(int id)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(productModelFromRepo));
            }
            return NotFound();
        }

        //POST api/product
        [HttpPost]
        public ActionResult <ProductReadDto> CreateNewProduct(ProductCreateDto productCreate)
        {
            var productModel = _mapper.Map<Product>(productCreate);

            _repository.CreateNewProduct(productModel);
            _repository.SaveChanges();

            var productReadDto = _mapper.Map<ProductReadDto>(productModel);

            return CreatedAtRoute (nameof(GetProductById), new {Id = productModel.Id}, productReadDto);
        }

        //PUT api/product/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(productUpdateDto, productModelFromRepo);

            _repository.UpdateProduct(productModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/product/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteProduct(productModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
