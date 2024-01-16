using BlazorApp4.Client.Handlers;
using MediatR;
using static BlazorApp4.Client.Handlers.SayHelloRequest;

namespace BlazorApp4.Handlers;

public class HelloHandler : IRequestHandler<SayHelloRequest, SayHelloResponse>
{
    public Task<SayHelloResponse> Handle(SayHelloRequest request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new SayHelloResponse($"Server: Hi! {DateTime.Now:s}"));
    }
}
