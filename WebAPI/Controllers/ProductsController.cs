﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //isteği yaparken insanlar bize nasıl ulaşsını gösterir
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled- gevşek bağımlılık. soyuta bağımlılık var 
        //naming convention
        // IoC Controller -- Inversion of Control
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService; //injection
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain 
            /*IProductService productService=new ProductManager(new EFProductDal());*/ //bağımlılık zinciri oluşturuyor.
                var result = _productService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
} 