﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/attachMenuPeerTypeBotPM" />
///</summary>
[TlObject(0xc32bfa1a)]
public class TAttachMenuPeerTypeBotPM : IAttachMenuPeerType
{
    public uint ConstructorId => 0xc32bfa1a;


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