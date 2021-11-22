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
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UserController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/user
        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetUserList()
        {
            var userList = _repository.GetUserList();
            if (userList != null)
            {
                return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userList));
            }
            return NotFound();
        }

        //GET api/user/{id}
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult <UserReadDto> GetUserById(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo != null)
            {
                return Ok(_mapper.Map<UserReadDto>(userModelFromRepo));
            }
            return NotFound();
        }

        //POST api/user
        [HttpPost]
        public ActionResult <UserReadDto> CreateNewUser(UserCreateDto userCreate)
        {
            var userModelFromRepo = _repository.GetUserByEmail(userCreate.Email);
            if (userModelFromRepo != null)
            {
                return Unauthorized();
            }
            var userModel = _mapper.Map<User>(userCreate);

            _repository.CreateNewUser(userModel);
            _repository.SaveChanges();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute (nameof(GetUserById), new {Id = userModel.UserId}, userReadDto);
        }

        //PUT api/user/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto, userModelFromRepo);

            _repository.UpdateUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/user/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userModelFromRepo = _repository.GetUserById(id);
            if (userModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteUser(userModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
