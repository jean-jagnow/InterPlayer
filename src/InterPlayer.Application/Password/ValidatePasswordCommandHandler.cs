using MediatR;

namespace InterPlayer.Application.Password;

public class ValidatePasswordCommandHandler :
    IRequestHandler<ValidatePasswordCommand, ValidatePasswordResult>
{
    public async Task<ValidatePasswordResult> Handle(ValidatePasswordCommand request, CancellationToken cancellationToken)
        => await Task.FromResult(new ValidatePasswordResult { IsValid = true });
}