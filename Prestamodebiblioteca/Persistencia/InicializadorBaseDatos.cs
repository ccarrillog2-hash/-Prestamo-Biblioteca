
using System.Reflection;
using Microsoft.Data.Sqlite;

namespace PrestamoBiblioteca.Persistencia;
internal sealed class InicializadorBaseDatos {

public string RutaBaseDatos {get;} = Environment.GetEnvironmentVariable("prestamo_biblioteca_DB") 
?? Path.Combine(
Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
"UMG", "PrestamoBiblioteca", "Biblioteca.DB");
public string CadenaConexion => new SqliteConnectionStringBuilder{
DataSource = RutaBaseDatos,
ForeignKeys = true }.ToString();
public void Inicializar(){

var Directorio=Path.GetDirectoryName (RutaBaseDato);
if (!String.Isnullorempty (Directorio)) Directory.CreateDirectory(directorio);

using var conexion= new SqliteConnection (CadenaConexion);
conexion.Open();
using var comando= conexion.CreateCommand ();
comando.CommandText= LeerScriptTablas();
comando.ExecuteNonQuery();}

private static string LeerScriptTablas(){
var assamble = Assembly.GetExecutingAssembly();
var Recurso= Esamble.GetManifestResourceName()
.single (Nombre.Endswith ("Crear_Tablas.SQL", StringComparison.OrdinalIgnoreCase));

using var stream= Esamble.getManfestiResourceStream (recursos)
?? throw new InvalidOperation ("Error");

using var lector= new StreamReader(Stream);
return lector.ReadToEnd();
}}





