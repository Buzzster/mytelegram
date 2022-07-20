﻿// ReSharper disable All

namespace MyTelegram.Schema.Help;

public interface IPremiumPromo : IObject
{
    string StatusText { get; set; }
    TVector<MyTelegram.Schema.IMessageEntity> StatusEntities { get; set; }
    TVector<string> VideoSections { get; set; }
    TVector<MyTelegram.Schema.IDocument> Videos { get; set; }
    string Currency { get; set; }
    long MonthlyAmount { get; set; }
    TVector<MyTelegram.Schema.IUser> Users { get; set; }

}
