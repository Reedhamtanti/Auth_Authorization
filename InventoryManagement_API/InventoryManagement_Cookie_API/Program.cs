using InventoryManagement_Cookie_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = AuthenticationSchema.DefaultAuthenticationSchema;
    option.DefaultChallengeScheme = AuthenticationSchema.DefaultAuthenticationSchema;
    option.DefaultScheme = AuthenticationSchema.DefaultAuthenticationSchema;
    option.DefaultSignInScheme = AuthenticationSchema.DefaultAuthenticationSchema;
    option.DefaultSignOutScheme = AuthenticationSchema.DefaultAuthenticationSchema;
    option.DefaultForbidScheme = AuthenticationSchema.DefaultAuthenticationSchema;
}).AddCookie(AuthenticationSchema.DefaultAuthenticationSchema, option => {
    option.Cookie.Name = AuthenticationSchema.DefaultAuthenticationSchema;
    option.Cookie.SameSite = SameSiteMode.Strict;
    option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
    option.Cookie.MaxAge = TimeSpan.FromMinutes(30);
    option.LoginPath = "/api/Account/Login";
    option.SlidingExpiration = true;
    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
