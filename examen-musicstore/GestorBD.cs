using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class GestorBD
{
    private MySqlConnection conexion;

    public GestorBD()
    {
        var csb = new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            UserID = "root",
            Password = "",
            Database = "musicstore"
        };
        conexion = new MySqlConnection(csb.ConnectionString);
    }

    public void Insertar(Album p)
    {
        conexion.Open();
        var cmd = conexion.CreateCommand();
        cmd.CommandText = "INSERT INTO album (titulo,artista,anyo,disponible) VALUES (@t,@a,@an,@d)";
        cmd.Parameters.AddWithValue("@t", p.getTitulo());
        cmd.Parameters.AddWithValue("@a", p.getArtista());
        cmd.Parameters.AddWithValue("@an", p.getAnyo());
        cmd.Parameters.AddWithValue("@d", p.isDisponible());
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    public List<Album> ObtenerTodos()
    {
        var lista = new List<Album>();
        conexion.Open();
        var cmd = conexion.CreateCommand();
        cmd.CommandText = "SELECT titulo,artista,anyo,disponible FROM album";
        var r = cmd.ExecuteReader();
        while(r.Read()) 
            lista.Add(new Album(r.GetString(0), r.GetString(1), r.GetInt32(2), r.GetBoolean(3)));
        r.Close();
        conexion.Close();
        return lista;
    }
}
