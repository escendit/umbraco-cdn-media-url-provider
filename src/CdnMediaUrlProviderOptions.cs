// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Escendit.Umbraco.MediaUrlProviders.Cdn;

/// <summary>
/// S3 Media Url Provider Options.
/// </summary>
public class CdnMediaUrlProviderOptions
{
    /// <summary>
    /// Gets or sets the uri.
    /// </summary>
    /// <value>The S3 base uri.</value>
    public Uri? Uri { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether remove media from path.
    /// </summary>
    /// <value>
    ///     <c>true</c> if <c>/media/</c> needs to be removed from the path; otherwise <c>false</c>.
    /// </value>
    public bool RemoveMediaFromPath { get; set; } = true;
}
