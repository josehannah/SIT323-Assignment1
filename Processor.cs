using System;

namespace Assignment1SIT323
{
	public class Processor
    {

		string processorName { get; set; }
		double frequency;
		int RAM { get; set; }
		int download { get; set; }

		int upload { get; set; }

		double C0 { get; set; }
		double C1 { get; set; }
		double C2 { get; set; }

		public Processor(string processorName, double frequency, int RAM, int download, int upload)
        {
			this.processorName = processorName;
			this.frequency = frequency;
			this.RAM = RAM;
			this.download = download;
			this.upload = upload;
        } 

		public void setRAM(int RAM)
        {
			this.RAM = RAM;
        }

		public void setDownload(int download)
        {
			this.download = download;
        }

		public void setUpload(int upload)
        {
			this.upload = upload;
        }

		public void setCoefficients(double C0, double C1, double C2)
        {
			this.C0 = C0;
			this.C1 = C1;
			this.C2 = C2;
        }


		public double EnergyPerSec(double frequency)
        {
			return (C2 * frequency * frequency + C1 * frequency + C0);
        }

		public double Energy(double frequency, double runtime)
        {
			return (EnergyPerSec(frequency) * runtime);
        }
    }
}

	
	
