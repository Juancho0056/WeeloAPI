[![WeeloAPI](https://img.shields.io/badge/WeeloAPI-v1.0-green)](https://github.com/Juancho0056/WeeloAPI)
# PRUEBA PRACTICA SENIOR BACKEND

Prueba 
## Table Of Contents APIController
- [WeeloAPI](#weelo-api)
  - [OwnerController](#ownercontroller)
	* [/api/Owner/Get](#OwnerGet)
	* [/api/Owner/GetAll](#OwnerGetAll)
	* [/api/Owner/GetPhoto](#OwnerGetPhoto)
	* [/api/Owner/Create](#OwnerCreate)
	* [/api/Owner/Update](#OwnerUpdate)
	* [/api/Owner/Delete](OwnerDelete)
  - [PropertyController](#propertycontroller)
	* [/api/Property/Get](#PropertyGet)
	* [/api/Property/GetAll](#PropertyGetAll)
	* [/api/Property/GetPhoto](#PropertyCreateImage)
	* [/api/Property/Create](#PropertyCreate)
	* [/api/Property/Update](#PropertyUpdate)
	* [/api/Property/Delete](PropertyDelete)	
  
1. Configurar base de datos en el archivo appsettings.json, ubicar la seccion ConnectionStrings -> DefaultConnection
2. Abrir consola de comandos visual studio y ejecutar comando ```update-dabase ```
3. Se crean los siguientes datos de acceso para prueba:
   - Username: ```administrator@localhost```
   - Password: ```Administrator1!```
4. Aunque existen Propietarios de prueba, puede crear uno nuevo realizando un consumo POST a  /api/Owner/Create con tipo de contenido en header multipart/form-data.
5. Puede realizar las pruebas de todos los siguientes puntos
	-	Create Property Building 
	-	Add Image from property
	-	Change Price
	-	Update property
	-	List property  with filters
	Al actualizar un precio de una propiedad o si se crea una nueva propiedad se dispara un evento MediatR para insertar un nuevo PropertyTrace
