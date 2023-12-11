namespace Loge.Application.Contracts;

public class TransportOrderDto
{
    public Guid Id { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string State { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
}