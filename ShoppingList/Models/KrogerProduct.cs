using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
//kroger item: "name"=>"30 Inch Round Kiwi Casual Laces", "buyable"=>true, "catentryId"=>nil, "fullImageAltDescription"=>nil, "imageUrl"=>"https://www.kroger.com/product/images/medium/front/0003160066116", "regularPrice"=>"1.69", "salePrice"=>"", "offerDescription"=>nil, "offerQuantity"=>nil, "offerPrice"=>"", "offerType"=>nil, "offerEndDate"=>nil, "sizing"=>"2 Pair", "thumbnail"=>nil, "wcsProductId"=>nil, "upc"=>"0003160066116", "soldBy"=>"UNIT", "orderBy"=>"UNIT", "serviceCenter"=>nil, "imageUrls"=>["https://www.kroger.com/product/images/medium/front/0003160066116"], "thumbnails"=>nil, "priceSizingDescription"=>"2 Pair", "specialInstruction"=>nil, "currentPrice"=>"1.69", "currentPriceIsYellowTag"=>false}

namespace ShoppingList.Models
{
    public class KrogerProduct
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool buyable { get; set; }
        public uint upc { get; set; }
        public Double regularPrice { get; set; }
        public Double salePrice { get; set; }
        public int offerQuantity { get; set; }
        public Double offerPrice { get; set; }
        public string offerType { get; set; }
        public DateTime offerEndDate { get; set; }
        public string sizing { get; set; }
        public Double currentPrice { get; set; }
        public String Self
         {
             get { return string.Format(CultureInfo.CurrentCulture,
                  "api/krogerproducts/{0}", this.Id);
            }
            set { }
         }

    }
}