namespace SpartakHRM.UserService.API.ViewModel.Documents;

public class EmployeeDetailsViewModel
{
    public Guid EmployeeId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}
