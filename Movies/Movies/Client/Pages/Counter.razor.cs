using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Client.Pages
{
    public partial class Counter
    {
        [Inject] SingletonService singleton { get; set; }
        [Inject] TransientService trans { get; set; }

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            singleton.Value = currentCount;
            trans.Value = currentCount;
        }
    }
}
