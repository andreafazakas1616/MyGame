//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyGame.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enemy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Enemy()
        {
            this.EnemyCoords = new HashSet<EnemyCoord>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> Attack { get; set; }
        public Nullable<int> Defense { get; set; }
        public Nullable<int> HP { get; set; }
        public Nullable<int> XP_given { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnemyCoord> EnemyCoords { get; set; }
    }
}
