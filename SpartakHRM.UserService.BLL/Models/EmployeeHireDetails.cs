using static SpartakHRM.UserService.DAL.Entities.EnumsEntity;

namespace SpartakHRM.UserService.BLL.Models;

public class EmployeeHireDetails
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public WorkFormat WorkFormat { get; set; }
}
