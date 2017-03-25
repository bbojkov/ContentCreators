using System;
using System.ComponentModel.DataAnnotations;

namespace BulgarianCreators.Models
{
    public class Country
    {
        public Guid Id { get; set; }

        public string CountryName { get; set; }
    }
}