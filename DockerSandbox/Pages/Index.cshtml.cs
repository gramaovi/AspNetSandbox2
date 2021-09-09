using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerSandbox.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> loggerCopy;

        public IndexModel(ILogger<IndexModel> logger)
        {
            loggerCopy = logger;
        }

        public void OnGet()
        {

        }
    }
}
