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
    
    public partial class UserCoord
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<int> CoordX { get; set; }
        public Nullable<int> CoordY { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
