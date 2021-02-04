# **Custom template for API in Net 5**

Para hacer uso de este template se debe descargar el archivo  Generator/HydraTechTemplate.zip, y sin descomprimir este archivo, introducirlo en la carpeta de Template de visual studio (la ruta puede ser parecida a esta "`C:\Users\PRUEBA\Documents\Visual Studio 2019\Templates\ProjectTemplates\Visual C#`").

Si se guardado en la ruta correcta al crear un nuevo proyecto desde visual studio  en las plantillas por defecto veremos una nueva llamada "`HydraTech Template API`"

- Asigne un nombre de proyecto que sera el mismo que el de la solucion y NO seleccionar el check "incluir solucion y proyecto en la misma carpeta"
- Una vez se auto-genere el proyecto, lanzar desde la consola de administracion de paquetes nugets:
    >     `Update-Database -Context AuthContext`
    >     `Update-Database -Context APIContext`

Esto genera la bbdd en local. y ya tendriamos el proyecto funcionando.
