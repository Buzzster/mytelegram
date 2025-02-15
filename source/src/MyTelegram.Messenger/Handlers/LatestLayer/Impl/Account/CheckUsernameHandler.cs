﻿// ReSharper disable All

namespace MyTelegram.Handlers.Account;

///<summary>
/// Validates a username and checks availability.
/// <para>Possible errors</para>
/// Code Type Description
/// 400 USERNAME_INVALID The provided username is not valid.
/// 400 USERNAME_OCCUPIED The provided username is already occupied.
/// 400 USERNAME_PURCHASE_AVAILABLE The specified username can be purchased on <a href="https://fragment.com/">https://fragment.com</a>.
/// See <a href="https://corefork.telegram.org/method/account.checkUsername" />
///</summary>
internal sealed class CheckUsernameHandler(IQueryProcessor queryProcessor)
    : RpcResultObjectHandler<MyTelegram.Schema.Account.RequestCheckUsername, IBool>,
        Account.ICheckUsernameHandler
{
    protected override async Task<IBool> HandleCoreAsync(IRequestInput input,
        MyTelegram.Schema.Account.RequestCheckUsername obj)
    {
        var userNameReadModel = await queryProcessor.ProcessAsync(new GetUserNameByNameQuery(obj.Username));
        if (userNameReadModel == null)
        {
            return new TBoolTrue();
        }

        return new TBoolFalse();
    }
}
