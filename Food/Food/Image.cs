﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Food
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Image
    {
        public int ImageID { get; set; }
        [DisplayName("Hình Ảnh")]
        public string ImageName { get; set; }
        public Nullable<int> FoodID { get; set; }
    
        public virtual Food Food { get; set; }
    }
}
