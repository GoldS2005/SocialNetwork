//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSocial
{
    using System;
    using System.Collections.Generic;
    
    public partial class Like
    {
        public int LikeId { get; set; }
        public Nullable<int> PostId { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
