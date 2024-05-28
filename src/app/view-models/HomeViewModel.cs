using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class HomeViewModel : BaseViewModel
    {
        public override string Name { get; } = "Home";
        public override string ID { get; } = nameof(HomeViewModel);
    }
}
