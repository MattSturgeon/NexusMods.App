using JetBrains.Annotations;
using NexusMods.Icons;

namespace NexusMods.Abstractions.Settings;

/// <summary>
/// Represents a section.
/// </summary>
[PublicAPI]
public interface ISettingsSectionDescriptor
{
    /// <summary>
    /// Gets the ID.
    /// </summary>
    SectionId Id { get; }

    /// <summary>
    /// Gets the Name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Gets the Icon.
    /// </summary>
    IconValue Icon { get; }
}
