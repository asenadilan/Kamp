using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProductValidatior: AbstractValidator<Product>
{
    public ProductValidatior()
    {
        //kurallar buraya yazılır
        RuleFor(p => p.ProductName).NotEmpty();
        RuleFor(p => p.ProductName).MinimumLength(2);
        RuleFor(p => p.UnitPrice).GreaterThan(0);
        RuleFor(p => p.UnitPrice).GreaterThan(10).When(p=>p.CategoryId == 1);
        //olmayan bir kuralın yazımı:
        RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//StartWithA => bizim kuralımız
    }

    private bool StartWithA(string arg)
    {
        return arg.StartsWith("A");
    }
}
