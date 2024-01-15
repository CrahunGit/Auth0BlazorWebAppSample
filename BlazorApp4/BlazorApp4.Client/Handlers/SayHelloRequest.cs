using MediatR;

namespace BlazorApp4.Client.Handlers;

public record SayHelloRequest: IRequest<SayHelloRequest.SayHelloResponse>
{
    public record SayHelloResponse(string response);
}
