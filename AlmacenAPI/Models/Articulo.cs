﻿namespace AlmacenAPI.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime fechaEntrada { get; set; }
        public int Cantidad { get; set; }



    }
}
