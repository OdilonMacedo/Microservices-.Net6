﻿using System.Reflection;
using GeekShopping.web.Models;
using GeekShopping.web.Services.IServices;
using GeekShopping.web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [Authorize]
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.CreateProduct(model);
                return RedirectToAction("ProductIndex");
            }
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int id)
        {
            var model = await _productService.FindProductById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productService.UpdateProduct(model);
                return RedirectToAction("ProductIndex");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var model = await _productService.FindProductById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
            var product = await _productService.DeleteProductById(model.Id);
            return RedirectToAction("ProductIndex");
        }

    }
}