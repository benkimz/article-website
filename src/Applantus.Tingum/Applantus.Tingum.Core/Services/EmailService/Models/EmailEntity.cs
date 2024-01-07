using System.Net.Sockets;

namespace Applantus.Tingum.Core.Services.EmailService.Models;

public class EmailEntity
{
    public string? Name { get; set; }
    public string Address { get; set; }
    public EmailEntity(string address, string? name = null)
    {
        Name = name ?? string.Empty;
        Address = address;
    }
}
