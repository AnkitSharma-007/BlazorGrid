# BlazorGrid
This is a reusable grid component for Blazor. It also support client size pagination.
# Prerequisites
The BlazorGrid component can be used in a Blazor application only. To create a Blazor application follow the steps mentioned at https://blazor.net/docs/get-started.html
# Nuget Gallery
The Nuget package page can be found at https://www.nuget.org/packages/BlazorGrid/
# Installation
To install ```BlazorGrid``` using NPM run the following command
```
Install-Package BlazorGrid
```
To install ```BlazorGrid``` using .NET CLI run the following command
```
dotnet add package BlazorGrid
```
After you have installed the package add the following line in the ```_ViewImports.cshtml``` file
```
@addTagHelper *,BlazorGridComponent
```
# Sample usage
The ```<BlazorGrid>``` component accepts following parameters
-	**Items** : The list of items supplied to the BlazorGrid.
-	**PageSize** : Size of each page of BlazorGrid. This is a required field.
-	**GridHeader** : Header for BlazorGrid.
-	**GridRow** : Rows for BlazorGrid.

Refer to the sample code below:

```
<BlazorGrid Items="@forecasts" PageSize="4">
	<GridHeader>
		<th>Date</th>
		<th>TemperatureC</th>
		<th>TemperatureF</th>
		<th>Summary</th>
	</GridHeader>
	<GridRow>
		<td>@context.Date.ToShortDateString()</td>
		<td>@context.TemperatureC</td>
		<td>@context.TemperatureF</td>
		<td>@context.Summary</td>
	</GridRow>
</BlazorGrid>
```
```
@functions {
    WeatherForecast[] forecasts;

    protected override async Task OnInitAsync()
    {
        forecasts = await Http.GetJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string Summary { get; set; }
    }
}
```
# Sample Output
![Alt Text](https://github.com/AnkitSharma-007/BlazorGrid/blob/master/BlazorGridComponent/BlazorGridDemo.PNG)
# Release notes
**1.1**
> - Updated license 

**1.0**
> - Initial release
