using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Car
{
    public string Nopol { get; set; }
    public string Kendaraan { get; set; }
    public string Warna { get; set; }

    public Car(string nopol, string warna, string kendaraan)
    {
        Nopol = nopol;
        Warna = warna;
        Kendaraan = kendaraan;
    }
}

public class ParkingLot
{
    private int capacity;
    private int remaining;
    private List<Car> cars;

    public ParkingLot(int capacity)
    {
        this.capacity = capacity;
        remaining = capacity;
        cars = new List<Car>();
    }

    public async Task Park(Car car)
    {
        await Task.Delay(3000);

        if (remaining == 0)
        {
            Console.WriteLine("Maaf, parkiran penuh");
            return;
        }

        if (cars.Any(c => c.Nopol == car.Nopol))
        {
            Console.WriteLine($"{car.Kendaraan} dengan nopol {car.Nopol} sudah terdaftar");
            return;
        }

        cars.Add(car);
        remaining--;
        Console.WriteLine($"Allocated slot number: {capacity - remaining}");
    }

    public async Task Leave(int slotNumber)
    {
        await Task.Delay(3000);
        if (slotNumber < 1 || slotNumber > capacity)
        {
            Console.WriteLine($"Invalid slot number: {slotNumber}");
            return;
        }

        Car carToLeave = cars.FirstOrDefault(c => cars.IndexOf(c) + 1 == slotNumber);

        if (carToLeave != null)
        {
            cars.Remove(carToLeave);
            remaining++;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }
        else
        {
            Console.WriteLine($"Slot number {slotNumber} is already free");
        }
    }

    public async Task Check()
    {
        await Task.Delay(3000);

        Console.WriteLine($"Slot\tNo.\t\tType\tRegistration No\tColour");

        for (int i = 0; i < cars.Count; i++)
        {
            int slotNumber = i + 1;
            Car car = cars[i];

            // Skip slot yang tidak terisi
            if (car.Nopol == null)
            {
                continue;
            }

            Console.WriteLine($"{slotNumber}\t{car.Nopol}\t{car.Kendaraan}\t{car.Warna}");
        }

        Console.WriteLine("\nJumlah lot terisi: " + (capacity - remaining));
        Console.WriteLine("Jumlah lot tersedia: " + remaining);
        Console.WriteLine("Jumlah kendaraan berdasarkan nomor kendaraan (Ganjil/Genap):");
        Console.WriteLine("Ganjil: " + CountByPlatType("Ganjil"));
        Console.WriteLine("Genap: " + CountByPlatType("Genap"));
        Console.WriteLine("Jumlah kendaraan berdasarkan jenis kendaraan:");
        foreach (var entry in CountByKendaraanType())
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        Console.WriteLine("Jumlah kendaraan berdasarkan warna kendaraan:");
        foreach (var entry in CountByWarnaType())
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }

    private int CountByPlatType(string platType)
    {
        return cars.Count(c => c.Nopol.Length % 2 == (platType == "Ganjil" ? 1 : 0));
    }

    private Dictionary<string, int> CountByKendaraanType()
    {
        return cars.GroupBy(c => c.Kendaraan)
                   .ToDictionary(g => g.Key, g => g.Count());
    }

    private Dictionary<string, int> CountByWarnaType()
    {
        return cars.GroupBy(c => c.Warna)
                   .ToDictionary(g => g.Key, g => g.Count());
    }

}

class Program
{
    static async Task Main()
    {
        ParkingLot parkingLot = await CreatePark(6);
        await parkingLot.Park(new Car("B-1234-XYZ", "Putih", "Mobil"));
        await parkingLot.Park(new Car("B-9999-XYZ", "Putih", "Motor"));
        await parkingLot.Park(new Car("D-0001-HIJ", "Hitam", "Mobil"));
        await parkingLot.Park(new Car("B-7777-DEF", "Red", "Mobil"));
        await parkingLot.Park(new Car("B-2701-XXX", "Biru", "Mobil"));
        await parkingLot.Park(new Car("B-3141-ZZZ", "Hitam", "Motor"));
        await parkingLot.Check();
        await parkingLot.Leave(4);
        await parkingLot.Check();
    }

    static async Task<ParkingLot> CreatePark(int capacity)
    {
        await Task.Delay(5000);
        Console.WriteLine($"Tempat parkir berhasil dibuat dengan kapasitas {capacity} kendaraan");
        return new ParkingLot(capacity);
    }
}
