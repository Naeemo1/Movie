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

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
