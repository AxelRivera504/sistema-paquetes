﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Paqueteria.Entities.Entities
{
    public partial class tbCiudades
    {
        public int ciu_ID { get; set; }
        public string ciu_Descri { get; set; }
        public int dep_ID { get; set; }
        public int ciu_UsuarioCrea { get; set; }
        public DateTime? ciu_FechaCrea { get; set; }
        public int? ciu_UsuarioModifica { get; set; }
        public DateTime? ciu_FechaModifica { get; set; }

        public virtual tbDepartamentos dep { get; set; }
    }
}