using Audisoft.Domain.Repositories.Interfaces;
using Audisoft.Domain.Services.Interfaces;
using Audisoft.Dtos.Entities.Note;
using Audisoft.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Audisoft.Api.Controllers.V1.Administration
{
    [ApiController]

    [Route("Api/Note")]
    public class NoteController : GenericBaseController<NoteInDto, NoteOutDto, Note>
    {
        public NoteController(INoteRepository noteRepository, IGenericService<NoteInDto, NoteOutDto, Note> service, IMapper mapper) : base(service, mapper)
        {
            this.NeedValidate = false;
            _service.SetRepository(noteRepository);
        }
    }
}
