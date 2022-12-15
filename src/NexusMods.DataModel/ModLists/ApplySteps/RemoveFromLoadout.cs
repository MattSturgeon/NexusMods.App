﻿using NexusMods.Hashing.xxHash64;
using NexusMods.Paths;

namespace NexusMods.DataModel.ModLists.ApplySteps;

public record RemoveFromLoadout : IApplyStep
{
    public required AbsolutePath To { get; init; }
}