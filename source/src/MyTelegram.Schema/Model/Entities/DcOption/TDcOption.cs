﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/dcOption" />
///</summary>
[TlObject(0x18b7a10d)]
public class TDcOption : IDcOption
{
    public uint ConstructorId => 0x18b7a10d;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Ipv6 { get; set; }
    public bool MediaOnly { get; set; }
    public bool TcpoOnly { get; set; }
    public bool Cdn { get; set; }
    public bool Static { get; set; }
    public bool ThisPortOnly { get; set; }
    public int Id { get; set; }
    public string IpAddress { get; set; }
    public int Port { get; set; }
    public byte[]? Secret { get; set; }

    public void ComputeFlag()
    {
        if (Ipv6) { Flags[0] = true; }
        if (MediaOnly) { Flags[1] = true; }
        if (TcpoOnly) { Flags[2] = true; }
        if (Cdn) { Flags[3] = true; }
        if (Static) { Flags[4] = true; }
        if (ThisPortOnly) { Flags[5] = true; }
        if (Secret != null) { Flags[10] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Write(Id);
        bw.Serialize(IpAddress);
        bw.Write(Port);
        if (Flags[10]) { bw.Serialize(Secret); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Ipv6 = true; }
        if (Flags[1]) { MediaOnly = true; }
        if (Flags[2]) { TcpoOnly = true; }
        if (Flags[3]) { Cdn = true; }
        if (Flags[4]) { Static = true; }
        if (Flags[5]) { ThisPortOnly = true; }
        Id = br.ReadInt32();
        IpAddress = br.Deserialize<string>();
        Port = br.ReadInt32();
        if (Flags[10]) { Secret = br.Deserialize<byte[]>(); }
    }
}