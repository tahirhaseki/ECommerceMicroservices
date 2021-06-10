using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Web.Models.Catalog
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs Süresi")]
        public int Duration { get; set; }
    }
}
