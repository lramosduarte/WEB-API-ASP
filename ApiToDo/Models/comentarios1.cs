//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiToDo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class comentarios1
    {
        public int id { get; set; }
        public string comentarios { get; set; }
        public int tarefas_id { get; set; }
    
        public virtual tarefas1 tarefas1 { get; set; }
    }
}
