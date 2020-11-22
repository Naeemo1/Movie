using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Movies.Client.Shared.MainLayout;

namespace Movies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton { get; set; }
        [Inject] TransientService trans { get; set; }
        //[CascadingParameter(Name ="color")] public string color { get; set; }
        //[CascadingParameter(Name = "size")] public string size { get; set; }
        [CascadingParameter] public AppStyle AppStyle { get; set; }


        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            singleton.Value = currentCount;
            trans.Value = currentCount;
        }
    }
}
