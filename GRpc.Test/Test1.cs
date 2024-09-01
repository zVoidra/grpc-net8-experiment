using Grpc.Net.Client;
using NUnit.Framework;

namespace GRpc.Test;

public class GrpcTest1
{
  private Greeter.GreeterClient _client;

  [SetUp]
  public void Setup()
  {
    var channel = GrpcChannel.ForAddress("https://localhost:7121");
    _client = new Greeter.GreeterClient(channel);
  }

  [Test]
  public async Task SayHello_ReturnsExpectedMessage()
  {
    // Act
    var response = await _client.SayHelloAsync(new HelloRequest { Name = "TestUser" });

    // Assert
    Assert.That(response.Message, Is.EqualTo("Hello TestUser"));

    TestContext.WriteLine(response.Message);
  }
}