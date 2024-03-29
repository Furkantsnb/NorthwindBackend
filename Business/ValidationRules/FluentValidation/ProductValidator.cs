﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=> p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).Length(2,30);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(1);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(30).When(p=>p.CategoryId==1);
            RuleFor(p => p.ProductName).Must(StarWitgWithA);

        }

        private bool StarWitgWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
