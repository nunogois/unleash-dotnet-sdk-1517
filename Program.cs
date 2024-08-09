using Unleash;
using Unleash.ClientFactory;

class Program
{
  static async Task Main(string[] args)
  {
    var settings = new UnleashSettings()
    {
      AppName = "dotnet-test",
      UnleashApi = new Uri("<unleash-url>/api/"),
      CustomHttpHeaders = new Dictionary<string, string>()
        {
          {"Authorization", "<client-token>" }
        }
    };

    var unleashFactory = new UnleashClientFactory();

    IUnleash unleash = await unleashFactory.CreateClientAsync(settings, synchronousInitialization: true);

    while (true)
    {
      var result = unleash.IsEnabled("test");
      var variant = unleash.GetVariant("test");

      Console.WriteLine(result);
      Console.WriteLine(variant.Name);

      Thread.Sleep(1000);
    }
  }
}