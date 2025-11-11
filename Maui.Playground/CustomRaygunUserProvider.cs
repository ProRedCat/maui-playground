using Raygun4Maui;

namespace Maui.Playground;

using Mindscape.Raygun4Net;
using Raygun4Maui.AppEvents;

public class CustomRaygunMauiUserProvider : IRaygunMauiUserProvider
{
    private RaygunIdentifierMessage? _current;
    private readonly object _lock = new();

    public CustomRaygunMauiUserProvider()
    {
        System.Diagnostics.Debug.WriteLine(
            "[CustomRaygunMauiUserProvider] Constructor called - provider instance created"
        );
    }

    public RaygunIdentifierMessage GetUser()
    {
        lock (_lock)
        {
            return _current;
        }
    }

    public void SetUser(RaygunIdentifierMessage message)
    {
        message!.Email = "reilly.oldham@gmail.com";
        
        lock (_lock)
        {
            _current = message;
            RaygunAppEventPublisher.Publish(
                new RaygunUserChanged { User = message }
            );
        }
    }
}
