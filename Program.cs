// See https://aka.ms/new-console-template for more information
using OlympusThread.Services;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string path = "/log/out.txt";
        var logService = new ThreadLogService(path);
        Console.WriteLine("Start threads...");

        try
        {
            logService.Initialize();
            Task[] tasks = new Task[10];
            for (int i = 0; i < 10; i++) {
                tasks[i] = Task.Run(() =>

                logService.WriteThread()
                );
            }

            await Task.WhenAll(tasks);
            Console.WriteLine("All threads compelted writing");
        }
        catch (Exception ex) {
            Console.WriteLine($"Application error: {ex.Message}");
        }



    }


}