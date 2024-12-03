using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var configuration = builder.Configuration;
var vaultUri = configuration["KeyVault:VaultUri"] ?? "";
if (!string.IsNullOrEmpty(vaultUri))
{
    var keyVaultUri = new Uri(vaultUri);
    builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());
}

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
