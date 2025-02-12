using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Server;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

[ApiController]
[Route("api/features")]
public class FeatureController : ControllerBase
{
    private readonly LdClient _ldClient;

    public FeatureController(LdClient ldClient)
    {
        _ldClient = ldClient;
    }

    [HttpGet("new-feature/{userKey}")]
    public IActionResult GetFeatureStatus(string userKey)
    {
        // Replace with your feature flag key
        string featureFlagKey = "new-feature";
        var context = Context.Builder(userKey).Build();
        // Check if the feature flag is enabled
        bool isFeatureEnabled = _ldClient.BoolVariation(featureFlagKey, context);

        if (isFeatureEnabled)
        {
            return Ok(new { message = "New Feature is ENABLED!" });
        }
        else
        {
            return Ok(new { message = "New Feature is DISABLED!" });
        }
    }
}
