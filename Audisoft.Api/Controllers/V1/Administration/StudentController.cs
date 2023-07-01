using Audisoft.Domain.Services.Interfaces;
using Audisoft.Dtos.Entities.Student;
using Audisoft.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audisoft.Api.Controllers.V1.Administration
{
    [ApiController]
    [Route("Api/Student")]
    public class StudentController : GenericBaseController<StudentInDto, StudentOutDto, Student>
    {
        public StudentController(IGenericService<StudentInDto, StudentOutDto, Student> service, IMapper mapper) : base(service, mapper)
        {
            this.NeedValidate = false;

        }
    }
}
