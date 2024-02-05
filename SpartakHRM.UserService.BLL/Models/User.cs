﻿//namespace SpartakHRM.UserService.BLL.Models
//{
//    public class User
//    {
//        public Guid Id { get; set; }
//        public string Name { get; set; }
//        public string Surname { get; set; }
//        public string Position { get; set; }
//        public DateTime BirthDate { get; set; }
//        public DateTime AcceptanceDate { get; set; }
//        public string Gender { get; set; }
//        public string Location { get; set; }
//        public string WorkStatus { get; set; }
//        public string WorkFormat { get; set; }
//        public string AvatarURL { get; set; }
//        public Guid? OfficeId { get; set; }
//        public List<Contact> Contacts { get; set; }
//        public bool IsDeleted { get; set; }
//        public bool IsActive { get; set; }
//        public string Role { get; set; }
//    }
//}
using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EmployeePosition Position { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public Gender? Gender { get; set; }
        public string Location { get; set; }
        public WorkStatus WorkStatus { get; set; }
        public WorkFormat WorkFormat { get; set; }
        public string AvatarURL { get; set; }
        public Guid? OfficeId { get; set; }
        public List<Contact> Contacts { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        //public string Role { get; set; }
    }
}