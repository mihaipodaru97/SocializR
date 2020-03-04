using BusinessEntities.Types;
using BusinessLogic.Servicies;
using DataAcces.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SocializR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SocializR.Code.ExtensionMethods
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<CountyService>();
            services.AddScoped<LocalityService>();
            services.AddScoped<InterestService>();
            services.AddScoped<FriendService>();
            services.AddScoped<PostService>();
            services.AddScoped<CommentService>();
            services.AddScoped<LikeService>();
            services.AddScoped<AlbumService>();
            services.AddScoped<PhotoService>();
            services.AddScoped<PermissionService>();

            return services;
        }

        public static void AddCurrentUser(this IServiceCollection services)
        {
            _ = services.AddScoped(serviceProvider =>
              {
                  var httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                  var userService = serviceProvider.GetService<UserService>();
                  var email = httpContextAccessor.HttpContext.User
                                      .FindFirst(ClaimTypes.Email)?
                                      .Value;
                  var user = userService.GetByEmail(email);
                  var permissionService = serviceProvider.GetService<PermissionService>();

                  var rolesList = httpContextAccessor.HttpContext
                      .User.FindAll(ClaimTypes.Role).ToList();

                  var roles = new List<string>();

                  rolesList.ForEach(r => roles.Add(r.Value));

                  return user == null ? new CurrentUser() : new CurrentUser
                  {
                      Id = user.Id,
                      FirstName = user.FirstName,
                      LastName = user.LastName,
                      IsAuthenticated = true,
                      Roles = roles,
                      CanCreateCities = permissionService.CanUserDo(user.Id, PermissionType.CreateCounty),
                      CanCreateLocalities = permissionService.CanUserDo(user.Id, PermissionType.CreateLocality),
                      CanDeleteUser = permissionService.CanUserDo(user.Id, PermissionType.DeleteUser),
                      CanEditProfile = permissionService.CanUserDo(user.Id, PermissionType.ModifyProfile),
                      CanViewProfile = permissionService.CanUserDo(user.Id, PermissionType.ViewProfile)
                  };
              });
        }
    }
}
