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
    
    public partial class Comment
    {
        public int IDComment { get; set; }
        public Nullable<int> IDCreatedComment { get; set; }
        public Nullable<int> IDPosts { get; set; }
        public string ContentComment { get; set; }
        public Nullable<System.DateTime> DatePublicate { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Post Post { get; set; }
    }
}
