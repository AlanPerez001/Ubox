﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubox.ModelService.Autenticacion
{
    public class ActualizarToken
    {

        public ActualizarToken(string refreshToken, string user, string jwtTojen)
        {
            RefreshToken = refreshToken;
            User = user;
            JwtToken = jwtTojen;
        }

        public string RefreshToken { get; }
        public string User { get; }
        public string JwtToken { get; }
    }
}
