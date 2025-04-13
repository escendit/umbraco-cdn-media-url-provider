// Copyright (c) Escendit Ltd. All Rights Reserved.
// Licensed under the MIT. See LICENSE.txt file in the solution root for full license information.

namespace Umbraco.Cms.Core.DependencyInjection;

using Escendit.Umbraco.MediaUrlProviders.Cdn;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Umbraco Builder Extensions.
/// </summary>
public static class UmbracoBuilderExtensions
{
    /// <summary>
    /// Registers and configures the <see cref="CdnMediaUrlProvider" />.
    /// </summary>
    /// <param name="builder">The <see cref="IUmbracoBuilder" />.</param>
    /// <returns>
    /// The passed <see cref="IUmbracoBuilder" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">builder.</exception>
    public static IUmbracoBuilder AddCdnMediaUrlProvider(this IUmbracoBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder
            .Services
            .AddOptions<CdnMediaUrlProviderOptions>()
            .BindConfiguration("Umbraco:Storage:Cdn:Media")
            .ValidateDataAnnotations();

        builder
            .MediaUrlProviders()
            .Insert<CdnMediaUrlProvider>();

        return builder;
    }

    /// <summary>
    /// Registers and configures the <see cref="CdnMediaUrlProvider" />.
    /// </summary>
    /// <param name="builder">The initial <see cref="IUmbracoBuilder" />.</param>
    /// <param name="configure">An action used to configure the <see cref="CdnMediaUrlProviderOptions" />.</param>
    /// <returns>
    /// The updated <see cref="IUmbracoBuilder" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">builder or configure.</exception>
    public static IUmbracoBuilder AddCdnMediaUrlProvider(this IUmbracoBuilder builder, Action<CdnMediaUrlProviderOptions> configure)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configure);

        AddCdnMediaUrlProvider(builder);

        builder
            .Services
            .AddOptions<CdnMediaUrlProviderOptions>()
            .Configure(configure);

        return builder;
    }

    /// <summary>
    /// Registers and configures the <see cref="CdnMediaUrlProvider" />.
    /// </summary>
    /// <param name="builder">The <see cref="IUmbracoBuilder" />.</param>
    /// <param name="configure">An action used to configure the <see cref="CdnMediaUrlProviderOptions" />.</param>
    /// <returns>
    /// The passed <see cref="IUmbracoBuilder" />.
    /// </returns>
    /// <exception cref="ArgumentNullException">builder or configure.</exception>
    public static IUmbracoBuilder AddCdnMediaUrlProvider(this IUmbracoBuilder builder, Action<CdnMediaUrlProviderOptions, IServiceProvider> configure)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(configure);

        AddCdnMediaUrlProvider(builder);

        builder
            .Services
            .AddOptions<CdnMediaUrlProviderOptions>()
            .Configure(configure);

        return builder;
    }
}
