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
    public class TipController : ControllerBase
    {
        private readonly ITipRepo _repository;
        private readonly IMapper _mapper;

        public TipController(ITipRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/tip
        [HttpGet]
        public ActionResult <IEnumerable<TipReadDto>> GetTipList()
        {
            var tipList = _repository.GetTipList();
            if (tipList != null)
            {
                return Ok(_mapper.Map<IEnumerable<TipReadDto>>(tipList));
            }
            return NotFound();
        }

        //GET api/tip/{id}
        [HttpGet("{id}", Name = "GetTipById")]
        public ActionResult <TipReadDto> GetTipById(int id)
        {
            var tipModelFromRepo = _repository.GetTipById(id);
            if (tipModelFromRepo != null)
            {
                return Ok(_mapper.Map<TipReadDto>(tipModelFromRepo));
            }
            return NotFound();
        }

        //POST api/tip
        [HttpPost]
        public ActionResult <TipReadDto> CreateNewTip(TipCreateDto tipCreate)
        {
            var tipModel = _mapper.Map<Tip>(tipCreate);

            _repository.CreateNewTip(tipModel);
            _repository.SaveChanges();

            var tipReadDto = _mapper.Map<TipReadDto>(tipModel);

            return CreatedAtRoute (nameof(GetTipById), new {Id = tipModel.TipId}, tipReadDto);
        }

        //PUT api/tip/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateTip(int id, TipUpdateDto tipUpdateDto)
        {
            var tipModelFromRepo = _repository.GetTipById(id);
            if (tipModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(tipUpdateDto, tipModelFromRepo);

            _repository.UpdateTip(tipModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/tip/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteTip(int id)
        {
            var tipModelFromRepo = _repository.GetTipById(id);
            if (tipModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteTip(tipModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}