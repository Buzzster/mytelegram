﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Help;

///<summary>
///See <a href="https://core.telegram.org/method/help.getPremiumPromo" />
///</summary>
[TlObject(0xb81b93d4)]
public sealed class RequestGetPremiumPromo : IRequest<MyTelegram.Schema.Help.IPremiumPromo>
{
    public uint ConstructorId => 0xb81b93d4;

    public void ComputeFlag()
    {

    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);

    }

    public void Deserialize(BinaryReader br)
    {

    }
}
