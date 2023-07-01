using Audisoft.Domain.Services.Interfaces;
using Audisoft.Dtos.Entities.Teacher;
using Audisoft.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audisoft.Api.Controllers.V1.Administration
{
    [ApiController]
    [Route("Api/Teacher")]
    public class TeacherController : GenericBaseController<TeacherInDto, TeacherOutDto, Teacher>
    {
        public TeacherController(IGenericService<TeacherInDto, TeacherOutDto, Teacher> service, IMapper mapper) : base(service, mapper)
        {
            this.NeedValidate = false;
        }
    }
}
