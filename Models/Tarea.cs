namespace tl2_tp10_2023_FloresHAdrian;

public enum EstadoTarea{Ideas, ToDo, Review, Done};

public class Tarea {
    public int Id {get;set;}
    public int IdUsuarioPropietario {get;set;}
    public int IdTablero {get;set;}
    public string? Nombre {get;set;}
    public string? Descripcion {get;set;}
    public string? Color {get;set;}
    public EstadoTarea Estado {get;set;}

}
