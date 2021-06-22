﻿using Application.DTOs.Users;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<Response<AuthenticationResponse>>
    {
    }
}
