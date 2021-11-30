// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Processing.Processors.Transforms
{
    /// <summary>
    /// Applies the orientation in EXIF metadata and adjusts an image so that its orientation is suitable for viewing.
    /// </summary>
    public sealed class ReOrientProcessor : IImageProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReOrientProcessor"/> class.
        /// </summary>
        /// <param name="orientation">The orientation.</param>
        public ReOrientProcessor(OrientationMode orientation) => this.Orientation = orientation;

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        public OrientationMode Orientation { get; }

        /// <inheritdoc />
        public IImageProcessor<TPixel> CreatePixelSpecificProcessor<TPixel>(Configuration configuration, Image<TPixel> source, Rectangle sourceRectangle)
            where TPixel : unmanaged, IPixel<TPixel>
            => new ReOrientProcessor<TPixel>(configuration, this, source, sourceRectangle);
    }
}
