using System;
using System.IO;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Desktop.Services;
using Desktop.ViewModels;
using Desktop.Views;

namespace Desktop;

public partial class App : Application
{
    public static RestDbService RestDbService { get; private set; } = null!;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            string settingsPath = Path.Combine(
                AppContext.BaseDirectory,
                "appsettings.json"
            );

            string json = File.ReadAllText(settingsPath);

            using JsonDocument document = JsonDocument.Parse(json);

            string baseUrl = document.RootElement
                .GetProperty("RestDb")
                .GetProperty("BaseUrl")
                .GetString()!;

            string apiKey = document.RootElement
                .GetProperty("RestDb")
                .GetProperty("ApiKey")
                .GetString()!;

            RestDbService = new RestDbService(baseUrl, apiKey);

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}