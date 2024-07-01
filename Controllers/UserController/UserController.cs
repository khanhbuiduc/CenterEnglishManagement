﻿using CenterEnglishManagement.Models.OtherModels;
using CenterEnglishManagement.Service.IService.IOtherServices;
using CenterEnglishManagement.Service.IService;
using Microsoft.AspNetCore.Mvc;
using CenterEnglishManagement.Models.UserModels;
using CenterEnglishManagement.Service.IService.IUserServices;
using CenterEnglishManagement.Extentions;
using CenterEnglishManagement.Dto.ModelDto.OtherModelDto;
using AutoMapper;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace CenterEnglishManagement.Controllers.UserController
{
    
        [ApiController]
        [Route("api/[controller]")]
        public class UserController : CommonController<User>
        {
            private readonly IUserService _services;
            private readonly IMapper _mapper;
            public UserController(ICommonServices<User> commonServices, IUserService service, IMapper mapper) : base(commonServices)
            {
                _services = service;
            _mapper = mapper;
            }
        [HttpGet("role")]
        public async Task<IActionResult> GetAllByRole(int pageIndex, int pageSize, string sortBy, bool sortDesc, UserRole role)
        {
            var entities = await _services.GetAllByRoleAsync(pageIndex, pageSize, sortBy, sortDesc, role);
            var userDtos = entities.Select(u => _mapper.Map<UserDto>(u));
            return Ok(userDtos);
        }
        [HttpGet("role/{id}")]
        public async Task<IActionResult> GetUserByRoleAndId(int id,UserRole role)
        {
            var user = await _services.GetbyIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Role != role)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserDto>(user));
        }
        [HttpPost("role")]
        public async Task<IActionResult> CreateUserByRole([FromBody] CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                Password = createUserDto.Password,
                Mobile = createUserDto.Mobile,
                DOB = string.IsNullOrEmpty(createUserDto.DOB) ? (DateTime?)null : DateTime.SpecifyKind(DateTime.ParseExact(createUserDto.DOB, "yyyy-MM-dd", null), DateTimeKind.Utc),
                Gender = createUserDto.Gender,
                IsActive = true,
                Role = createUserDto.Role,
                Address = createUserDto.Address,
            };
            await _services.CreateAsync(user);
            return Ok(user);
        }
        [HttpGet("totalPayment")]
        public IActionResult GetPaymentandTuitionTotal() { 
            return Ok(_services.PaymentandTuitionTotal());
        }
        [HttpGet("teacher/{idTeacher}/classes")]
        public async Task<IActionResult> GetClassesbybyTeacherId(int idTeacher)
        {
            var classes = await _services.GetTeacherClassesAsync(idTeacher);
            return Ok(classes);
            /*// Configure JsonSerializerOptions with ReferenceHandler.Preserve
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            // Serialize classes to JSON with configured options
            var serializedClasses = JsonSerializer.Serialize(classes, jsonOptions);

            // Return serialized classes in the response
            return Ok(serializedClasses);*/
        }
    }
    
}
