using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Botzilla.Core.UpdateRequestModels
{
    public class UpdateCountryRequest
    {
        [MaxLength(50, ErrorMessage = "The name of the Country must be between 2 and 50 characters"), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "The description must be between 2 and 250 characters"), MinLength(2)]
        public string Description { get; set; }

        public long Id { get; set; }
    }
}
