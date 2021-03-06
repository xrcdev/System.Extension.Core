﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using EInfrastructure.Core.Aliyun.Storage.Config;
using EInfrastructure.Core.Configuration.Ioc.Plugs.Storage.Params.Storage;
using FluentValidation;

namespace EInfrastructure.Core.Aliyun.Storage.Validator.Storage
{
    /// <summary>
    ///
    /// </summary>
    internal class MoveFileParamValidator : AbstractValidator<MoveFileParam>
    {
        /// <summary>
        ///
        /// </summary>
        public MoveFileParamValidator(ALiYunStorageConfig _aLiYunConfig)
        {
            RuleFor(x => x.OptBucket).Must(x => !string.IsNullOrEmpty(x)).WithMessage("目标空间不能为空");
            RuleFor(x => x.SourceKey).Must(x => !string.IsNullOrEmpty(x)).WithMessage("源空间key不能为空");
            RuleFor(x => x.OptKey).Must(x => !string.IsNullOrEmpty(x)).WithMessage("目标文件key不能为空");

            RuleFor(x => x.OptKey)
                .Must((item, _) => !(Core.Tools.GetBucket(_aLiYunConfig, item.PersistentOps.Bucket) ==
                                   Core.Tools.GetBucket(_aLiYunConfig, item.PersistentOps.Bucket, item.OptBucket)&&item.SourceKey==item.OptKey))
                .WithMessage("目标文件不能与源文件一致");
        }
    }
}
