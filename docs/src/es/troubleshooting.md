# Solución de problemas

A continuación se resumen los problemas más frecuentes y cómo resolverlos.

- **No se puede iniciar / no se encuentra el entorno de ejecución de .NET** — Para que CSManager funcione se necesita **.NET Desktop Runtime 8** o superior. Si no está instalado, obténgalo en la página de descargas de Microsoft.
- **Falla la lectura de COD** — `Leer base de datos COD (### cristales)` descarga la primera vez un archivo de gran tamaño (más de 800 MB) de Internet. Compruebe la conexión de red y el espacio libre en disco, y vuelva a intentarlo más tarde.
- **No se puede abrir el archivo de la base de datos** — Compruebe que el archivo `*.cdb3` no esté dañado, movido o guardado con otra versión. Si utiliza AMCSD / COD tal cual, puede volver a cargarlos desde `Leer base de datos AMCSD (### cristales)` / `Leer base de datos COD (### cristales)`.
- **El funcionamiento es lento con bases de datos grandes** — Con bases de datos muy grandes como COD, la búsqueda y la carga pueden tardar. Filtre por los criterios necesarios antes de operar.
- **No se puede interoperar con PDIndexer / ReciPro** — Compruebe que el programa de destino esté en ejecución. La transferencia automática al seleccionar se realiza a través del portapapeles (consulte [Interoperación con otros programas](6-interoperation.md)).

Si encuentra un problema que no figura aquí, comuníquelo en los [Issues](https://github.com/seto77/CSManager/issues) de GitHub.
