﻿namespace Business.Entitites
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal Convertion { get; set; }
        public bool Active { get; set; }
    }
}
