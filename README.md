##Cambios al archivo SQL

Se realizaron cambios logicos a los stored procedures para editar y eliminar. Regresaba error cuando si encontraba personas con el id. Basto con negar la condicion.
Ademas se estandarizo la salida del procedimiento de eliminar para que regresara una respuesta con un formato igual a los demas.


##Seguridad

La aplicacion hace uso de la API interna proporcionada para validar el login. El token se guarda en el session storage y se manda con cada operacion CRUD. Este token se valida con el otro endpoint proporcionado.


##Consideraciones

Se intento realizar una mejora a la vista de actualizacion para jalar los datos dependiendo del ID y editar sobre estos. Lamentablemente por cuestiones de tiempo no pude implementarlo.
En la parte de la aplicacion hago la descarga como csv mediante javascript. No me dio tiempo para investigar como hacerlo con .net en formato excel, una disculpa.

