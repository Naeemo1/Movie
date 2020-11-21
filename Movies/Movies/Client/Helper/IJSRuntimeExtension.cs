using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Client.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string meesage)
        {
            return await js.InvokeAsync<bool>("confirm", meesage);
        }

        public static async ValueTask Print(this IJSRuntime js, string message)
        {
             await js.InvokeVoidAsync("my_function", message);
        }

    }
}
