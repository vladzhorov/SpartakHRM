public class ContactViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
    public bool IsPrimary { get; set; }
}