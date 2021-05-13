using System.Collections.Generic;
using HypothesisTesting.Domain;
using HypothesisTesting.Domain.Ports.Translations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HypothesisTesting.Web.Models
{
    public class TestViewModel : BaseViewModel
    {
        public string XValues { get; set; }

        public string YValues { get; set; }

        public string SamplesType { get; set; }

        public string ScaleMeasure { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; }

        public TestViewModel(string language, ITranslator translator)
            : base(language, translator)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem("Polski", WebConstants.Languages.Polish),
                new SelectListItem("English", WebConstants.Languages.English),
            };

            SamplesType = Constants.SamplesTypes.Paired;
            ScaleMeasure = Constants.ScaleMeasures.Nominal;
            Languages = items;
            XValues = "1\n2\n3\n4\n5";
            YValues = "6\n7\n8\n9\n10";
        }
    }
}