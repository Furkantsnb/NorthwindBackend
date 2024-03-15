using Business.Contants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilitis.Interceptors;
using Core.Utilitis.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation :MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpcontextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpcontextAccessor=ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpcontextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
