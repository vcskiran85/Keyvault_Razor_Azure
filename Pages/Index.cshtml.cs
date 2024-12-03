using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Keyvault_Razor_Azure.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public string SecretValue { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            SecretValue = "";


        }

        public async Task OnGetAsync()
        {
            // Simulate an asynchronous operation
            await Task.Run(() =>
            {
                // Example of setting SecretValue from configuration
                SecretValue = _configuration["SQLCn"] ?? "default value";
            });
        }
    }
}
