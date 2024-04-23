using JetBrains.Annotations;

namespace NexusMods.Abstractions.Settings;

/// <summary>
/// Represents a value container.
/// </summary>
[PublicAPI]
public interface IValueContainer
{
    /// <summary>
    /// Gets whether the value has changed.
    /// </summary>
    bool HasChanged { get; }

    /// <summary>
    /// Updates the value in the settings manager.
    /// </summary>
    void Update(ISettingsManager settingsManager);
}
