﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.requestWebView" />
///</summary>
[TlObject(0x91b15831)]
public sealed class RequestRequestWebView : IRequest<MyTelegram.Schema.IWebViewResult>
{
    public uint ConstructorId => 0x91b15831;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool FromBotMenu { get; set; }
    public bool Silent { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser Bot { get; set; }
    public string? Url { get; set; }
    public string? StartParam { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/DataJSON" />
    ///</summary>
    public MyTelegram.Schema.IDataJSON? ThemeParams { get; set; }
    public int? ReplyToMsgId { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer? SendAs { get; set; }

    public void ComputeFlag()
    {
        if (FromBotMenu) { Flags[4] = true; }
        if (Silent) { Flags[5] = true; }
        if (Url != null) { Flags[1] = true; }
        if (StartParam != null) { Flags[3] = true; }
        if (ThemeParams != null) { Flags[2] = true; }
        if (ReplyToMsgId != 0 && ReplyToMsgId.HasValue) { Flags[0] = true; }
        if (SendAs != null) { Flags[13] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        Peer.Serialize(bw);
        Bot.Serialize(bw);
        if (Flags[1]) { bw.Serialize(Url); }
        if (Flags[3]) { bw.Serialize(StartParam); }
        if (Flags[2]) { ThemeParams.Serialize(bw); }
        if (Flags[0]) { bw.Write(ReplyToMsgId.Value); }
        if (Flags[13]) { SendAs.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[4]) { FromBotMenu = true; }
        if (Flags[5]) { Silent = true; }
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        Bot = br.Deserialize<MyTelegram.Schema.IInputUser>();
        if (Flags[1]) { Url = br.Deserialize<string>(); }
        if (Flags[3]) { StartParam = br.Deserialize<string>(); }
        if (Flags[2]) { ThemeParams = br.Deserialize<MyTelegram.Schema.IDataJSON>(); }
        if (Flags[0]) { ReplyToMsgId = br.ReadInt32(); }
        if (Flags[13]) { SendAs = br.Deserialize<MyTelegram.Schema.IInputPeer>(); }
    }
}
