﻿using System;
using DragonLib.IO;
using JetBrains.Annotations;
using UObject.Properties;

namespace UObject.Asset
{
    [PublicAPI]
    public class PropertyGuid : IObjectProperty
    {
        public bool HasGuid => Guid != Guid.Empty;

        public Guid Guid { get; set; } = Guid.Empty;

        public void Deserialize(Span<byte> buffer, AssetFile asset, ref int cursor)
        {
            var hasGuid = SpanHelper.ReadByte(buffer, ref cursor) == 1;
            if (hasGuid) Guid = SpanHelper.ReadStruct<Guid>(buffer, ref cursor);
        }

        public void Serialize(Span<byte> buffer, AssetFile asset, ref int cursor)
        {
            SpanHelper.WriteByte(buffer, (byte) (HasGuid ? 1 : 0), ref cursor);
            if (HasGuid) SpanHelper.WriteStruct(buffer, Guid, ref cursor);
        }
    }
}
