using AudiSoft = Audisoft.Application.CustomAttributes;
using Audisoft.Application.Enums;
using Audisoft.Domain.Services.Interfaces;
using Audisoft.Dtos;
using Audisoft.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audisoft.Api.Controllers.V1
{
    //[AudiSoft.Version("x-version", "v1")]
    public class GenericBaseController<InDto, OutDto, Entity> : ControllerBase where InDto : class, new() where OutDto : GenericOutDto, new() where Entity : GenericModel, new()
    {
        protected readonly IGenericService<InDto, OutDto, Entity> _service;
        protected readonly IMapper mapper;
        protected string? ModuleName { get; set; }
        protected bool NeedValidate { get; set; } = true;

        public GenericBaseController(IGenericService<InDto, OutDto, Entity> service, IMapper mapper)
        {
            this._service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<Status<IEnumerable<OutDto>>>> Get()
        {
            var s = this.mapper.Map<IEnumerable<OutDto>>(await this._service.GetAllAsync());
            return Ok(new Status<IEnumerable<OutDto>>(null, TypeMessage.Success, this.mapper.Map<IEnumerable<OutDto>>(await this._service.GetAllAsync())));
        }

        [HttpGet("{Id}")]
        public virtual async Task<ActionResult<Status<OutDto>>> GetFirst(decimal Id)
        {
            var result = this.mapper.Map<OutDto>(await this._service.GetFirstAsync(Id));
            return Ok(new Status<OutDto>(null, TypeMessage.Success, result));
        }

        [HttpPost]
        public virtual async Task<ActionResult<Status<OutDto>>> Create(InDto Item)
        {
            var resultService = await this._service.CreateAsync(this.mapper.Map<Entity>(Item), NeedValidate ? $"Validate{ModuleName}Actions" : null);
            return Ok(new Status<OutDto>(resultService.Message, resultService.TypeMessage, this.mapper.Map<OutDto>(resultService.Data)));
        }

        [HttpPut("{Id}")]
        public virtual async Task<ActionResult<Status<OutDto>>> Update([FromRoute] decimal Id, [FromBody] InDto Entity)
        {
            var entityMap = this.mapper.Map<Entity>(Entity);
            var resultService = await this._service.UpdateAsync(this.mapper.Map<Entity>(Entity), Id, NeedValidate ? $"Validate{ModuleName}Actions" : null);
            return Ok(new Status<OutDto>(resultService.Message, resultService.TypeMessage, this.mapper.Map<OutDto>(resultService.Data)));
        }

        [HttpDelete("{Id}")]
        public virtual async Task<ActionResult<Status<OutDto>>> Delete([FromRoute] decimal Id)
        {
            var resultService = await this._service.DeleteAsync(this.mapper.Map<Entity>(new Entity { Id = Id }), NeedValidate ? $"Validate{ModuleName}Actions" : null);
            return Ok(new Status<OutDto>(resultService.Message,
                resultService.TypeMessage, this.mapper.Map<OutDto>(resultService.Data)));
        }


    }
}
