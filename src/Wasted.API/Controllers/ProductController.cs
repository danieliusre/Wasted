using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Wasted.API.Data;
using Wasted.API.Dtos;
using Wasted.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wasted.API.Wrapped;
using Wasted.API.Filter;
using System.Linq;
using Wasted.API.Services;
using Wasted.API.Helpers;


namespace Wasted.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;
        private readonly WastedContext context;
        private readonly IUriService uriService;
        public ProductController(WastedContext context, IUriService uriService, IProductRepo repository, IMapper mapper)
        {
            this.context = context;
            this.uriService = uriService;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProductList([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = context.Products
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();
            var totalRecords = context.Products.Count();
            var pagedReponse = PaginationHelper.CreatePagedReponse<Product>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);
        }

        //GET api/product/{id}
        [HttpGet("{id}", Name = "GetProductById")]
        public IActionResult GetProductById(int id)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo != null)
            {
                // return Ok(_mapper.Map<ProductReadDto>(productModelFromRepo));
                var product =  _mapper.Map<ProductReadDto>(productModelFromRepo);
            return Ok(new Response<ProductReadDto>(product));
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
