using AutoMapper;
using SpartakHRM.UserService.API.ViewModel;
using SpartakHRM.UserService.API.ViewModel.Documents;
using SpartakHRM.UserService.API.ViewModel.Draft;
using SpartakHRM.UserService.API.ViewModel.NewFolder;
using SpartakHRM.UserService.API.ViewModel.Office;
using SpartakHRM.UserService.API.ViewModel.User;
using SpartakHRM.UserService.BLL.Models;
using SpartakHRM.UserService.DAL.Entities;
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.API.Mapper
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<DocumentEntity, Document>().ReverseMap();
            CreateMap<DocumentEntity, EmployeeDetails>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.Name))
                 .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.Surname))
                 .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<EmployeeDetails, DocumentEntity>()
                .ForPath(dest => dest.User.Name, opt => opt.MapFrom(src => src.FirstName))
                .ForPath(dest => dest.User.Surname, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.EmployeeId));


            CreateMap<CreateDocumentModel, DocumentEntity>()
               .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.EmployeeId));
            CreateMap<Document, DocumentViewModel>().ReverseMap();
            CreateMap<EmployeeDetails, EmployeeDetailsViewModel>().ReverseMap();
            CreateMap<EmployeeHireDetails, UserEntity>();

            CreateMap<Draft, DraftViewModel>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => src.AcceptanceDate.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.WorkFormat, opt => opt.MapFrom(src => src.WorkFormat.ToString()));

            CreateMap<DraftViewModel, Draft>()
            .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.AcceptanceDate)));

            CreateMap<CreateOfficeViewModel, Office>();
            CreateMap<Office, OfficeViewModel>();

            CreateMap<EmployeePersonalInfoDraftViewModel, EmployeePersonalInfoDraft>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.BirthDate)))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender));

            CreateMap<EmployeeBusinessInfoDraftViewModel, EmployeeBusinessInfoDraft>();
            CreateMap<EmployeeBusinessInfoDraft, EmployeeBusinessInfoDraftViewModel>();

            CreateMap<EmployeePersonalInfoDraft, EmployeePersonalInfoDraftViewModel>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.ToString()));

            CreateMap<EmployeeBusinessInfoDraft, EmployeeBusinessInfoDraftViewModel>()
            .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => src.AcceptanceDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<EmployeeBusinessInfoDraftViewModel, EmployeeBusinessInfoDraft>()
            .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.AcceptanceDate)));

            CreateMap<Contact, ContactViewModel>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
            .ForMember(dest => dest.IsPrimary, opt => opt.MapFrom(src => src.IsPrimary));

            CreateMap<Contact, ContactEntity>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<ContactEntity, Contact>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<User, UserEntity>()
             .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
             .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
             .ForMember(dest => dest.WorkStatus, opt => opt.MapFrom(src => src.WorkStatus))
             .ForMember(dest => dest.WorkFormat, opt => opt.MapFrom(src => src.WorkFormat))
             .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.BirthDate)))
             .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.AcceptanceDate)));

            CreateMap<OfficeEntity, Office>().ReverseMap();
            CreateMap<CreateOfficeModel, OfficeEntity>();

            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => Enum.GetName(typeof(EmployeePosition), src.Position)))
                .ForMember(dest => dest.WorkStatus, opt => opt.MapFrom(src => Enum.GetName(typeof(WorkStatus), src.WorkStatus)))
                .ForMember(dest => dest.WorkFormat, opt => opt.MapFrom(src => Enum.GetName(typeof(WorkFormat), src.WorkFormat)))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToDateTime(TimeOnly.MinValue)))
                .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => src.AcceptanceDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UserViewModel, User>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.WorkStatus, opt => opt.MapFrom(src => src.WorkStatus))
                .ForMember(dest => dest.WorkFormat, opt => opt.MapFrom(src => src.WorkFormat))
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts));

            CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
            .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
            .ForMember(dest => dest.WorkStatus, opt => opt.MapFrom(src => src.WorkStatus))
            .ForMember(dest => dest.WorkFormat, opt => opt.MapFrom(src => src.WorkFormat))
            .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts));

            CreateMap<User, CreateUserViewModel>();
            CreateMap<CreateUserViewModel, User>();

            CreateMap<User, UpdateUser>();
            CreateMap<UpdateUser, User>();

            CreateMap<Draft, CreateDraft>();
            CreateMap<CreateDraft, Draft>();

            CreateMap<Draft, UpdateDraft>();
            CreateMap<UpdateDraft, Draft>();
            CreateMap<CreateDraft, DraftViewModel>().ReverseMap();

            CreateMap<Draft, UserDraftEntity>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => src.AcceptanceDate))
                .ForMember(dest => dest.PersonalInfo, opt => opt.MapFrom(src => src.PersonalInfo))
                .ForMember(dest => dest.BusinessInfo, opt => opt.MapFrom(src => src.BusinessInfo))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.WorkFormat, opt => opt.MapFrom(src => src.WorkFormat.ToString()))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.OfficeId, opt => opt.MapFrom(src => src.OfficeId));

            CreateMap<UserDraftEntity, Draft>()
                .ForMember(dest => dest.AcceptanceDate, opt => opt.MapFrom(src => src.AcceptanceDate));
            CreateMap<ContactEntity, Contact>();
            CreateMap<Contact, ContactEntity>();
            CreateMap<EmployeeBusinessInfoDraftEntity, EmployeeBusinessInfoDraft>();
            CreateMap<EmployeeBusinessInfoDraft, EmployeeBusinessInfoDraftEntity>();
            CreateMap<EmployeePersonalInfoDraftEntity, EmployeePersonalInfoDraft>();
            CreateMap<EmployeePersonalInfoDraft, EmployeePersonalInfoDraftEntity>();


        }
    }
}
