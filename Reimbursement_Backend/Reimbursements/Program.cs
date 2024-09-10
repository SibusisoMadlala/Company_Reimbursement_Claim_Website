using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reimbursements.Business.Interfaces;
using Reimbursements.Business.Mappings;
using Reimbursements.Business.Services;
using Reimbursements.DataAccess.Context;
using Reimbursements.DataAccess.Context.Entities;
using Reimbursements.DataAccess.Interfaces;
using Reimbursements.DataAccess.Repositories;
using Reimbursements.WebApi;
using System.Formats.Tar;
using System.Text;

namespace Reimbursements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ReimbursementsContextConnection' not found.");

            builder.Services.AddDbContext<ReimbursementsContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddDbContext<ClaimsDbContext>();

            

            builder.Services.AddDefaultIdentity<ReimbursementsUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ReimbursementsContext>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            builder.Services.AddScoped<JwtHandler>();
           
            builder.Services.AddScoped<IClaimsRepository, ClaimsRepository>();
            builder.Services.AddScoped<IBankRepository, BankRepository>();
            builder.Services.AddScoped<IClaimAppService, ClaimAppService>();
            builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            builder.Services.AddScoped<ITypesRepository, TypesRepository>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
            builder => builder
                .WithOrigins("http://localhost:4200") 
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseCors("AllowAngularApp");
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
