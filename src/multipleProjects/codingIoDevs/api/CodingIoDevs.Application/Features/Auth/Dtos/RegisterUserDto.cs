using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingIoDevs.Application.Features.Auth.Dtos;

public class RegisterUserDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}