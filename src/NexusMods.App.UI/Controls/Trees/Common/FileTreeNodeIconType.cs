using System.Runtime.CompilerServices;
using NexusMods.Paths;
using NexusMods.Paths.Utilities;
using NexusMods.Paths.Utilities.Enums;

namespace NexusMods.App.UI.Controls.Trees.Common;

public enum FileTreeNodeIconType
{
    /// <summary>
    ///     Shows a regular 'file' icon.
    ///     This is for any file that doesn't fall into the other categories.
    /// </summary>
    File,
    
    /// <summary>
    ///     Show a 'closed folder' icon.
    /// </summary>
    ClosedFolder,
    
    /// <summary>
    ///     Show an 'open folder' icon.
    /// </summary>
    OpenFolder,
    
    /// <summary>
    ///     This is a file which is an Image.
    /// </summary>
    Image,
    
    /// <summary>
    ///     This is a file which is text.
    /// </summary>
    Text,
    
    /// <summary>
    ///     This is a file which contains music or speech.
    /// </summary>
    Audio,
    
    /// <summary>
    ///     This shows movies.
    /// </summary>
    Video,
}

public static class FileTreeNodeIconTypeHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FileTreeNodeIconType GetIconType(this Extension extension)
    {
        var category = extension.GetCategory();
        return GetIconType(category);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static FileTreeNodeIconType GetIconType(this ExtensionCategory category) => category switch
    {
        // Images
        ExtensionCategory.Image => FileTreeNodeIconType.Image,

        // Text
        ExtensionCategory.Script => FileTreeNodeIconType.Text,
        ExtensionCategory.Text => FileTreeNodeIconType.Text,
        
        // Audio
        ExtensionCategory.Audio => FileTreeNodeIconType.Audio,
        ExtensionCategory.ArchiveOfAudio => FileTreeNodeIconType.Audio,
 
        // Video
        ExtensionCategory.Video => FileTreeNodeIconType.Video,
        
        // Files (Other)
        ExtensionCategory.Unknown => FileTreeNodeIconType.File,
        ExtensionCategory.Model => FileTreeNodeIconType.File,
        ExtensionCategory.Archive => FileTreeNodeIconType.File,
        ExtensionCategory.ArchiveOfImage => FileTreeNodeIconType.File,
        ExtensionCategory.Binary => FileTreeNodeIconType.File,
        ExtensionCategory.Library => FileTreeNodeIconType.File,
        ExtensionCategory.Database => FileTreeNodeIconType.File,
        ExtensionCategory.Executable => FileTreeNodeIconType.File,
        _ => FileTreeNodeIconType.File,
    };
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetIconClass(this FileTreeNodeIconType iconType) => iconType switch
    {
        FileTreeNodeIconType.File => "File",
        FileTreeNodeIconType.ClosedFolder => "FolderOutline",
        FileTreeNodeIconType.OpenFolder => "FolderOpenOutline",
        FileTreeNodeIconType.Image => "Image",
        FileTreeNodeIconType.Text => "FileDocumentOutline",
        FileTreeNodeIconType.Audio => "MusicNote",
        FileTreeNodeIconType.Video => "VideoOutline",
        _ => ThrowArgumentOutOfRangeException(iconType),
    };
    
    private static string ThrowArgumentOutOfRangeException(FileTreeNodeIconType iconType) => throw new ArgumentOutOfRangeException(nameof(iconType), iconType, null);
}
