﻿using PSL.Core.Entities.Concrete;
using PSL.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSL.Business.Interfaces
{
    public interface IAuthService
    {
        Task<IDataResult<JwtAuthUser>> LoginWithEmail(string email, string password, string ip);
        Task<IDataResult<JwtAuthUser>> LoginWithUsername(string email, string password, string ip);
    }
}
