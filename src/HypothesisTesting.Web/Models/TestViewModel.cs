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

            SamplesType = Constants.SamplesTypes.Independent;
            ScaleMeasure = Constants.ScaleMeasures.Interval;
            Languages = items;
            XValues = "0.63, 1.64, 1.93, -1.03, -1.73, -1.13, 4.72, 0.45, -1.03, -2.31, -0.83, -3.3, -0.02, 3.26, 1.17";
            YValues = "1.36, 0.63, 4.79, -1.59, 2.72, -1.65, -0.58, 0.76, -2.26, 2.28, -0.19, 2.94, 0.56, -2.97, -2.03, 2.35, -0.25, 1.69, 0.62, 4.2";
        }
    }
}