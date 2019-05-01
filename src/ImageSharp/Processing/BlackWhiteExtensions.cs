﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors.Filters;
using SixLabors.Primitives;

namespace SixLabors.ImageSharp.Processing
{
    /// <summary>
    /// Adds extensions that allow the application of black and white toning to the <see cref="Image{TPixel}"/> type.
    /// </summary>
    public static class BlackWhiteExtensions
    {
        /// <summary>
        /// Applies black and white toning to the image.
        /// </summary>
        /// <param name="source">The image this method extends.</param>
        /// <returns>The <see cref="Image{TPixel}"/>.</returns>
        public static IImageProcessingContext BlackWhite(this IImageProcessingContext source)
            => source.ApplyProcessor(new BlackWhiteProcessor());

        /// <summary>
        /// Applies black and white toning to the image.
        /// </summary>
        /// <param name="source">The image this method extends.</param>
        /// <param name="rectangle">
        /// The <see cref="Rectangle"/> structure that specifies the portion of the image object to alter.
        /// </param>
        /// <returns>The <see cref="Image{TPixel}"/>.</returns>
        public static IImageProcessingContext BlackWhite(this IImageProcessingContext source, Rectangle rectangle)
            => source.ApplyProcessor(new BlackWhiteProcessor(), rectangle);
    }
}