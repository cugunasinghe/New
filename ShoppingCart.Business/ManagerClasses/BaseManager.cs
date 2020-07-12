﻿using ShoppingCart.Data.Models;
using ShoppingCart.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.ManagerClasses
{
    /// <summary>
    /// Base Manager class which will hold all the common attributes of the manager classes
    /// </summary>
    public class BaseManager
    {
        #region Private Properties

        private IRepository<Product> productRepository { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Product Public Repository
        /// </summary>
        public IRepository<Product> ProductRepository
        {
            get
            {
                productRepository = productRepository ?? new Repository<Product>();
                return productRepository;
            }
        }

        #endregion
    }
}
