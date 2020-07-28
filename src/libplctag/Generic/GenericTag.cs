﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace libplctag.Generic
{
    public class GenericTag<TPlcType, TDotNetType> : ITag, IGenericTag<TDotNetType> where TPlcType : IPlcType<TDotNetType>, new()
    {

        private readonly TPlcType plcDataType;
        private readonly Tag tag;

        public GenericTag(AttributeGroup attributeGroup = default)
        {
            //Instantiate our definition
            //TODO: These could be singleton or a private static lookup for performance

            plcDataType = new TPlcType();

            this.tag = new Tag(attributeGroup)
            {
                ElementSize = plcDataType.ElementSize
            };

        }

        public TDotNetType Value { get => plcDataType.Decode(tag); set => plcDataType.Encode(tag, value); }
        public byte CipCode => plcDataType.CipCode;

        public void Initialize(int timeout) => tag.Initialize(timeout);
        public Task InitializeAsync(int millisecondTimeout, CancellationToken token = default) => tag.InitializeAsync(millisecondTimeout, token);
        public Task InitializeAsync(CancellationToken token = default) => tag.InitializeAsync(token);

        public void Read(int timeout) => tag.Read(timeout);
        public Task ReadAsync(int millisecondTimeout, CancellationToken token = default) => tag.ReadAsync(millisecondTimeout, token);
        public Task ReadAsync(CancellationToken token = default) => tag.ReadAsync(token);

        public void Write(int timeout) => tag.Write(timeout);
        public Task WriteAsync(int millisecondTimeout, CancellationToken token = default) => tag.WriteAsync(millisecondTimeout, token);
        public Task WriteAsync(CancellationToken token = default) => tag.WriteAsync(token);

        public void Abort() => ((ITag)tag).Abort();

        public void Dispose() => ((ITag)tag).Dispose();

        public int GetSize() => ((ITag)tag).GetSize();

        public Status GetStatus() => ((ITag)tag).GetStatus();

        public PlcType? PlcType
        {
            get => ((ITag)tag).PlcType;
            set => ((ITag)tag).PlcType = value;
        }

        public int? ElementCount
        {
            get => ((ITag)tag).ElementCount;
            set => ((ITag)tag).ElementCount = value;
        }

        public int? ElementSize
        {
            get => ((ITag)tag).ElementSize;
            set => ((ITag)tag).ElementSize = value;
        }

        public string Gateway
        {
            get => ((ITag)tag).Gateway;
            set => ((ITag)tag).Gateway = value;
        }

        public string Name
        {
            get => ((ITag)tag).Name;
            set => ((ITag)tag).Name = value;
        }

        public string Path
        {
            get => ((ITag)tag).Path;
            set => ((ITag)tag).Path = value;
        }

        public Protocol? Protocol
        {
            get => ((ITag)tag).Protocol;
            set => ((ITag)tag).Protocol = value;
        }

        public int? ReadCacheMillisecondDuration
        {
            get => ((ITag)tag).ReadCacheMillisecondDuration;
            set => ((ITag)tag).ReadCacheMillisecondDuration = value;
        }

        public bool? UseConnectedMessaging
        {
            get => ((ITag)tag).UseConnectedMessaging;
            set => ((ITag)tag).UseConnectedMessaging = value;
        }

    }

}
