using Booking.Application.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Event_Ticket_Booking_System.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestDoubleBooking : Controller
{
    [HttpGet("TestDoubleBooking")]
    public async Task<IActionResult> Test()
    {
        var client = new HttpClient();

        var token =
            "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjEiLCJOYW1lIjoiTFVLQSIsIkVtYWlsIjoibC5rYXJrYXJhc2h2aWxpOEBnbWFpbC5jb20iLCJleHAiOjE3ODgwNzQyMTcsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTExMiIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTExMiJ9.gDYEkB7044uu934Qpmy-hYEm5m-Yj3gat6jKmhvM3JM";

        client.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

// Step 2: now fire both booking requests with the token attached
        var request1 = client.PostAsJsonAsync("http://localhost:5112/api/Reservation/CreateReservation", 
            new { EventId = 2, SeatsList = new[] { 17 } });

        var request2 = client.PostAsJsonAsync("http://localhost:5112/api/Reservation/CreateReservation", 
            new { EventId = 2, SeatsList = new[] { 17 } });

        var results = await Task.WhenAll(request1, request2);

        foreach (var r in results)
        {
            Console.WriteLine($"{r.StatusCode}: {await r.Content.ReadAsStringAsync()}");
        }

        return Ok();

    }
}