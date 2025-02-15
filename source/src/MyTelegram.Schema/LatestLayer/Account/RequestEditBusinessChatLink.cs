﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Account;

///<summary>
/// See <a href="https://corefork.telegram.org/method/account.editBusinessChatLink" />
///</summary>
[TlObject(0x8c3410af)]
public sealed class RequestEditBusinessChatLink : IRequest<MyTelegram.Schema.IBusinessChatLink>
{
    public uint ConstructorId => 0x8c3410af;
    public string Slug { get; set; }
    public MyTelegram.Schema.IInputBusinessChatLink Link { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Slug);
        writer.Write(Link);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Slug = reader.ReadString();
        Link = reader.Read<MyTelegram.Schema.IInputBusinessChatLink>();
    }
}
