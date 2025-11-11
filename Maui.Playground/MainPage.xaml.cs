using System;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;
using Mindscape.Raygun4Net;
using Raygun4Maui;

namespace Maui.Playground;

public partial class MainPage : ContentPage
{
    int count = 0;

    private ILogger _logger;

    public MainPage(ILogger<MainPage> logger, IRaygunMauiUserProvider userProvider)
    {
        InitializeComponent();
        
        _logger = logger;
        
        Console.WriteLine(userProvider);
        Console.WriteLine("Hello World!");
        
        userProvider.SetUser(new RaygunIdentifierMessage("Test User"));
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";
        
        Console.WriteLine(RaygunMauiClient.Current);

        throw new Exception("This is an error");
        
        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}