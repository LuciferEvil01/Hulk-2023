# Informe del Proyecto Hulk

> Este proyecto esta conformado de tres partes:
 El lexer que analiza y tokeniza el codigo, el parser que conforma el AST y analiza errores sintaticos y el inteprete que se apoya en este AST para ejecutar los comandos pedidos

 ## Estructura de clase:
  ### lexer:
 * Lexer: Clase que analiza el codigo y lo tokeniza.
 * token: clase que define la estructura basica de un token y sus propiedades.
 * TokenReader: clase que sirve de apoyo al lexer a la hora de moverse por el codigo.

 ### Parser:
 * Parser: Clase que define la estructura basica de un codigo y crea los elementos del AST
 * TokenReader: clase que sirve de apoyo al parser para moverse por la lista de token.
 ### AST
 * Expresion: cojunto de clase que definen los tipos de expresiones que existen
 * Keywords: Cojunto de clase que definen los diferentes tipos de palabras reservadas y sus propiedades
 * ASTNode: Clase abstracta principal que de la cual se derivas todas las demas clases.
 ### Bugs
 * CompilingBugs: clase que recopilas todos los errores que pueden detectarse en el inteprete.
### Clases generales
* Global server: Clase que archiva todos los datos genrales definidos en el servidor 
* Local Server : clase que archiva todos los datos temporales solo accesibles a un grupo especificos de clases.
* EpressionType: tipo de expressiones definidas en el inteprete.


> este proyecto aun no esta concluido debido pero se espera su terminacion en el menor tiempo posible.