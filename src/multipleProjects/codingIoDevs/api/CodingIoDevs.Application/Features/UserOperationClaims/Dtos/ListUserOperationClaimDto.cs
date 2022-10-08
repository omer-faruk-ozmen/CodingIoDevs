namespace CodingIoDevs.Application.Features.UserOperationClaims.Dtos;

public class ListUserOperationClaimDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}