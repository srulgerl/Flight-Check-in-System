// MainLayout.razor
//@inherits LayoutComponentBase

//<div class= "page" >
//    < main >
//        < div class= "top-row px-4" >
//            < a href = "https://learn.microsoft.com/aspnet/core/" target = "_blank" > About </ a >
//        </ div >
//        < article class= "content px-4" >
//            @Body
//        </ article >
//    </ main >
//</ div >

//// Pages/FlightDisplay.razor
//@page "/flights"
//@inject HttpClient Http
//@inject SignalRClient SignalR

//<h3>✈ Нислэгийн мэдээлэл</h3>

//@if (flights == null)
//{
//    <p>Уншиж байна...</p>
//}
//else
//{
//    < table class= "table table-bordered" >
//        < thead >
//            < tr >
//                < th > Flight Number </ th >
//                < th > Departure </ th >
//                < th > Arrival </ th >
//                < th > Departure Time </ th >
//                < th > Arrival Time </ th >
//                < th > Status </ th >
//            </ tr >
//        </ thead >
//        < tbody >
//            @foreach(var flight in flights)
//            {
//                < tr >
//                    < td > @flight.FlightNumber </ td >
//                    < td > @flight.Departure </ td >
//                    < td > @flight.Arrival </ td >
//                    < td > @flight.DepartureDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm") </ td >
//                    < td > @flight.ArrivalDate.ToLocalTime().ToString("yyyy-MM-dd HH:mm") </ td >
//                    < td > @flight.Status </ td >
//                </ tr >
//            }
//        </ tbody >
//    </ table >
//}

//@code {
//    private List<Flight>? flights;

//protected override async Task OnInitializedAsync()
//{
//    SignalR.OnFlightStatusChanged += HandleFlightStatusChanged;
//    await SignalR.StartAsync("https://localhost:5001/flightHub");
//    flights = await Http.GetFromJsonAsync<List<Flight>>("api/flights");
//}

//private void HandleFlightStatusChanged(int flightId, string status)
//{
//    var flight = flights?.FirstOrDefault(f => f.FlightId == flightId);
//    if (flight != null)
//    {
//        flight.Status = status;
//        InvokeAsync(StateHasChanged);
//    }
//}

//public class Flight
//{
//    public int FlightId { get; set; }
//    public string FlightNumber { get; set; } = "";
//    public string Departure { get; set; } = "";
//    public string Arrival { get; set; } = "";
//    public DateTime DepartureDate { get; set; }
//    public DateTime ArrivalDate { get; set; }
//    public string Status { get; set; } = "";
//}
//}

//// App.razor
//< Router AppAssembly = "@typeof(Program).Assembly" >
//    < Found Context = "routeData" >
//        < RouteView RouteData = "@routeData" DefaultLayout = "@typeof(MainLayout)" />
//        < FocusOnNavigate RouteData = "@routeData" Selector = "h1" />
//    </ Found >
//    < NotFound >
//        < PageTitle > Not found </ PageTitle >
//        < LayoutView Layout = "@typeof(MainLayout)" >
//            < p role = "alert" > Sorry, there's nothing at this address.</p>
//        </LayoutView>
//    </NotFound>
//</Router>

//// SignalRClient.cs
//using Microsoft.AspNetCore.SignalR.Client;

//namespace BlazorApp15;

//public class SignalRClient : IAsyncDisposable
//{
//    private HubConnection? hubConnection;
//    public event Action<int, string>? OnFlightStatusChanged;

//    public async Task StartAsync(string hubUrl)
//    {
//        hubConnection = new HubConnectionBuilder()
//            .WithUrl(hubUrl)
//            .Build();

//        hubConnection.On<int, string>("FlightStatusChanged", (flightId, status) =>
//        {
//            OnFlightStatusChanged?.Invoke(flightId, status);
//        });

//        await hubConnection.StartAsync();
//    }

//    public async ValueTask DisposeAsync()
//    {
//        if (hubConnection is not null)
//        {
//            await hubConnection.DisposeAsync();
//        }
//    }
//}
