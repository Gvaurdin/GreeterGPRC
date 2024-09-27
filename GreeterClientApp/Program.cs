// создаем канал для обмена сообщениями с сервером
// параметр - адрес сервера gRPC
using ConsoleAppClientGrpc;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7067");
var client = new Greeter.GreeterClient(channel);

// запрос у пользователя
Console.Write("Введите имя: ");
var firstName = Console.ReadLine();
Console.Write("Введите фамилию: ");
var lastName = Console.ReadLine();
Console.Write("Введите возраст: ");
var age = int.Parse(Console.ReadLine());

//запрос на регистрацию
var reply = await client.RegisterUserAsync(new RegisterRequest
{
    FirstName = firstName,
    LastName = lastName,
    Age = age
});

// ответ сервера
Console.WriteLine(reply.Message);
Console.WriteLine($"Имя: {reply.User.FirstName}, Фамилия: {reply.User.LastName}, Возраст: {reply.User.Age}");
Console.ReadKey();