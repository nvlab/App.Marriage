//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Marriage.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articles
    {
        public int Id { get; set; }
        public string Titles { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public string Status { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public Nullable<int> Entity_Order { get; set; }
        public Nullable<bool> IsPublish { get; set; }
        public Nullable<System.DateTime> ArticalDate { get; set; }
        public string Artical_Image { get; set; }
    
        public virtual Category Category { get; set; }
    }
}
