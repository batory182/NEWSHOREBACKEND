﻿namespace Business.Entitites
{
    public class Flight
    {
        public Flight()
        {
            Transport = new Transport(); ;
        }
        public Transport Transport { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }
    }
}
