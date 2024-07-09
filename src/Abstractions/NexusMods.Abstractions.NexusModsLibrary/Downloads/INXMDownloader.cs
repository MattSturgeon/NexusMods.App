using JetBrains.Annotations;
using NexusMods.Abstractions.Downloads;

namespace NexusMods.Abstractions.NexusModsLibrary;

/// <summary>
/// Represents a downloader for <see cref="INXMDownloadActivity"/>.
/// </summary>
[PublicAPI]
public interface INXMDownloader : IDownloader;
