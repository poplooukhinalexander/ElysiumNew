// See https://aka.ms/new-console-template for more information
using System.Globalization;

using Npgsql;

try
{
	var cts = new CancellationTokenSource();
	Console.CancelKeyPress += (e, s) => 
	{
		Console.WriteLine("Import data was cancelled!");
		cts.Cancel();
		s.Cancel = true;
	};
	Console.WriteLine("Import data was started.");
	await using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Database=elysium;Username=postgres;Password=flame2005");
	await connection.OpenAsync(cts.Token);
	await using var transaction = await connection.BeginTransactionAsync(cts.Token);
	await using var fs = new FileStream(@"Data\locations-ru.txt", FileMode.Open, FileAccess.Read);
	using var sr = new StreamReader(fs);	
	await using var batch = new NpgsqlBatch(connection, transaction);
	string? line = null;
	int lineNum = 1;
	while ((line = await sr.ReadLineAsync()) != null)
	{
		var parts = line.Split(';');
		int latIndex = parts.Length - 3;
		int lonIndex = parts.Length - 2;
		var id = Guid.NewGuid();
		var country = parts[0];
		var city = parts[2];
		var region = parts.Length == 8 ? parts[3] : null;
		var district = parts.Length == 9 ? parts[5] : null;
		var latitude = double.Parse(parts[latIndex], NumberStyles.Float, CultureInfo.InvariantCulture);
		var longitude = double.Parse(parts[lonIndex], NumberStyles.Float, CultureInfo.InvariantCulture);
		var name = $"{country}";
		if (!string.IsNullOrWhiteSpace(region))
			name += $", {region}";

		if (!string.IsNullOrWhiteSpace(district))
			name += $", {district}";

		name += $", {city}";

		var cmd = 
			new NpgsqlBatchCommand(@"insert into public.""Locations""(""Id"", ""Name"", ""Country"", ""Region"", ""District"", ""City"", ""Latitude"", ""Longitude"") values(@Id, @Name, @Country, @Region, @District, @City, @Latitude, @Longitude)");
		cmd.Parameters.Add(new NpgsqlParameter("Id", id));
		cmd.Parameters.Add(new NpgsqlParameter("Name", name));
		cmd.Parameters.Add(new NpgsqlParameter("Country", country));
		cmd.Parameters.Add(new NpgsqlParameter("City", city));
		cmd.Parameters.Add(new NpgsqlParameter("Region", region ?? Convert.DBNull));
		cmd.Parameters.Add(new NpgsqlParameter("District", district ?? Convert.DBNull));
		cmd.Parameters.Add(new NpgsqlParameter("Latitude", latitude));
		cmd.Parameters.Add(new NpgsqlParameter("Longitude", longitude));	
		batch.BatchCommands.Add(cmd);
		Console.WriteLine($"Line {lineNum ++}. City: {city}, Region: {region}, District: {district}, Country: {country}, Lat: {latitude}, Lon: {longitude}");
	}
	Console.WriteLine("All lines were proccessed.");
	await batch.PrepareAsync(cts.Token);
	await batch.ExecuteNonQueryAsync(cts.Token);
	await transaction.CommitAsync(cts.Token);
	Console.WriteLine("Import data was finished!. Push any button to exit.");
	Console.ReadLine();
}
catch(Exception ex)
{
	Console.WriteLine($"Error:{ex}");
}
