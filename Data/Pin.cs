using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EdUnity.Data
{
    public record Pin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Grade Class { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Time { get; set; }
        public PinKind Kind { get; set; }

    }
    public enum PinKind
    {
        [Display(Name="Car")] Car
    }
    public enum Grade
    {
        [Display(Name = "Freshman")] Freshman,
        [Display(Name = "Sophomore")] Sophomore,
        [Display(Name = "Junior")] Junior,
        [Display(Name = "Senior")] Senior
    }
}