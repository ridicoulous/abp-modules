﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;

namespace Passingwind.Abp.Account;

[RemoteService(Name = AccountRemoteServiceConsts.RemoteServiceName)]
[Area(AccountRemoteServiceConsts.ModuleName)]
[Route("api/account")]
public class AccountController : AbpControllerBase, IAccountV2AppService
{
    protected IAccountV2AppService AccountAppService { get; }

    public AccountController(IAccountV2AppService accountAppService)
    {
        AccountAppService = accountAppService;
    }

    [HttpPost]
    [Route("register")]
    public virtual Task<IdentityUserDto> RegisterAsync(RegisterDto input)
    {
        return AccountAppService.RegisterAsync(input);
    }

    [HttpPost]
    [Route("send-password-reset-code")]
    public virtual Task SendPasswordResetCodeAsync(SendPasswordResetCodeDto input)
    {
        return AccountAppService.SendPasswordResetCodeAsync(input);
    }

    [HttpPost]
    [Route("reset-password")]
    public virtual Task ResetPasswordAsync(ResetPasswordDto input)
    {
        return AccountAppService.ResetPasswordAsync(input);
    }

    [HttpPost]
    [Route("verify-password-reset-token")]
    public virtual Task<AccountVerifyPasswordResetTokenResultDto> VerifyPasswordResetTokenV2Async(VerifyPasswordResetTokenInput input)
    {
        return AccountAppService.VerifyPasswordResetTokenV2Async(input);
    }

    [NonAction]
    public virtual Task<bool> VerifyPasswordResetTokenAsync(VerifyPasswordResetTokenInput input)
    {
        return AccountAppService.VerifyPasswordResetTokenAsync(input);
    }
}
