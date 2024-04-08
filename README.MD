Comienzo comentando algunos problemas que me he encontrado a la hora de realizar el ejercicio. 

A la hora de correr el programa, me daba constantemente el error 404 página no encontrada. No sabía exactamente por qué, ya que había seguido paso por paso el vídeo del módulo. Resulta que era porque en el archivo Program.cs estaba esta condición:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Al borrarla, la página ya se me visualiza correctamente. He descubierto que también puedo añadir en launchSettings.json la variable "ASPNETCORE_ENVIRONMENT": "Development" y de esta manera, la condicional daría true y correría sin problema, pero bueno, la he eliminado.
 
Creo que el error puede estar en la versión usada de Visual Studio, así como el de Api Web. Yo he usado la versión 8.0, la última que me permite, y en el vídeo sí es cierto que se recomienda usar la 5.0 porque es algo más simple, pero no lo he hecho simplemente porque el IDE no me lo ha permitido, si no recuerdo mal no me deja bajar de la versión 6.0.
Muy bien, arreglado esto sigo los pasos del vídeo e introduzco actores y películas de ejemplo.
 
Ejecuto la app y sale en Swagger sin problemas. Pero, cuando le doy a try out salta un error.
 
Después, en mi versión 8.0 no me sale el archivo Startup.cs, desconozco por qué, ni por qué me deja ejecutar la app sin problemas aunque no esté. Quizás con las nuevas versiones su funcionalidad la han metido en otros archivos, ni idea. La cuestión es que entonces he descubierto que la inyección de dependencias se tiene que hacer en el main, en el Program.cs, con la siguiente línea:
builder.Services.AddTransient<IActorRepository, ActorRepository>();

Metiendo esa línea arreglo ese error 500. Y ahora puedo empezar a hacer la entrega.

-------------------------------------------------------------------------------------------

Ejercicio 1.- Implementar los métodos que han quedado pendientes en la teoria:
- Obtener un Actor por Id.
 
En el controlador creo un nuevo método HttpGet, esta vez con la especificación ("{id}"). Importante señalar que es un Actor, no una Lista como el anterior Get, y le metemos que busque el id como parametro.
Creo la variable actor que almacena la llamada al metodo GetActorById(id) que hace la interfaz _actorRepository.
Después, en el ActorRepository.cs implemento la lógica.
 
Leo toda la lista de Actores del archivo y después creo una variable llamada actorById que almacena el resultado de la función de LinQ FirstOrDefault, que busca en la lista de actores algún Id que se corresponda con el id que introducimos. Si lo hay, devuelve el primero que coincida, si no, devuelve null porque no existe.

- Modificar un Actor.
 
Directamente en el controlador le aplico la lógica al método update actor con el HttpPatch esta vez, que sirve para editar valores. 
 
- Borrar un Actor.
Hago la llamada al método DeleteActor(id) desde el controlador, con la función [HttpDelete]. 
Implemento la siguiente lógica en el repositorio. Hago que se lean todos los actores de la lista, y cuando encuentre alguno que coincida con el Id (lo busca mediante LinQ), lo elimina. Y acto seguido vuelve a escribir la lista en el .json y lo actualiza sin el actor que hemos eliminado.

 
Ejercicio 2.- Implementar los métodos que han quedado pendientes en la teoria:
- Método para añadir un producto (la lógica del repositorio)
Llamo a este método desde el controlador.
 
- Método para aumentar(ArtículoIn) y restar la cantidad(ArtículoOut) de un producto (la lógica del repositorio)
Llamo a este método desde el controlador.
 
Y con esto finaliza. He de decir que me ha costado un poco, soy alumno de 1º de DAM y en clase apenas hemos empezado a dar las excepciones, así que ha tocado adelantar temario.
PD: No sé si lo he documentado correctamente, tengo un pdf con imágenes que he ido capturando del código, pero después me he dado cuenta de que en el README no puedo subir imágenes directamente desde el PC, tendría que
subirlas para poder tener una ruta HTTP...
