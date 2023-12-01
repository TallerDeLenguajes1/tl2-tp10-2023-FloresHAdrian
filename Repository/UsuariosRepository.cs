using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace tl2_tp10_2023_FloresHAdrian;
public class UsuariosRepository : IUsuariosRepository
{
    private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

    public void Create(Usuario usuario)
    {
        var query = $"INSERT INTO Usuario(nombre_de_usuario) VALUES (@name);";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@name", usuario.NombreDeUsuario));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Update(int id, Usuario usuario)
    {
        var query = $"UPDATE Usuario SET nombre_de_usuario=@name WHERE id=@id;";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@name",usuario.NombreDeUsuario));
            command.Parameters.Add(new SQLiteParameter("@id",id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<Usuario> GetAll(){
        var query = @"SELECT * FROM Usuario;";
        List<Usuario> lista = new List<Usuario>();

        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);

            using(SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    var usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                    lista.Add(usuario);
                }
            }
            connection.Close();
        }

        return lista;
    }

    public Usuario GetById(int id){
        var query = $"SELECT * FROM Usuario WHERE id= @id;";
        var usuario = new Usuario();

        using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command= new SQLiteCommand(query,connection);
            command.Parameters.Add(new SQLiteParameter("@id", id));
            using( SQLiteDataReader reader = command.ExecuteReader()){
                while(reader.Read()){
                    usuario.id= Convert.ToInt32(reader["id"]) ;
                    usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                }
            }
            connection.Close();
        }
        return usuario;
    }

    public void Remove(int id){
        var query = @"DELETE FROM Usuario WHERE id=@id;";
        using(SQLiteConnection connection = new SQLiteConnection(cadenaConexion)){
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@id",id));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    
}



