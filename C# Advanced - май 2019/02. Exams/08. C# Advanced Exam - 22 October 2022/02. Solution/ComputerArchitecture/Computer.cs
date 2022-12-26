using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            this.Model = model;
            this.Capacity = capacity;
            this.Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }

        public int Capacity { get; set; }

        public List<CPU> Multiprocessor { get; set; }

        public int Count => this.Multiprocessor.Count();

        public void Add(CPU cpu)
        {
            if (this.Count < this.Capacity)
            {
                this.Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            var target = this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (target != null)
            {
                this.Multiprocessor.Remove(target);
                return true;
            }

            return false;
        }

        public CPU MostPowerful()
        {
            return this.Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }

        public CPU? GetCPU(string brand)
        {
            return this.Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {this.Model}:");

            foreach (var item in this.Multiprocessor)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}