﻿// <auto-generated/>
// ReSharper disable All

namespace MyTelegram.Schema.Channels;

///<summary>
/// Pin or unpin <a href="https://corefork.telegram.org/api/forum">forum topics</a>
/// <para>Possible errors</para>
/// Code Type Description
/// 400 TOPIC_ID_INVALID The specified topic ID is invalid.
/// See <a href="https://corefork.telegram.org/method/channels.updatePinnedForumTopic" />
///</summary>
[TlObject(0x6c2d9026)]
public sealed class RequestUpdatePinnedForumTopic : IRequest<MyTelegram.Schema.IUpdates>
{
    public uint ConstructorId => 0x6c2d9026;
    ///<summary>
    /// Supergroup ID
    /// See <a href="https://corefork.telegram.org/type/InputChannel" />
    ///</summary>
    public MyTelegram.Schema.IInputChannel Channel { get; set; }

    ///<summary>
    /// <a href="https://corefork.telegram.org/api/forum">Forum topic ID</a>
    ///</summary>
    public int TopicId { get; set; }

    ///<summary>
    /// Whether to pin or unpin the topic
    /// See <a href="https://corefork.telegram.org/type/Bool" />
    ///</summary>
    public bool Pinned { get; set; }

    public void ComputeFlag()
    {

    }

    public void Serialize(IBufferWriter<byte> writer)
    {
        ComputeFlag();
        writer.Write(ConstructorId);
        writer.Write(Channel);
        writer.Write(TopicId);
        writer.Write(Pinned);
    }

    public void Deserialize(ref SequenceReader<byte> reader)
    {
        Channel = reader.Read<MyTelegram.Schema.IInputChannel>();
        TopicId = reader.ReadInt32();
        Pinned = reader.Read();
    }
}
