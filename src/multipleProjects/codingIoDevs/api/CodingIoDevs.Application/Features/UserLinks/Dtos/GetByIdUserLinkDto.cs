namespace CodingIoDevs.Application.Features.UserLinks.Dtos;

public class GetByIdUserLinkDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string? GithubUrl { get; set; }
    public string? LinkedInUrl { get; set; }
}