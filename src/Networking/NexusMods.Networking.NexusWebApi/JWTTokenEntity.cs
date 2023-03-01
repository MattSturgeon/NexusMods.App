﻿using NexusMods.DataModel.Abstractions;
using NexusMods.DataModel.JsonConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMods.Networking.NexusWebApi;

/// <summary>
/// entity to store a JWT token
/// TODO: Right now we follow a "ask for forgiveness, not permission" approach to using the token,
///   so we use the access token until we get an error indicating it has expired, then refresh the
///   token and retry. This way we don't need to store when the token expires even though we have
///   that information. If we wanted to save one request every six hours or if the lifetime of access tokens
///   changes, we might want to refresh tokens more proactively and then we'd need to save the expire time.
/// </summary>
[JsonName("JWTTokens")]
public record JWTTokenEntity : Entity
{
    /// <inheritdoc/>
    public static readonly Id StoreId = new IdVariableLength(EntityCategory.AuthData, "NexusMods.Networking.NexusWebApi.JWTTokens"u8.ToArray());

    /// <inheritdoc/>
    public override EntityCategory Category => EntityCategory.AuthData;

    /// <summary>
    /// the current access token
    /// </summary>
    public required string AccessToken { get; init; }

    /// <summary>
    /// token needed to generate a new access token when the current one has expired.
    /// </summary>
    public required string RefreshToken { get; init; }
}

