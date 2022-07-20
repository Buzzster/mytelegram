﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Messages;

///<summary>
///See <a href="https://core.telegram.org/method/messages.transcribeAudio" />
///</summary>
[TlObject(0x269e9a49)]
public sealed class RequestTranscribeAudio : IRequest<MyTelegram.Schema.Messages.ITranscribedAudio>
{
    public uint ConstructorId => 0x269e9a49;

    ///<summary>
    ///See <a href="https://core.telegram.org/type/InputPeer" />
    ///</summary>
    public MyTelegram.Schema.IInputPeer Peer { get; set; }
    public int MsgId { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        Peer.Serialize(bw);
        bw.Write(MsgId);
    }

    public void Deserialize(BinaryReader br)
    {
        Peer = br.Deserialize<MyTelegram.Schema.IInputPeer>();
        MsgId = br.ReadInt32();
    }
}
