﻿using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Movies.Client.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Tewr.Blazor.FileReader;

namespace Movies.Client.Basment
{
    public class Component : ComponentBase
    {
        #region Injection
        [Inject] protected IJSRuntime Js { get; set; }
        [Inject] protected NavigationManager Nav { get; set; }
        [Inject] protected IRepository rep { get; set; }
        [Inject] protected HttpClient httpClient { get; set; }
        [Inject] protected IFileReaderService fileReaderService { get; set; }
        [Inject] protected IModalService Popup { get; set; }


        #endregion

        protected async Task Busy(bool state, string element = "body")
        {
            try
            {
                await Js.InvokeVoidAsync("Busy", state, element);
            }
            catch (Exception ex)
            {


            }
        }

    }
}
