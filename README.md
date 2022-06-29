# Proyecto_Adn

Entregable:

1.Código Fuente (Para Nivel 2 y 3: En repositorio github)

  Link repositorio codigo fuente: https://github.com/Dmusuga1/Proyecto_Adn
  
2.Instrucciones de cómo ejecutar el programa o la API. (Para Nivel 2 y 3: En README de github).

  -Descargar repositorio y ejecutar con la herramienta visual studio 2019
  
  -En la carpeta sevicios se encuentr la api "ADN.API", dar clic derecho sobre la api y seleccionar la opción "Establecer como proyecto de inicio" 
  
   ![image](https://user-images.githubusercontent.com/61803104/176366644-5ea13032-ae2e-4cd3-85bf-ac5a572e8276.png)

  -Cambiar las credenciales de base de datos que se encuentra en la carpeta accesoDatos, donde en el archivo DMInsight se encontrará el string de conexión.
  
  ![image](https://user-images.githubusercontent.com/61803104/176367235-ff7aa734-885b-40ad-b9d0-21f2f482f9c0.png)
  
  -Ejecutar con IIS Express 
  
  ![image](https://user-images.githubusercontent.com/61803104/176367615-e81d9462-b6bf-42b6-bb7f-0aefa56a2042.png)

  -Al ejecutar la api, se abrira el documento Swagger donde se especifica la lista de recursos disponibles en la API REST y las operaciones a las que se puede llamar    en estos recursos, el cual contendra los metodos del servicio (mutant y stats), que podran ser ejecutados desde la misma herramienta.
  
  ![image](https://user-images.githubusercontent.com/61803104/176368200-d3d02f4c-26a7-4bc1-b869-89ea5d929156.png)

  -Ejecución servicio mutant: Para ejecutar el servicio dar clic en "Try it out" e ingresar parametro de entrada
  ![image](https://user-images.githubusercontent.com/61803104/176368678-ea0c891c-cd39-4aa9-85df-82c6dffa05f9.png)

  Respuesta servicio:
  
  ![image](https://user-images.githubusercontent.com/61803104/176368847-00e32110-3c6a-497e-a4ca-f1ae79da4e54.png)

  
  
  -Ejecución servicio stats: Para ejecutar el servicio dar clic en "Try it out"
  
  ![image](https://user-images.githubusercontent.com/61803104/176369121-8f7e0776-e67b-4916-a272-2fe8eac6c5e6.png)



3.URL de la API (Nivel 2 y 3)

- Link Api Post mutant: http://appservicesadn.azurewebsites.net/api/mutant/Mutant

Recibe como parametro de entrada un array, ejemplo: 
		{
  		   "dna": [
   			    "ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"
  			  ]
		}
    
    Ejecución desde la herramienta POSTMAN:
    
    ![image](https://user-images.githubusercontent.com/61803104/176369863-3fc57771-31e4-48d5-a127-7ae12669ad42.png)

    
- Link Api Get stats: http://appservicesadn.azurewebsites.net/api/mutant/stats

    Ejecución desde la herramienta POSTMAN:
    
    ![image](https://user-images.githubusercontent.com/61803104/176369581-fa3813b1-c33e-497c-8fe6-66d3f0e90684.png)

    
  
  
