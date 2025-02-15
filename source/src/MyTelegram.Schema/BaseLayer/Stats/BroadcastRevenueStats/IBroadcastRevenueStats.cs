﻿// ReSharper disable All

namespace MyTelegram.Schema.Stats;

///<summary>
/// See <a href="https://corefork.telegram.org/constructor/stats.BroadcastRevenueStats" />
///</summary>
[JsonDerivedType(typeof(TBroadcastRevenueStats), nameof(TBroadcastRevenueStats))]
public interface IBroadcastRevenueStats : IObject
{
    MyTelegram.Schema.IStatsGraph TopHoursGraph { get; set; }
    MyTelegram.Schema.IStatsGraph RevenueGraph { get; set; }
    long CurrentBalance { get; set; }
    long AvailableBalance { get; set; }
    long OverallRevenue { get; set; }
    double UsdRate { get; set; }
}
