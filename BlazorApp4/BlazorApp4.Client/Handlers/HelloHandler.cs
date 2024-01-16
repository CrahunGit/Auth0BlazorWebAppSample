using BlazorApp4.Client.Handlers;
using MediatR;
using static BlazorApp4.Client.Handlers.SayHelloRequest;

namespace BlazorApp4;

public class HelloHandler : IRequestHandler<SayHelloRequest, SayHelloResponse>
{
    private readonly IHttpClientFactory Factory;

    public HelloHandler(IHttpClientFactory factory)
    {
        Factory = factory;
    }

    public async Task<SayHelloResponse> Handle(SayHelloRequest request, CancellationToken cancellationToken)
    {
        var client = Factory.CreateClient("API");
        var result = await client.GetStringAsync("/Hello");
        return new SayHelloResponse($"Client: {result}");
    }
}
