using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace TailwindTraders.Mobile.Models
{
    public class RecommendedProductCategory
    {
        public string CategoryName { get; set; }
        public string ImageName { get; set; }
        public string CategoryAbbreviation { get; set; }

        public ICommand NavigateCommand { get; set; }
    }
}
