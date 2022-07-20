﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;


///<summary>
///See <a href="https://core.telegram.org/constructor/availableReaction" />
///</summary>
[TlObject(0xc077ec01)]
public class TAvailableReaction : IAvailableReaction
{
    public uint ConstructorId => 0xc077ec01;
    public BitArray Flags { get; set; } = new BitArray(32);
    public bool Inactive { get; set; }
    public bool Premium { get; set; }
    public string Reaction { get; set; }
    public string Title { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument StaticIcon { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument AppearAnimation { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument SelectAnimation { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument ActivateAnimation { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument EffectAnimation { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument? AroundAnimation { get; set; }

    ///<summary>
    ///See <a href="https://core.telegram.org/type/Document" />
    ///</summary>
    public MyTelegram.Schema.IDocument? CenterIcon { get; set; }

    public void ComputeFlag()
    {
        if (Inactive) { Flags[0] = true; }
        if (Premium) { Flags[2] = true; }
        if (AroundAnimation != null) { Flags[1] = true; }
        if (CenterIcon != null) { Flags[1] = true; }
    }

    public void Serialize(BinaryWriter bw)
    {
        ComputeFlag();
        bw.Write(ConstructorId);
        bw.Serialize(Flags);
        bw.Serialize(Reaction);
        bw.Serialize(Title);
        StaticIcon.Serialize(bw);
        AppearAnimation.Serialize(bw);
        SelectAnimation.Serialize(bw);
        ActivateAnimation.Serialize(bw);
        EffectAnimation.Serialize(bw);
        if (Flags[1]) { AroundAnimation.Serialize(bw); }
        if (Flags[1]) { CenterIcon.Serialize(bw); }
    }

    public void Deserialize(BinaryReader br)
    {
        Flags = br.Deserialize<BitArray>();
        if (Flags[0]) { Inactive = true; }
        if (Flags[2]) { Premium = true; }
        Reaction = br.Deserialize<string>();
        Title = br.Deserialize<string>();
        StaticIcon = br.Deserialize<MyTelegram.Schema.IDocument>();
        AppearAnimation = br.Deserialize<MyTelegram.Schema.IDocument>();
        SelectAnimation = br.Deserialize<MyTelegram.Schema.IDocument>();
        ActivateAnimation = br.Deserialize<MyTelegram.Schema.IDocument>();
        EffectAnimation = br.Deserialize<MyTelegram.Schema.IDocument>();
        if (Flags[1]) { AroundAnimation = br.Deserialize<MyTelegram.Schema.IDocument>(); }
        if (Flags[1]) { CenterIcon = br.Deserialize<MyTelegram.Schema.IDocument>(); }
    }
}