﻿using System;
using System.Diagnostics;
using System.Globalization;
using DragonLib.IO;
using JetBrains.Annotations;
using UObject.Asset;
using UObject.Enum;
using UObject.JSON;

namespace UObject.Properties
{
    // TODO: Validate if GUID is BEFORE or AFTER Value.
    [PublicAPI]
    public class FloatProperty : AbstractGuidProperty, IValueType<float>
    {
        public float Value { get; set; }

        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);

        public override void Deserialize(Span<byte> buffer, AssetFile asset, ref int cursor, SerializationMode mode)
        {
            base.Deserialize(buffer, asset, ref cursor, mode);
            Value = SpanHelper.ReadLittleSingle(buffer, ref cursor);
        }

        public override void Serialize(ref Memory<byte> buffer, AssetFile asset, ref int cursor, SerializationMode mode)
        {
            base.Serialize(ref buffer, asset, ref cursor, mode);
            SpanHelper.WriteLittleSingle(ref buffer, Value, ref cursor);
        }
    }
}
