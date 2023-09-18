namespace Store.Coomon.DTO;

public class ResaultDto
{
    public bool InSucces{ get; set; }
    public string Message{ get; set; }
}

public class ResaultDto<TData>
{
    public bool IsSucces{ get; set; }
    public string Message{ get; set; }
    public TData Data { get; set; }
}