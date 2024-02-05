namespace SpartakHRM.UserService.BLL.Models;
public class EmployeeDetails
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
