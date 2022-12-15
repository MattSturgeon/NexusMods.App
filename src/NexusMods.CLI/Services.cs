﻿using Microsoft.Extensions.DependencyInjection;
using NexusMods.CLI.OptionParsers;
using NexusMods.DataModel;
using NexusMods.DataModel.ModLists;
using NexusMods.DataModel.ModLists.Markers;
using NexusMods.DataModel.RateLimiting;
using NexusMods.FileExtractor;
using NexusMods.FileExtractor.Extractors;
using NexusMods.Interfaces;
using NexusMods.Interfaces.Components;
using NexusMods.Paths;

namespace NexusMods.CLI;

public static class Services
{
    public static IServiceCollection AddCLI(this IServiceCollection services)
    {
        services.AddScoped<Configurator>();
        services.AddScoped<CommandLineBuilder>();
        services.AddSingleton<IOptionParser<AbsolutePath>, AbsolutePathParser>();
        services.AddSingleton<IOptionParser<IGame>, GameParser>();
        services.AddSingleton<IOptionParser<ModListMarker>, ModListMarkerParser>();
        services.AddSingleton<IOptionParser<Version>, VersionParser>();
        services.AddSingleton<IOptionParser<ModList>, ModListParser>();
        services.AddSingleton<TemporaryFileManager>();
        
        services.AddAllSingleton<IResource, IResource<IExtractor, Size>>(s => new Resource<IExtractor, Size>("File Extraction"));
        services.AddAllSingleton<IResource, IResource<ArchiveContentsCache, Size>>(s => new Resource<ArchiveContentsCache, Size>("File Analysis"));
        services.AddFileExtractors();
        services.AddDataModel();
        return services;
    }
    
}