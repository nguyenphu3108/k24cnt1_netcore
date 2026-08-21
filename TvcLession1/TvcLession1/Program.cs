namespace TvcLession1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello Nguyen Phu!");

            app.Run();
        }
    }
}
