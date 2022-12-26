using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        public CPU(string brand, int cores, double frequency)
        {
            this.Brand = brand;
            this.Cores = cores;
            this.Frequency = frequency;
        }

        public string Brand { get; set; }

        public int Cores { get; set; }

        public double Frequency { get; set; }

        public override string ToString()
        {
            return $"{this.Brand} CPU:\nCores: {this.Cores}\nFrequency: {string.Format("{0:0.0}", this.Frequency)} GHz";
        }
    }
}