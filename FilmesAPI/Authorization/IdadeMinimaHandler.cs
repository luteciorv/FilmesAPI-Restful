using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmesAPI.Authorization
{
    public class IdadeMinimaHandler : AuthorizationHandler<IdadeMinimaRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinimaRequirement requirement)
        {
            bool possuiDataNacimento = context.User.HasClaim(C => C.Type == ClaimTypes.DateOfBirth));
            if (!possuiDataNacimento)
            { return Task.CompletedTask; }

            DateTime dataNascimento = Convert.ToDateTime(
                context.User.FindFirst(C => C.Type == ClaimTypes.DateOfBirth).Value
            );

            int idade = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Today.AddYears(-idade))
            { idade--; }

            if(idade >= requirement.IdadeMinima)
            { context.Succeed(requirement); }

            return Task.CompletedTask;
        }
    }
}
