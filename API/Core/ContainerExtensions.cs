using API.Core;
using Application;
using Application.Commands;
using Application.Email;
using Application.Logger;
using EfDataAccess;
using Implementation.Commands;
using Implementation.Email;
using Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core
{
    public static class ContainerExtensions
    {

        public static void AddUsesCases(this IServiceCollection services)
        {


            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IUseCaseLogger, DBUseCaseLogger>();
            services.AddTransient<IGetLogsCommand, EfGetLogsQuery>();
            services.AddTransient<IEmailSender, SMTPEmailSender>();

            //create ili ti add
            services.AddTransient<ICreatePostCommand, EfCreatePost>();
            services.AddTransient<ICreateTagCommand, EfAddTagCommand>();
            services.AddTransient<ICreateUserCommand, EfAddUserCommand>();
            services.AddTransient<ICreatePictureCommand, EfAddPictureCommand>();
            services.AddTransient<ICreateCommentCommand, EfAddCommentCommand>();

            //edit ili ti update
            services.AddTransient<IEditPostCommand, EfEditPostCommand>();
            services.AddTransient<IEditTagCommand, EfEditTagCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IEditCommentCommand, EfEditCommentCommand>();
            services.AddTransient<IEditPictureCommand, EfEditPictureCommand>();

            //delete 
            services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
            services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
            services.AddTransient<IDeletePictureCommand, EfDeletePictureCommand>();

            //getOne i getAll
            services.AddTransient<IGetPostCommand, EfGetPostCommand>();
            services.AddTransient<IGetPostsCommand, EfGetPostsCommand>();
            services.AddTransient<IGetTagsCommand, EfGetTagsCommand>();
            services.AddTransient<IGetTagCommand, EfGetTagCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IGetCommentCommand, EfGetCommentCommand>();
            services.AddTransient<IGetCommentsCommand, EfGetCommentsCommand>();
            services.AddTransient<IGetPictureCommand, EfGetPictureCommand>();
            services.AddTransient<IGetPicturesCommand, EfGetPicturesCommand>();

            //Validatori
            services.AddTransient<AddUserValidator>();
            services.AddTransient<AddpostValidator>();
            services.AddTransient<AddCommentValidator>();
            services.AddTransient<AddTagValidator>();
            services.AddTransient<AddUserValidator>();
            services.AddTransient<AddPictureValidator>();

            services.AddTransient<EditPictureValidator>();
            services.AddTransient<EditTagValidator>();
            services.AddTransient<EditPostValidator>();
            services.AddTransient<EditUserValidator>();
            services.AddTransient<EditCommentValidator>();

        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JWTActor>(actorString);

                return actor;

            });
        }
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JWTManager>(x =>
            {
                var context = x.GetService<BlogContext>();

                return new JWTManager(context);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
