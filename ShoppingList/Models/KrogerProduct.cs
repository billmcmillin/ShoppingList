using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

//kroger item: "name"=>"30 Inch Round Kiwi Casual Laces", "buyable"=>true, "catentryId"=>nil, "fullImageAltDescription"=>nil, "imageUrl"=>"https://www.kroger.com/product/images/medium/front/0003160066116", "regularPrice"=>"1.69", "salePrice"=>"", "offerDescription"=>nil, "offerQuantity"=>nil, "offerPrice"=>"", "offerType"=>nil, "offerEndDate"=>nil, "sizing"=>"2 Pair", "thumbnail"=>nil, "wcsProductId"=>nil, "upc"=>"0003160066116", "soldBy"=>"UNIT", "orderBy"=>"UNIT", "serviceCenter"=>nil, "imageUrls"=>["https://www.kroger.com/product/images/medium/front/0003160066116"], "thumbnails"=>nil, "priceSizingDescription"=>"2 Pair", "specialInstruction"=>nil, "currentPrice"=>"1.69", "currentPriceIsYellowTag"=>false}

namespace ShoppingList.Models
{
    public class KrogerProduct
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool buyable { get; set; }
        public object catentryId { get; set; }
        public object fullImageAltDescription { get; set; }
        public string imageUrl { get; set; }
        public string regularPrice { get; set; }
        public string salePrice { get; set; }
        public object offerDescription { get; set; }
        public object offerQuantity { get; set; }
        public string offerPrice { get; set; }
        public object offerType { get; set; }
        public string offerEndDate { get; set; }
        public string sizing { get; set; }
        public object thumbnail { get; set; }
        public object wcsProductId { get; set; }
        public string upc { get; set; }
        public string soldBy { get; set; }
        public string orderBy { get; set; }
        public object serviceCenter { get; set; }
        public List<string> imageUrls { get; set; }
        public object thumbnails { get; set; }
        public string priceSizingDescription { get; set; }
        public object specialInstruction { get; set; }
        public string currentPrice { get; set; }
        public bool currentPriceIsYellowTag { get; set; }
        public String Self
        {
            get
            {
                return string.Format(CultureInfo.CurrentCulture,
               "api/krogerproducts/{0}", this.Id);
            }
            set { }
        }

        private ApplicationDbContext db = new ApplicationDbContext();

        public void populateDB()
        {

           
            string jsonString = File.ReadAllText(@"C:\Users\Bill\Downloads\final3.json");
            System.Diagnostics.Debug.WriteLine("//////////////////////////////////");

            var root = JsonConvert.DeserializeObject<RootObject>(jsonString);
            System.Diagnostics.Debug.WriteLine(root.KrogerProducts[0].name);

            foreach (KrogerProduct kp in root.KrogerProducts)
            {
                System.Diagnostics.Debug.WriteLine(kp.name);
                //var todel = db.KrogerProducts.Where(i => i.name == kp.name);
                //foreach (KrogerProduct k in todel)
                //{
                //    db.KrogerProducts.Remove(k);


                //}

                //db.KrogerProducts.Add(kp);


            }
            //db.SaveChanges();
        }
    }

        public class RootObject
    {
        public List<KrogerProduct> KrogerProducts { get; set; }
    }


            //var rootNode = a1.ToObject<List<KrogerProduct>>();
            //var root = JsonConvert.DeserializeObject<RootObject>(a1);

            //foreach (KrogerProduct prod in kpList)
            //{
            //    System.Diagnostics.Debug.WriteLine(prod.name);
            //}
            //var root = JsonConvert.DeserializeObject<RootObject>(o2);

            //System.Diagnostics.Debug.WriteLine(root.pages.KrogerProducts);
            //foreach (var kp in root.pages.KrogerProducts)
            //{
            //    Console.WriteLine(kp.name);
            //}





        
    

}