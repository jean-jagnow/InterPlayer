using MediatR;

namespace InterPlayer.Application.Password;

public class ValidatePasswordCommand : IRequest<ValidatePasswordResult>
{
    public string Password { get; set; }
}