﻿using ShoppingCart.Business.ManagerClasses;
using ShoppingCart.Common;
using ShoppingCart.Data.Models;
using System.Linq;
using System.Net;

namespace ShoppingCart.Business.Manager
{
    /// <summary>
    /// Business manager class with all the product related logic
    /// </summary>
    public class ProductManager : BaseManager
    {
        /// <summary>
        /// method to get all the products
        /// </summary>
        /// <param name="id">id if needs to be filtered</param>
        /// <returns></returns>
        public OperationResult GetAllProducts(int? id)
        {
            //new operarion result object to hold responce data
            OperationResult operationResult = new OperationResult();
            operationResult.Status = Enum.Status.Success;
            operationResult.Message = Constant.SuccessMessage;

            //check if id is available
            if (id == null)
            {
                var productList = ProductRepository.GetAll().ToList();
                operationResult.Data = productList;
            }
            else
            {
                var product = ProductRepository.GetById(id);
                operationResult.Data = product;
            }

            return operationResult;
        }

    }
}
