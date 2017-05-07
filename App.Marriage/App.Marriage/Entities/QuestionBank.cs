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
    
    public partial class QuestionBank
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuestionBank()
        {
            this.RequestQuestionSenario = new HashSet<RequestQuestionSenario>();
        }
    
        public int Id { get; set; }
        public string Question { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public byte[] Image { get; set; }
        public Nullable<int> Entity_Order { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequestQuestionSenario> RequestQuestionSenario { get; set; }
    }
}