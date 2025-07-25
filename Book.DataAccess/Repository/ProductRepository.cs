﻿using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContex _db;
        public ProductRepository(ApplicationDbContex db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
