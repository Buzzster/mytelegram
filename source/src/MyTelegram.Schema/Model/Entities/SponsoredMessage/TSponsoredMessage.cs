﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/sponsoredMessage" />
///</summary>
[TlObject(0x3a836df8)]
public class TSponsoredMessage : ISponsoredMessage
{
    public uint ConstructorId => 0x3a836df8;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Recommended { get; set; }
    public byte[] RandomId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Peer" />
    ///</summary>
    public MyTelegram.Schema.IPeer? FromId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/ChatInvite" />
    ///</summary>
    public MyTelegram.Schema.IChatInvite? ChatInvite { get; set; }
    public string? ChatInviteHash { get; set; }
    public int? ChannelPost { get; set; }
    public string? StartParam { get; set; }
    public string Message { get; set; }
    public TVector<MyTelegram.Schema.IMessageEntity>? Entities { get; set; }

    public void ComputeFlag()
    {
        if (Recommended) { Flags[5] = true; }
        if (FromId != null) { Flags[3] = true; }
        if (ChatInvite != null) { Flags[4] = true; }
        if (ChatInviteHash != null) { Flags[4] = true; }
        if (ChannelPost != 0 && ChannelPost.HasValue) { Flags[2] = true; }
        if (StartParam != null) { Flags[0] = true; }
        if (Entities?.Count > 0) { Flags[1] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Serialize(RandomId);
        if (Flags[3]) { FromId.Serialize(bw); }
        if (Flags[4]) { ChatInvite.Serialize(bw); }
        if (Flags[4]) { bw.Serialize(ChatInviteHash); }
        if (Flags[2]) { bw.Write(ChannelPost.Value); }
        if (Flags[0]) { bw.Serialize(StartParam); }
        bw.Serialize(Message);
        if (Flags[1]) { Entities.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[5]) { Recommended = true; }
        RandomId = br.Deserialize<byte[]>();
        if (Flags[3]) { FromId = br.Deserialize<MyTelegram.Schema.IPeer>(); }
        if (Flags[4]) { ChatInvite = br.Deserialize<MyTelegram.Schema.IChatInvite>(); }
        if (Flags[4]) { ChatInviteHash = br.Deserialize<string>(); }
        if (Flags[2]) { ChannelPost = br.ReadInt32(); }
        if (Flags[0]) { StartParam = br.Deserialize<string>(); }
        Message = br.Deserialize<string>();
        if (Flags[1]) { Entities = br.Deserialize<TVector<MyTelegram.Schema.IMessageEntity>>(); }
    }
}