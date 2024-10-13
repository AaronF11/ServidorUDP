# ServidorUDP

## Introducción

Bienvenido a **ServidorUDP**, una implementación de un servidor UDP en C# para recibir mensajes de clientes UDP.

## Características

- Escucha en un puerto específico y recibe mensajes de clientes UDP.
- Puede ser utilizado para crear aplicaciones de servidor que requieren comunicación UDP.

## Uso

1. Crea una instancia de la clase `Servidor` y pasa el puerto que deseas utilizar como parámetro.
2. Inicia el servidor llamando al método `IniciarServidor`.
3. El servidor estará listo para recibir mensajes de clientes UDP.

## Ejemplo
```csharp
int puerto = 6789;
Servidor servidorUDP = new Servidor(puerto);
servidorUDP.IniciarServidor();
```

## Licencia
Este proyecto está bajo la licencia MIT. ¡Libre de usar y modificar!

## Agradecimientos
¡Muchas gracias por utilizar ServidorUDP! 😊

## Autores
- Carlos Daniel Juarez Castillon
- Eduardo Robles Ruezga
- Emilio Alejandro Morales Bautista
- Aarón Flores Pasos
