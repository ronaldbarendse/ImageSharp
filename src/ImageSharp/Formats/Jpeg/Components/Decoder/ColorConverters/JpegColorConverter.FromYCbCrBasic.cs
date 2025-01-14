﻿// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Numerics;

namespace SixLabors.ImageSharp.Formats.Jpeg.Components.Decoder.ColorConverters
{
    internal abstract partial class JpegColorConverter
    {
        internal sealed class FromYCbCrBasic : BasicJpegColorConverter
        {
            public FromYCbCrBasic(int precision)
                : base(JpegColorSpace.YCbCr, precision)
            {
            }

            public override void ConvertToRgbInplace(in ComponentValues values)
                => ConvertCoreInplace(values, this.MaximumValue, this.HalfValue);

            internal static void ConvertCoreInplace(in ComponentValues values, float maxValue, float halfValue)
            {
                Span<float> c0 = values.Component0;
                Span<float> c1 = values.Component1;
                Span<float> c2 = values.Component2;

                var scale = 1 / maxValue;

                for (int i = 0; i < c0.Length; i++)
                {
                    float y = c0[i];
                    float cb = c1[i] - halfValue;
                    float cr = c2[i] - halfValue;

                    c0[i] = MathF.Round(y + (1.402F * cr), MidpointRounding.AwayFromZero) * scale;
                    c1[i] = MathF.Round(y - (0.344136F * cb) - (0.714136F * cr), MidpointRounding.AwayFromZero) * scale;
                    c2[i] = MathF.Round(y + (1.772F * cb), MidpointRounding.AwayFromZero) * scale;
                }
            }
        }
    }
}
