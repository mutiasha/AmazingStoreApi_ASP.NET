using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AmazingStoreApi.Models;

namespace AmazingStoreApi.Controllers
{
    public class ProductController : ApiController
    {
        //https://forums.asp.net/t/2139116.aspx?+Message+The+requested+resource+does+not+support+http+method+POST+
        
        private AmazingStoreEntities db = new AmazingStoreEntities();

        //http://localhost:25547/api/Product/AM003 ini versi default (bisa post atau get)
        //http://localhost:25547/api/Product/GetProduct/AM003 ini versi tambahan action (cek WebApiConfig)
        
        //[HttpPost] //ini kalo mau pake post di postman nya
        // GET api/Product
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        //[HttpPost]
        // GET api/Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(string id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT api/Product/5
        //public IHttpActionResult PutProduct(string id, Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != product.product_id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST api/Product
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult PostProduct(Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Products.Add(product);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (ProductExists(product.product_id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = product.product_id }, product);
        //}

        //// DELETE api/Product/5
        //[ResponseType(typeof(Product))]
        //public IHttpActionResult DeleteProduct(string id)
        //{
        //    Product product = db.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Products.Remove(product);
        //    db.SaveChanges();

        //    return Ok(product);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(string id)
        {
            return db.Products.Count(e => e.product_id == id) > 0;
        }
    }
}