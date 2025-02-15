﻿namespace MyTelegram.Domain.Aggregates.PeerNotifySettings;

public class PeerNotifySettingsAggregate : SnapshotAggregateRoot<PeerNotifySettingsAggregate, PeerNotifySettingsId,
    PeerNotifySettingsSnapshot>
{
    private readonly PeerNotifySettingsState _state = new();

    public PeerNotifySettingsAggregate(PeerNotifySettingsId id) : base(id, SnapshotEveryFewVersionsStrategy.Default)
    {
        Register(_state);
    }

    protected override Task<PeerNotifySettingsSnapshot> CreateSnapshotAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(new PeerNotifySettingsSnapshot(_state.PeerNotifySettings));
    }

    protected override Task LoadSnapshotAsync(PeerNotifySettingsSnapshot snapshot,
        ISnapshotMetadata metadata,
        CancellationToken cancellationToken)
    {
        _state.LoadSnapshot(snapshot);
        return Task.CompletedTask;
    }

    public void UpdatePeerNotifySettings(RequestInfo requestInfo,
        long ownerPeerId,
        PeerType peerType,
        long peerId,
        bool? showPreviews,
        bool? silent,
        int? muteUntil,
        string? sound)
    {
        Emit(new PeerNotifySettingsUpdatedEvent(requestInfo,
            ownerPeerId,
            peerType,
            peerId,
            new ValueObjects.PeerNotifySettings(showPreviews, silent, muteUntil, sound)));
    }

}
