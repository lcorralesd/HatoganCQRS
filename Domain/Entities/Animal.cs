using Domain.Common;
using Domain.Enums;
using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal : EntityBase
    {
        private int _ageDays;
        private string _longAge;

        public string Code { get; set; }
        public string EarTag { get; set; }
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public Status Status { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BreedId { get; set; }
        public Breed Breed { get; set; }
        public string Color { get; set; }
        public DateTime? BirthDate { get; set; }
        public int AgeDays
        {
            get
            {
                _ageDays = Utils.CalculateAgeDays(BirthDate);
                return _ageDays;
            }
        }

        public string LongAge
        {
            get
            {
                _longAge = Utils.CalculateLongAge(BirthDate, DateTime.Now);
                return _longAge;
            }
        }

        public decimal? BirthWeight { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public decimal? IncomeWeight { get; set; }
        public int? DamId { get; set; }
        public Animal Dam { get; set; }
        public int? SireId { get; set; }
        public Animal Sire { get; set; }
        public string Remark { get; set; }
        public List<Animal> DamPups { get; set; } = new List<Animal>();
        public List<Animal> SirePups { get; set; } = new List<Animal>();
    }
}
