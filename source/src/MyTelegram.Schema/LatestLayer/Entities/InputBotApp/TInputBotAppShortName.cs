﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema;

///<summary>
/// Used to fetch information about a <a href="https://corefork.telegram.org/api/bots/webapps#direct-link-mini-apps">direct link Mini App</a> by its short name
/// See <a href="https://corefork.telegram.org/constructor/inputBotAppShortName" />
///</summary>
[TlObject(0x908c0407)]
public sealed class TInputBotAppShortName : IInputBotApp
{
    public uint ConstructorId => 0x908c0407;
    ///<summary>
    /// ID of the bot that owns the bot mini app
    /// See <a href="https://corefork.telegram.org/type/InputUser" />
    ///</summary>
    public MyTelegram.Schema.IInputUser BotId { get; set; }

    ///<summary>
    /// Short name, obtained from a <a href="https://corefork.telegram.org/api/links#direct-mini-app-links">Direct Mini App deep link</a>
    ///</summary>
    public string ShortName { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(BotId);
        writer.Write(ShortName);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        BotId = reader.Read<MyTelegram.Schema.IInputUser>();
        ShortName = reader.ReadString();
    }
}