Para crear la api
dotnet new webapi --use-controllers -o TodoApi
dotnet add package Microsoft.EntityFrameworkCore.InMemory

Para https
dotnet dev-certs https --trust


Para debbug
Cuando Visual Studio Code le solicite que agregue recursos de compilación y depuración del proyecto, seleccione Sí. Si Visual Studio Code no ofrece agregar recursos de compilación y depuración, seleccione Ver>Paleta de comandos y escriba ".NET" en el cuadro de búsqueda. En la lista de comandos, seleccione el comando .NET: Generate Assets for Build and Debug.
Visual Studio Code agrega una carpeta .vscode con los archivos launch.json y tasks.json generados.