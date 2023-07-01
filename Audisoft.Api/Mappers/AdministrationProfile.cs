using Audisoft.Dtos.Entities.Note;
using Audisoft.Dtos.Entities.Student;
using Audisoft.Dtos.Entities.Teacher;
using Audisoft.Models.Entities;
using AutoMapper;

namespace Audisoft.Api.Mappers
{
    public class AdministrationProfile : Profile
    {
        public AdministrationProfile()
        {
            CreateMap<Note, NoteOutDto>()
                .ForMember(x => x.StudentName, opt => opt.MapFrom(x => x.Student.Name))
                .ForMember(x => x.TeacherName, opt => opt.MapFrom(x => x.Teacher.Name));

            CreateMap<NoteInDto, Note>();

            CreateMap<Teacher, TeacherOutDto>();
            CreateMap<TeacherInDto, Teacher>();

            CreateMap<Student, StudentOutDto>();
            CreateMap<StudentInDto, Student>();
        }
    }
}
