using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
//kroger item: "name"=>"30 Inch Round Kiwi Casual Laces", "buyable"=>true, "catentryId"=>nil, "fullImageAltDescription"=>nil, "imageUrl"=>"https://www.kroger.com/product/images/medium/front/0003160066116", "regularPrice"=>"1.69", "salePrice"=>"", "offerDescription"=>nil, "offerQuantity"=>nil, "offerPrice"=>"", "offerType"=>nil, "offerEndDate"=>nil, "sizing"=>"2 Pair", "thumbnail"=>nil, "wcsProductId"=>nil, "upc"=>"0003160066116", "soldBy"=>"UNIT", "orderBy"=>"UNIT", "serviceCenter"=>nil, "imageUrls"=>["https://www.kroger.com/product/images/medium/front/0003160066116"], "thumbnails"=>nil, "priceSizingDescription"=>"2 Pair", "specialInstruction"=>nil, "currentPrice"=>"1.69", "currentPriceIsYellowTag"=>false}

namespace ShoppingList.Models
{
    public class KrogerProduct
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool buyable { get; set; }
        public string upc { get; set; }
        public string regularPrice { get; set; }
        public string salePrice { get; set; }
        public int offerQuantity { get; set; }
        public string offerPrice { get; set; }
        public string offerEndDate { get; set; }
        public string sizing { get; set; }
        public string currentPrice { get; set; }
        public String Self
         {
             get { return string.Format(CultureInfo.CurrentCulture,
                  "api/krogerproducts/{0}", this.Id);
            }
            set { }
         }

        public class Page
        {
            public List<KrogerProduct> KrogerProducts { get; set; }
        }

        public class RootObject
        {
            public Page pages { get; set; }
        }

        public void populateDB()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Bill\Downloads\kroger3.json"))
            {
                string json = r.ReadToEnd();
                var root = JsonConvert.DeserializeObject<RootObject>(json);

                // List<KrogerProduct> items = JsonConvert.DeserializeObject<List<KrogerProduct>>(json);
                System.Diagnostics.Debug.WriteLine("//////////////////////////////////");
                //System.Diagnostics.Debug.WriteLine(root.p.kp);
                //foreach (var kp in root.p.kp)
                //{
                //    Console.WriteLine(kp.name);
                //}
            }

        }

    }


}