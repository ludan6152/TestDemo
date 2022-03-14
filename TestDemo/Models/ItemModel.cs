using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestDemo.Models
{
    public class ItemModel
    {
        [DisplayName("項目編號")]
        public string itemid { get; set; }

        [DisplayName("項目名稱")]
        public string itemname { get; set; }

        [DisplayName("金額")]
        public string amount { get; set; }
    }
}