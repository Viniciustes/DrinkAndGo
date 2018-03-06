﻿using DrinkAndGo.Data.Interfaces;
using DrinkAndGo.Data.Models;
using DrinkAndGo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DrinkAndGo.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IDrinkRepository _drinkRepository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryRepository = categoryRepository;
            _drinkRepository = drinkRepository;
        }

        public ViewResult List(string category)
        {
            var _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(d => d.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, System.StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkRepository.Drinks.Where(d => d.Category.CategoryName.Equals("Alcoholic")).OrderBy(d => d.DrinkId);
                }
                else
                    drinks = _drinkRepository.Drinks.Where(d => d.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(d => d.DrinkId);

                currentCategory = _category;
            }

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };

            return View(drinkListViewModel);
        }
    }
}