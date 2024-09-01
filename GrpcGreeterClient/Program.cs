﻿using ClientProtos;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7121");

var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(
  new HelloRequest { Name = "GreeterClient "});

Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();