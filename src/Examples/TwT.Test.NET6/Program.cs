using TwT.ContentSecurityPolicy.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseContentSecurityPolicyHeaderMiddelware(builder =>
{
    #region CSP Level 1
    //Level1 is always enabled!
    builder.Defaults
        .AllowSelf();

    builder.Scripts
        .AllowSelf();

    builder.Styles
        .AllowSelf();

    builder.Images
        .AllowSelf();

    builder.Connect
        .AllowSelf();

    builder.Fonts
        .AllowSelf();

    builder.Object
        .AllowSelf();

    builder.Media
        .AllowSelf();

    builder.Frame
        .AllowSelf();
    #endregion

    #region CSP Level 2
    builder.EnableLevel2 = true;

    builder.Child
        .AllowSelf();
    #endregion

    #region CSP Level 3
    builder.EnableLevel3 = false;

    builder.Worker
        .AllowSelf();

    builder.Manifest
        .AllowSelf();

    builder.Prefetch
        .AllowSelf();
    #endregion
});
app.UseAuthorization();

app.MapRazorPages();

app.Run();
