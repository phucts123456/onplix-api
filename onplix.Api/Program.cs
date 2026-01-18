using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using onplix.Application;
using onplix.Application.Handlers.Account;
using onplix.Application.Interfaces;
using onplix.Application.Mapping;
using onplix.Application.Services;
using onplix.Domain.Interfaces;
using onplix.Infrastructure.Data;
using onplix.Infrastructure.Repositories;
using onplix.Infrastructure.Services;
using onplix.Shared.Common;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OnPlixDbContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
	options.UseSqlServer(connectionString);
});

// jwt key config
var privateKey = builder.Configuration["jwt:Serect-Key"];
var Issuer = builder.Configuration["jwt:Issuer"];
var Audience = builder.Configuration["jwt:Audience"];

// cấu hình cơ bản
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	// Thiết lập các tham số xác thực token
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		// Kiểm tra và xác nhận Issuer (nguồn phát hành token)
		ValidateIssuer = true,
		ValidIssuer = Issuer, // Biến `Issuer` chứa giá trị của Issuer hợp lệ
							  // Kiểm tra và xác nhận Audience (đối tượng nhận token)
		ValidateAudience = true,
		ValidAudience = Audience, // Biến `Audience` chứa giá trị của Audience hợp lệ
								  // Kiểm tra và xác nhận khóa bí mật được sử dụng để ký token
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
		// Sử dụng khóa bí mật (`privateKey`) để tạo SymmetricSecurityKey nhằm xác thực chữ ký của token
		// Giảm độ trễ (skew time) của token xuống 0, đảm bảo token hết hạn chính xác
		ClockSkew = TimeSpan.Zero,
		// Xác định claim chứa vai trò của user (để phân quyền)
		RoleClaimType = ClaimTypes.Role,
		// Xác định claim chứa tên của user
		NameClaimType = ClaimTypes.Name,
		// Kiểm tra thời gian hết hạn của token, không cho phép sử dụng token hết hạn
		ValidateLifetime = true
	};
	// cấu hình response theo chuẩn ResponseEntity của dự án
	options.Events = new JwtBearerEvents
	{
		OnForbidden = context =>
		{
			context.Response.StatusCode = StatusCodes.Status403Forbidden;
			context.Response.ContentType = "application/json";
			var response = JsonSerializer.Serialize(ResponseEntity<string>.Fail("Unauthorization!", 403),
			new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
			return context.Response.WriteAsync(response);
		},
		OnChallenge = context => // khi không có token hoặc token không hợp lệ
		{
			context.HandleResponse(); // 
			context.Response.StatusCode = StatusCodes.Status401Unauthorized;
			context.Response.ContentType = "application/json";
			var response = JsonSerializer.Serialize(ResponseEntity<string>.Fail("Login required.", 401),
			new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
			return context.Response.WriteAsync(response);
		}
	};

});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPasswordHelper, PasswordHelper>();
builder.Services.AddScoped<IJwtAuthService, JwtAuthService>();
builder.Services.AddAutoMapper(config => { }, typeof(AccountMapper));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(
	configuration => configuration.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
