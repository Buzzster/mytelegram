﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Upload;

///<summary>
///See <a href="https://core.telegram.org/method/upload.getFile" />
///</summary>
[TlObject(0xbe5335be)]
public sealed class RequestGetFile : IRequest<MyTelegram.Schema.Upload.IFile>
{
    public uint ConstructorId => 0xbe5335be;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Precise { get; set; }
    public bool CdnSupported { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputFileLocation" />
    ///</summary>
    public MyTelegram.Schema.IInputFileLocation Location { get; set; }
    public long Offset { get; set; }
    public int Limit { get; set; }

    public void ComputeFlag()
    {
        if (Precise) { Flags[0] = true; }
        if (CdnSupported) { Flags[1] = true; }

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Location.Serialize(bw);
        bw.Write(Offset);
        bw.Write(Limit);
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Precise = true; }
        if (Flags[1]) { CdnSupported = true; }
        Location = br.Deserialize<MyTelegram.Schema.IInputFileLocation>();
        Offset = br.ReadInt64();
        Limit = br.ReadInt32();
    }
}
