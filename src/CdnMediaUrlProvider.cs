// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Escendit.Umbraco.MediaUrlProviders.Cdn;

using global::Umbraco.Cms.Core.PropertyEditors;
using global::Umbraco.Cms.Core.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

/// <inheritdoc />
public class CdnMediaUrlProvider : DefaultMediaUrlProvider
{
    private readonly IOptionsMonitor<CdnMediaUrlProviderOptions> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="CdnMediaUrlProvider"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="mediaPathGenerators">The media path generators.</param>
    /// <param name="uriUtility">The <see cref="Uri"/> utility.</param>
    /// <param name="urlAssembler">The <see cref="IUrlAssembler"/>.</param>
    [ActivatorUtilitiesConstructor]
    public CdnMediaUrlProvider(
        IOptionsMonitor<CdnMediaUrlProviderOptions> options,
        MediaUrlGeneratorCollection mediaPathGenerators,
        UriUtility uriUtility,
        IUrlAssembler urlAssembler)
        : base(mediaPathGenerators, uriUtility, urlAssembler)
    {
        ArgumentNullException.ThrowIfNull(options);
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CdnMediaUrlProvider"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    /// <param name="mediaPathGenerators">The media path generators.</param>
    /// <param name="uriUtility">The <see cref="UriUtility"/>.</param>
    [Obsolete("To be removed in Umbraco v15")]
    public CdnMediaUrlProvider(
        IOptionsMonitor<CdnMediaUrlProviderOptions> options,
        MediaUrlGeneratorCollection mediaPathGenerators,
        UriUtility uriUtility)
        : base(mediaPathGenerators, uriUtility)
    {
        _options = options;
    }

    /// <inheritdoc/>
    public override UrlInfo? GetMediaUrl(
        global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent content,
        string propertyAlias,
        global::Umbraco.Cms.Core.Models.PublishedContent.UrlMode mode,
        string? culture,
        Uri current)
    {
        var mediaUrl = base.GetMediaUrl(content, propertyAlias, mode, culture, current);

        if (mediaUrl is null)
        {
            return null;
        }

        return mediaUrl.IsUrl switch
        {
            false => mediaUrl,
            _ => UrlInfo.Url($"{_options.CurrentValue.Uri}/{mediaUrl.Text[(_options.CurrentValue.RemoveMediaFromPath ? "/media/" : "/").Length..]}", culture),
        };
    }
}
